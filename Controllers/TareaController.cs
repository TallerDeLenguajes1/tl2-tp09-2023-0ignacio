using Microsoft.AspNetCore.Mvc;
using tl2_tp09_2023_0ignacio.Models;
using tl2_tp09_2023_0ignacio.Repositories;
namespace tl2_tp09_2023_0ignacio.Controllers;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    private readonly ILogger<TareaController> _logger;
    private TareaRepository tareaRepository;
    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        tareaRepository = new TareaRepository();
    }

    [HttpPost("api/tarea")]
    public ActionResult<Tarea> NewTarea(int idTablero, Tarea tarea)
    {
        tareaRepository.Create(idTablero, tarea);
        return Ok(tarea);
    }

    [HttpPut("api/tarea/{id}/nombre/{nombre}")]
    public ActionResult<Tarea> UpdateTarea(int idTarea, Tarea tarea)
    {
        tareaRepository.Update(idTarea, tarea);
        return NoContent();
    }

    [HttpPut("api/tarea/{id}/estado/{estado}")]
    public ActionResult<Tarea> UpdateEstadoById(int idTarea, Tarea tarea)
    {
        tareaRepository.Update(idTarea, tarea);
        return NoContent();
    }

    [HttpDelete("api/tarea/{id}")]
    public ActionResult<Tarea> DeleteTarea(int idTarea)
    {
        tareaRepository.Delete(idTarea);
        return NoContent();
    } 

    [HttpGet("api/tarea/{estado}")]
    public ActionResult<Tarea> GetCantByEstado(int estado)
    {
        var tareas = tareaRepository.GetCantEstado(estado);
        return Ok(tareas);
    }

    [HttpGet("api/tarea/usuario/{id}")]
    public ActionResult<List<Tarea>> GetTareasByUsuario(int idUsuario)
    {
        var tareas = tareaRepository.GetAllByUsuario(idUsuario);
        return Ok(tareas);
    }

    [HttpGet("api/tarea/tablero/{id}")]
    public ActionResult<List<Tarea>> GetTareasByTablero(int idTablero)
    {
        var tareas = tareaRepository.GetAllByTablero(idTablero);
        return Ok(tareas);
    }
}