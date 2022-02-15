using Dapper.Contrib.Extensions;
using static MinimalApiTarefas.Data.TarefaContext;

namespace MinimalApiTarefas.Endpoints
{
    public static class TarefasEndpoints
    {
        public static void MapTarefasEndpoints(this WebApplication app)
        {
            app.MapGet("/", () => "Mini Tarefas API");

            app.MapGet("/tarefas", async (GetConnection conncetionGetter) =>
            {
                using var con = await conncetionGetter();
                return con.GetAll<Tarefa>().ToList();
            });

            app.MapGet("/tarefas/{id}", async (GetConnection conncetionGetter,int id) =>
            {
                using var con = await conncetionGetter();
                return con.Get<Tarefa>(id);
            });

            app.MapDelete("/tarefas/{id}", async (GetConnection conncetionGetter, int id) =>
            {
                using var con = await conncetionGetter();
                con.Delete(new Tarefa(id, "", ""));
                return Results.NoContent();
            });

            app.MapPost("/tarefas", async (GetConnection conncetionGetter, Tarefa tarefa) =>
            {
                using var con = await conncetionGetter();
                var id = con.Insert(tarefa);
                return Results.Created($"/tarefas/{id}", tarefa);
            });

            app.MapPut("/tarefas", async (GetConnection conncetionGetter, Tarefa tarefa) =>
            {
                using var con = await conncetionGetter();
                var id = con.Update(tarefa);
                return Results.Ok();
            });

        }
    }
}
