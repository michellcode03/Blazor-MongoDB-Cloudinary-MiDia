namespace TareasApp.Domain;

public class Reflexion
{
    public string? Id { get; set; }
    public string Sentimientos { get; set; } = string.Empty;
    public string Pensamientos { get; set; } = string.Empty;
    public string ImagenUrl { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
}