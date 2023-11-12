using Microsoft.AspNetCore.Mvc;
using tl2_tp09_2023_0ignacio.Models;
using tl2_tp09_2023_0ignacio.Repositories;
namespace tl2_tp09_2023_0ignacio.Controllers;

[ApiController]
[Route("[controller]")]
public class TableroController : ControllerBase
{
    private readonly ILogger<TableroController> _logger;
    private TableroRepository tableroRepository;
    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        tableroRepository = new TableroRepository();
    }

    [HttpPost("api/tablero")]
    public ActionResult<Tablero> NewTablero(Tablero tablero)
    {
        tableroRepository.Create(tablero);
        return Ok(tablero);
    }

    [HttpGet("api/tablero")]
    public ActionResult<List<Tablero>> GetAllTablero()
    {
        var tableros = tableroRepository.GetAll();
        return Ok(tableros);
    }
}