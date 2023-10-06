namespace cadeteria;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes;
    private List<Pedido> listadoPedidos;
    private static Cadeteria cadeteria;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public Cadeteria(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
        listadoPedidos = new List<Pedido>();
    }
    public Cadeteria()
    {
        listadoPedidos = new List<Pedido>();
        nombre = "Cadeteria de prueba";
        listadoPedidos.Add(new Pedido(1, "primer pedido", new Cliente("Agustin", "direc", "381", "aaa")));
        listadoPedidos.Add(new Pedido(2, "segundo pedido", new Cliente("Agustin", "direc", "382", "bbb")));
        listadoPedidos.Add(new Pedido(3, "tercer pedido", new Cliente("Agustin", "direc", "383", "ccc")));
        listadoCadetes = new List<Cadete>();
        listadoCadetes.Add(new Cadete(1, "Agustin", "Av. Roca 1000", "3811111111"));
        listadoCadetes.Add(new Cadete(2, "Geronimo", "Av. Avellaneda 490", "3811111112"));
        listadoCadetes.Add(new Cadete(3, "Luca", "Laprida 739", "3811111113"));
    } 

     public static Cadeteria GetCadeteria()
    {
        if (cadeteria ==null)
        {
            cadeteria  = new Cadeteria();
        }
        return cadeteria ;
    }

    public void CrearPedido(int cadId, int nroP, string obs, string cliNom, string cliDir, string cliTel, string cliRef)
    {
        Cliente clientePedido = new Cliente(cliNom, cliDir, cliTel, cliRef);
        Pedido nuevoPedido = new Pedido(cadId, nroP, obs, clientePedido);
        ListadoPedidos.Add(nuevoPedido);
    }

    public Pedido AgregarPedido (Pedido pedido) {
        cadeteria.listadoPedidos.Add(pedido);
        pedido.Nro = listadoPedidos.Count + 1;
        return pedido;
    }

    public Pedido CambiarEstadoPedido(int idP, int estadoNuevo)
    {
        Estados nuevoEstado = (Estados) estadoNuevo;
        Pedido? pedido = listadoPedidos.Find(ped => ped.Nro == idP);
        if(pedido != null){
            pedido.CambiarEstado(nuevoEstado);
        }
        return pedido;
    }

    public Pedido ReasignarPedido(int idP, int idCadN)
    {
        Pedido? pedido = listadoPedidos.Find(ped => ped.Nro == idP);
        Cadete? cadete = listadoCadetes.Find(cad => cad.Id == idCadN);
        if(pedido != null & cadete != null){
            pedido.IdCadete = idCadN;
        }
        return pedido;
    }

    public int JornalACobrar(int id)
    {
        int total = 0;
        foreach (Pedido p in ListadoPedidos)
        {
            if (p.IdCadete == id && p.Estado == Estados.Entregado)
            {
                total += 500;
            }
        }
        return total;
    }

    public Pedido asignarCadeteAPedido(int idPed, int idCad)
    {
        foreach (Pedido p in ListadoPedidos)
        {
            if (p.Nro == idPed)
            {
                p.IdCadete = idCad;
                return p;
            }
        }
        return null;
    }

    public List<Pedido> DevolverPedidos() {
        return listadoPedidos;
    }

    public List<Cadete> DevolverCadetes() {
        return listadoCadetes;
    }
}