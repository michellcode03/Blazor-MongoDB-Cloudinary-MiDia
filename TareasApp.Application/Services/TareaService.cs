using TareasApp.Domain;
using TareasApp.Infrastructure.Repositories;

namespace TareasApp.Application.Services;

public class TareaService
{
    // tampoco puedes reasignarlo después
    private readonly TareaRepository _tareaRepository;

    public TareaService(TareaRepository tareaRepository)
    {
        _tareaRepository = tareaRepository;
    }

    public async Task ValidarTarea(Tareas tareas)
    {
        if(string.IsNullOrEmpty(tareas.Titulo)) throw new ArgumentException("El título de la tarea no puede estar vacío.");
        if(tareas.Minutos <= 0) throw new ArgumentException("El tiempo de la tarea debe ser mayor a cero.");
        if(string.IsNullOrEmpty(tareas.Categoria)) throw new ArgumentException("La categoría de la tarea no puede estar vacía.");
        if(tareas.Completada) throw new ArgumentException("La tarea no puede estar marcada como completada al momento de crearla.");
        if(tareas.Id == null) tareas.Id = Guid.NewGuid().ToString();

        await _tareaRepository.AgregarTareaAsync(tareas);
    }

    public async Task ActualizarTarea(string id, bool completada)
    {
        await _tareaRepository.ActualizarTareas(id, completada);
    }

    public async Task<List<Tareas>> ObtenerTareas(DateTime fecha)
    {
    return await _tareaRepository.ListarTareasAsync(fecha);
    }

}