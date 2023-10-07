using System.Text.Json;
using System.Text.Json.Serialization;

namespace cadeteria;

public class AccesoADatosCadetes
{
    private string path = "cadetes.json";
    public List<Cadete> Obtener()
    {
        List<Cadete> cadetes = null;
        if (File.Exists(path))
        {
            string textCadetes = File.ReadAllText(path);
            cadetes = JsonSerializer.Deserialize<List<Cadete>>(textCadetes);
        }
        return cadetes;
    }
}