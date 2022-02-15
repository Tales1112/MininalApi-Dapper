using System.Data.SqlClient;
using static MinimalApiTarefas.Data.TarefaContext;

namespace MinimalApiTarefas.Extesions
{
    public static class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<GetConnection>(sp =>
                async () =>
                {
                    string connectionString = sp.GetService<IConfiguration>()["DefaultConection"];
                    var connection = new SqlConnection(connectionString);
                    await connection.OpenAsync();
                    return connection;
                });

            return builder;
        }
    }
}
