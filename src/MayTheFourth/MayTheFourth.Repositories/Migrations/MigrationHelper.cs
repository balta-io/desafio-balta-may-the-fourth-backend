using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;

namespace MayTheFourth.Repositories.Migrations
{
    internal static class MigrationHelper
    {
        public static void RunMigrationSqlFromFile(this MigrationBuilder migrationBuilder, string fileName)
        {
            Console.WriteLine($"Running file: {fileName}");
            try
            {
                var assembly = Assembly.GetExecutingAssembly();

                var resourceName = $"{typeof(MigrationHelper).Namespace}.{fileName}";

                using (var stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null) return;

                    using (var reader = new StreamReader(stream))
                    {
                        string sqlResult = reader.ReadToEnd();
                        migrationBuilder.Sql(sqlResult);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    string.Format(Utils.Properties.Resources.SqlFileCantBeExecuted, fileName, ex));
            }

        }
    }
}
