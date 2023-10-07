using System.Text.Json;
using System.Text.Json.Serialization;

namespace cadeteria;

public class AccesoADatosCadeteria
{
    private string path = "cadeteria.json";
    public Cadeteria Obtener()
    {
        Cadeteria cadeteria = null;
        if (File.Exists(path))
        {
            string textCadeteria = File.ReadAllText(path);
            cadeteria = JsonSerializer.Deserialize<Cadeteria>(textCadeteria);
        }
        else
        {
            Console.WriteLine("no existe la cadeteria");
        }
        return cadeteria;
    }
}