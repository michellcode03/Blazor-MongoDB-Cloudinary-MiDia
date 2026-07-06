using MongoDB.Driver;
using MongoDB.Bson;
using TareasApp.Domain;

namespace TareasApp.Infrastructure;
public class MongoDbContext
{
    //guarda la conexion a la base de datoss
    private string ConnectionString;
   //guarda el nombre de la base de datos
    private string DatabaseName;
    //guarda el cliente de la base de datos
    private MongoClient Client;
    //guarda las conexiones
    public IMongoCollection<Reflexion> collection_reflexion { get; set; }
    public IMongoCollection<Tareas> collection_tarea { get; set; }

    public MongoDbContext(string connectionString, string databaseName)
    {
        ConnectionString = connectionString;
        DatabaseName = databaseName;
        //mandamos el cliente la conexion
        Client = new MongoClient(ConnectionString);
        //muestra la base de datos
        IMongoDatabase bd = Client.GetDatabase("tareas");
        //Collection
        collection_tarea = bd.GetCollection<Tareas>("tarea");
        collection_reflexion = bd.GetCollection<Reflexion>("reflexion");
    }
}