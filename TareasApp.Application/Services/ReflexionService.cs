using TareasApp.Domain;
using TareasApp.Infrastructure.Repositories;

namespace TareasApp.Application.Services;


public class ReflexionService
{
     private readonly ReflexionRepository _reflexionRepository;
     private readonly CloudinaryService _cloudinaryService;

    public ReflexionService(ReflexionRepository reflexionRepository, CloudinaryService cloudinaryService)
    {
        _reflexionRepository = reflexionRepository;
        _cloudinaryService = cloudinaryService;
    }

    public async Task ValidarReflexion(Reflexion reflexion)
    {
        if(string.IsNullOrEmpty(reflexion.Sentimientos)) throw new ArgumentException("Los sentimientos no pueden estar vacíos.");
        if(string.IsNullOrEmpty(reflexion.Pensamientos)) throw new ArgumentException("Los pensamientos no pueden estar vacíos.");
        if(reflexion.Id == null) reflexion.Id = Guid.NewGuid().ToString();
        await _reflexionRepository.AgregarReflexionAsync(reflexion);
    }

    public async Task<string> SubirImagen(Stream imagen, string nombreArchivo)
    {
        return await _cloudinaryService.SubirImagenAsync(imagen, nombreArchivo);
    }

    public async Task<List<Reflexion>> ObtenerReflexiones()
    {
        return await _reflexionRepository.ListarReflexionesAsync();
    }
}

//Cuando el usuario selecciona una imagen en Blazor,
//  el archivo no llega como una ruta ("C:/foto.jpg") — 
// llega como bytes en memoria. Stream es la forma de C# de decir 
// "aquí están los bytes del archivo".