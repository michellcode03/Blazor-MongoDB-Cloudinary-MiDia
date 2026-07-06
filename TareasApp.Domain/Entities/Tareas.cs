namespace TareasApp.Domain;

public class Tareas
{
    public string? Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public int Minutos { get; set; }
    public string Categoria { get; set; } = string.Empty; // "trabajo", "personal", "hogar"
    public bool Completada { get; set; } = false;
    public DateTime Fecha { get; set; }

}
