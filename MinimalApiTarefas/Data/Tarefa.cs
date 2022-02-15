using System.ComponentModel.DataAnnotations.Schema;

[Table("Tarefa")]
public record Tarefa(int Id, string Atividade, string Status);
    

