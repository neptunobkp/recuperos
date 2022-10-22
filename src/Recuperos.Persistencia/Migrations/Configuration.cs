using System.IO;
using System.Reflection;

namespace Recuperos.Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Recuperos.Persistencia.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Recuperos.Persistencia.AppDbContext context)
        {
            RunLocalScript(context, "\\Migrations\\seed1.sql");
        }

        private static void RunLocalScript(AppDbContext context, string rutaScriptLocal)
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            var baseDir = Path.GetDirectoryName(path) + rutaScriptLocal;
            context.Database.ExecuteSqlCommand(File.ReadAllText(baseDir));
        }
    }
}
