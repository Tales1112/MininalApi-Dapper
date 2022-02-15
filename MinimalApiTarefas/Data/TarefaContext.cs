using System.Data;

namespace MinimalApiTarefas.Data
{
    public class TarefaContext
    {
        public delegate Task<IDbConnection> GetConnection();
    }
}
