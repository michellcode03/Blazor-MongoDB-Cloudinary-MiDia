using TareasApp.Domain;
using MongoDB.Driver;

namespace TareasApp.Infrastructure.Repositories;

public class TareaRepository
{
    // campo privado — guarda el MongoDbContext para usarlo después 
    //es como const Tarea = require('../models/Tarea');
    private readonly MongoDbContext _context;

    // 2. constructor — recibe el contexto cuando se crea el repositorio
    public TareaRepository(MongoDbContext context)
    {
        _context = context;
    }

    public async Task AgregarTareaAsync(Tareas tarea)
    {
        await _context.collection_tarea.InsertOneAsync(tarea);
    
    }

public async Task<List<Tareas>> ListarTareasAsync(DateTime fecha)
{
    var inicio = fecha.Date.ToUniversalTime();
    var fin = fecha.Date.AddDays(1).ToUniversalTime();
    return await _context.collection_tarea.Find(t => t.Fecha >= inicio && t.Fecha < fin).ToListAsync();
}

public async Task ActualizarTareas(string id, bool completada)
{
    var filter = Builders<Tareas>.Filter.Eq(t => t.Id, id);
    var update = Builders<Tareas>.Update.Set(t => t.Completada, completada);
    await _context.collection_tarea.UpdateOneAsync(filter, update);
}
// Builders<T>.Filter — casi. No es "acceder al documento"
//  sino filtrar documentos — es el equivalente al { _id: id } que le mandas al find()

}