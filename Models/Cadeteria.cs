namespace cadeteria;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes;
    private List<Pedido> listadoPedidos;
    private static Cadeteria instance;
    private AccesoADatosPedidos accesoADatosPedidos;
    private AccesoADatosCadetes accesoADatosCadetes;

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
        /* listadoPedidos = new List<Pedido>();
        nombre = "Cadeteria de prueba";
        listadoPedidos.Add(new Pedido(1, "primer pedido", new Cliente("Agustin", "direc", "381", "aaa")));
        listadoPedidos.Add(new Pedido(2, "segundo pedido", new Cliente("Agustin", "direc", "382", "bbb")));
        listadoPedidos.Add(new Pedido(3, "tercer pedido", new Cliente("Agustin", "direc", "383", "ccc")));
        listadoCadetes = new List<Cadete>();
        listadoCadetes.Add(new Cadete(1, "Agustin", "Av. Roca 1000", "3811111111"));
        listadoCadetes.Add(new Cadete(2, "Geronimo", "Av. Avellaneda 490", "3811111112"));
        listadoCadetes.Add(new Cadete(3, "Luca", "Laprida 739", "3811111113")); */
    }

    public static Cadeteria GetInstance()
    {
        if (instance == null)
        {
            instance = new Cadeteria();
            var accesoADatosCadeteria = new AccesoADatosCadeteria();
            var accesoADatosCadetes = new AccesoADatosCadetes();
            var accesoADatosPedidos = new AccesoADatosPedidos();
            instance = accesoADatosCadeteria.Obtener();
            instance.accesoADatosPedidos = accesoADatosPedidos;
            instance.accesoADatosCadetes = accesoADatosCadetes;
            instance.listadoPedidos = accesoADatosPedidos.Obtener();
            instance.listadoCadetes = accesoADatosCadetes.Obtener();
        }
        return instance;
    }

    public void CrearPedido(int cadId, int nroP, string obs, string cliNom, string cliDir, string cliTel, string cliRef)
    {
        Cliente clientePedido = new Cliente(cliNom, cliDir, cliTel, cliRef);
        Pedido nuevoPedido = new Pedido(cadId, nroP, obs, clientePedido);
        ListadoPedidos.Add(nuevoPedido);
    }

    public Pedido AgregarPedido(Pedido pedido)
    {
        if (pedido != null)
        {
            listadoPedidos = accesoADatosPedidos.Obtener();
            listadoPedidos.Add(pedido);
            pedido.Nro = listadoPedidos.Count;
            pedido.Estado = Estados.Pendiente;
            accesoADatosPedidos.Guardar(listadoPedidos);
        }
        return pedido;
    }
    public Pedido CambiarEstadoPedido(int idP, int estadoNuevo)
    {
        Estados nuevoEstado = (Estados)estadoNuevo;
        Pedido? pedido = listadoPedidos.Find(ped => ped.Nro == idP);
        if (pedido != null)
        {
            pedido.CambiarEstado(nuevoEstado);
            accesoADatosPedidos.Guardar(listadoPedidos);
        }
        return pedido;
    }

    public Pedido ReasignarPedido(int idP, int idCadN)
    {
        Pedido? pedido = listadoPedidos.Find(ped => ped.Nro == idP);
        Cadete? cadete = listadoCadetes.Find(cad => cad.Id == idCadN);
        if (pedido != null & cadete != null)
        {
            pedido.IdCadete = idCadN;
            accesoADatosPedidos.Guardar(listadoPedidos);
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
                accesoADatosPedidos.Guardar(listadoPedidos);
                return p;
            }
        }
        return null;
    }

    public List<Pedido> DevolverPedidos()
    {
        return listadoPedidos;
    }

    public List<Cadete> DevolverCadetes()
    {
        return listadoCadetes;
    }

    public Pedido ObtenerPedido(int id)
    {
        Pedido p = listadoPedidos.Find(p => p.Nro == id);
        return p;
    }

    public Cadete ObtenerCadete(int id)
    {
        Cadete p = listadoCadetes.Find(c => c.Id == id);
        return p;
    }

    public Cadete AgregarCadete(Cadete cadete)
    {
        if (cadete != null)
        {
            listadoCadetes = accesoADatosCadetes.Obtener();
            listadoCadetes.Add(cadete);
            cadete.Id = listadoCadetes.Count;
            accesoADatosCadetes.Guardar(listadoCadetes);
        }
        return cadete;
    }
}