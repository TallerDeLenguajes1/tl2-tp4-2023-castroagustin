using Microsoft.AspNetCore.Mvc;

namespace cadeteria.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    private Cadeteria cadeteria;
    private readonly ILogger<CadeteriaController> _logger;

    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        _logger = logger;
        cadeteria = Cadeteria.GetInstance();
    }

    [HttpGet]
    public ActionResult<string> GetNombre()
    {
        return Ok(cadeteria.Nombre);
    }
    [HttpGet]
    [Route("Pedidos")]
    public ActionResult<IEnumerable<Pedido>> GetPedidos()
    {
        var pedidos = cadeteria.DevolverPedidos();
        return Ok(pedidos);
    }

    [HttpGet]
    [Route("Cadetes")]
    public ActionResult<IEnumerable<Cadete>> GetCadetes()
    {
        var cadetes = cadeteria.DevolverCadetes();
        return Ok(cadetes);
    }

    [HttpGet]
    [Route("Pedido")]
    public ActionResult<Pedido> GetPedido(int id)
    {
        var pedido = cadeteria.ObtenerPedido(id);
        return Ok(pedido);
    }

    [HttpGet]
    [Route("Cadete")]
    public ActionResult<Cadete> GetCadete(int id)
    {
        var cadete = cadeteria.ObtenerCadete(id);
        return Ok(cadete);
    }

    [HttpPost]
    [Route("AgregarPedido")]
    public ActionResult<Pedido> AgregarPedido(Pedido pedido)
    {
        var nuevoPedido = cadeteria.AgregarPedido(pedido);
        return Ok(nuevoPedido);
    }

    [HttpPost]
    [Route("AgregarCadete")]
    public ActionResult<Cadete> AgregarCadete(Cadete cadete)
    {
        var nuevoCadete = cadeteria.AgregarCadete(cadete);
        return Ok(nuevoCadete);
    }

    [HttpPut]
    [Route("AsignarPedido")]
    public ActionResult<Pedido> AsignarPedido(int idPedido, int idCadete)
    {
        var pedido = cadeteria.asignarCadeteAPedido(idPedido, idCadete);
        return Ok(pedido);
    }

    [HttpPut]
    [Route("CambiarEstadoPedido")]
    public ActionResult<Pedido> CambiarEstadoPedido(int idPedido, int nuevoEstado)
    {
        var pedido = cadeteria.CambiarEstadoPedido(idPedido, nuevoEstado);
        return Ok(pedido);
    }

    [HttpPut]
    [Route("CambiarCadetePedido")]
    public ActionResult<Pedido> CambiarCadetePedido(int idPedido, int idNuevoCadete)
    {
        var pedido = cadeteria.ReasignarPedido(idPedido, idNuevoCadete);
        return Ok(pedido);
    }
}
