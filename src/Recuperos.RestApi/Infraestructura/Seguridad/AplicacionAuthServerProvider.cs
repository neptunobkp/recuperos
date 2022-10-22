using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using Recuperos.Aplicacion.Comun.Helpers;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.ControlAcceso;
using Recuperos.Aplicacion.Interfaces.Servicios.ControlAcceso.Modelos;
using Recuperos.Modelo.Entidades;
using Recuperos.Servicios.ControlAcceso;
using Recuperos.Servicios.ControlAcceso.Mocks;
using PersistenciaOracle = Recuperos.Persistencia.BaseOracle;
using PersistenciaSqlServer = Recuperos.Persistencia;


namespace Recuperos.RestApi.Infraestructura.Seguridad
{
    public class AplicacionAuthServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => context.Validated());
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            using (var db = EsSqlServer() ? new PersistenciaSqlServer.AppDbContext() : (IAppDbContext)new PersistenciaOracle.AppDbContext())
            {
                var rutLimpio = RutHelper.ExtraerRutDeRutFormateado(context.UserName).GetValueOrDefault().ToString();

                var apiControlAcceso = ApiControlAccesoDeshabilitado() ?
                    new ApiControlAccesoMock(db.Usuarios.FirstOrDefault(o => o.NombreIngreso == rutLimpio)) as IControlAcceso :
                    new ApiControlAcceso(ControlAccesoClient());

                var resultLoginControlAcceso = await apiControlAcceso.Autenticar(context.UserName, context.Password);
                if (resultLoginControlAcceso.ContrasenaCorrecta)
                {
                  
                    var user = db.Usuarios.FirstOrDefault(o => o.NombreIngreso == rutLimpio);
                    if (user != null)
                    {
                        AgregarClaims(identity, user);
                        await Task.Run(() => context.Validated(identity));
                    }
                    else
                    {
                        var usuarioControlAcceso = await apiControlAcceso.ObtenerUsuario(resultLoginControlAcceso.IdUsuario, resultLoginControlAcceso.ListadoTokenes.FirstOrDefault()?.Token);
                        var nuevoUsuarioParaBase = await RegistrarUsuario(context, usuarioControlAcceso, resultLoginControlAcceso, db);
                        AgregarClaims(identity, nuevoUsuarioParaBase);
                        await Task.Run(() => context.Validated(identity));
                    }
                }
                else
                    context.SetError("Credenciales no válidas", "Las credenciales ingresadas no son validas");

                return;
            }
        }

        private static async Task<Usuario> RegistrarUsuario(OAuthGrantResourceOwnerCredentialsContext context, UsuarioResponse usuario,
            LoginResponse resultLoginControlAcceso, IAppDbContext db)
        {
            var nuevoUsuario = new Usuario
            {
                Nombres = usuario.NombreCompleto,
                Rol = resultLoginControlAcceso.RolesUsuario.FirstOrDefault(t => t.Aplicacion.Codigo == "REC20NET")?.Descripcion,
                Correo = usuario.Email,
                NombreIngreso = RutHelper.ExtraerRutDeRutFormateado(context.UserName).GetValueOrDefault().ToString(),
                Rut = RutHelper.ExtraerRutDeRutFormateado(context.UserName).GetValueOrDefault().ToString()
            };
            db.Usuarios.Add(nuevoUsuario);
            await db.SaveChangesAsync(new CancellationToken());
            return nuevoUsuario;
        }

        private static void AgregarClaims(ClaimsIdentity identity, Usuario user)
        {
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.Rol));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Nombres));
            identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString("dd-MM-yyyy")));
        }

        private static HttpClient ControlAccesoClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ControlAcceso.Api.Url"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        private static bool ApiControlAccesoDeshabilitado()
        {
            return string.Compare(ConfigurationManager.AppSettings["ControlAcceso.Api.Deshabilitado"], "true",
                StringComparison.InvariantCultureIgnoreCase) == 0;
        }

        private bool EsSqlServer()
        {
            return string.Compare(ConfigurationManager.AppSettings["App.Persistencia"], "SqlServer",
                StringComparison.InvariantCultureIgnoreCase) == 0;
        }
    }
}