using System.Text.Json;
using System.Text.Json.Serialization;

namespace cadeteria;

public class AccesoADatosPedidos
{
    private string path = "pedidos.json";
    public List<Pedido> Obtener()
    {
        List<Pedido> pedidos = null;
        if (File.Exists(path))
        {
            string textPedido = File.ReadAllText(path);
            pedidos = JsonSerializer.Deserialize<List<Pedido>>(textPedido);
        }
        return pedidos;
    }

    public void Guardar(List<Pedido> pedidos)
    {
        if (File.Exists(path))
        {
            string textPedidos = JsonSerializer.Serialize(pedidos);
            File.WriteAllText(path, textPedidos);
        }
    }
}