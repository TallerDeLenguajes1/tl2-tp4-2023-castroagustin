namespace cadeteria;

public class Pedido
{
    private int? nro;
    private string? obs;
    private Cliente? cliente;
    private Estados estado;
    private int idCadete;

    public int? Nro { get => nro; set => nro = value; }
    public string? Obs { get => obs; set => obs = value; }
    public Estados Estado { get => estado; set => estado = value; }
    public Cliente? Cliente { get => cliente; set => cliente = value; }
    public int IdCadete { get => idCadete; set => idCadete = value; }

    public Pedido(int idCadete, int nro, string obs, Cliente cliente)
    {
        this.idCadete = idCadete;
        this.nro = nro;
        this.obs = obs;
        this.cliente = cliente;
        this.estado = Estados.Pendiente;
    }

    public Pedido(int nro, string obs, Cliente cliente)
    {
        this.nro = nro;
        this.obs = obs;
        this.cliente = cliente;
        this.estado = Estados.Pendiente;
    }

    public void CambiarEstado(Estados est)
    {
        if (this.estado == Estados.Pendiente)
        {
            this.estado = est;
        }
    }
}