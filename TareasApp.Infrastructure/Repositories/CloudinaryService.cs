using TareasApp.Domain;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace TareasApp.Infrastructure.Repositories;

public class CloudinaryService
{
    private readonly string _cloudName;
    private readonly string _apiKey;
    private readonly string _apiSecret;

    public CloudinaryService(string cloudName, string apiKey, string apiSecret)
    {
        _cloudName = cloudName;
        _apiKey = apiKey;
        _apiSecret = apiSecret;
    }

    public async Task<string> SubirImagenAsync(Stream imagen, string nombreArchivo)
    {
        var account = new Account(_cloudName, _apiKey, _apiSecret);
        var cloudinary = new Cloudinary(account);

        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(nombreArchivo, imagen),
            Folder = "midiapp"
        };

        var resultado = await cloudinary.UploadAsync(uploadParams);
        return resultado.SecureUrl.ToString();
}
}



