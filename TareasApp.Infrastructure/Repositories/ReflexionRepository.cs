using TareasApp.Domain;
using MongoDB.Driver;

namespace TareasApp.Infrastructure.Repositories;

public class ReflexionRepository
{
    private readonly MongoDbContext _context;
    private readonly CloudinaryService _cloudinaryService;

    public ReflexionRepository(MongoDbContext context, CloudinaryService cloudinaryService)
    {
        _context = context;
        _cloudinaryService = cloudinaryService;
    }

    public async Task AgregarReflexionAsync(Reflexion reflexion)
    {
        await _context.collection_reflexion.InsertOneAsync(reflexion);
    }

    public async Task<List<Reflexion>> ListarReflexionesAsync()
    {
        return await _context.collection_reflexion.Find(_ => true).ToListAsync();
    }
}