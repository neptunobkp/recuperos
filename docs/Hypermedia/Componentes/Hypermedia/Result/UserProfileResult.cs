using System.Security.Cryptography;
using System.Text;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result {
    public class UserProfileResult {
        public UserProfileResult(string name, string email) {
            Name = name;
            Email = email;
        }

        public string Email { get; }
        public string GravatarUrl => $"https://secure.gravatar.com/avatar/{GenerateHash()}";
        public string LogoutUrl => "/logout";
        public string Name { get; }

        private string GenerateHash() {
            if (string.IsNullOrEmpty(Email)) {
              return string.Empty;
            }

            var md5Hasher = MD5.Create();
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(Email.ToLower()));
            var builder = new StringBuilder();

            for (var i = 0; i < data.Length; i++) {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString().ToLower();
        }
    }
}
