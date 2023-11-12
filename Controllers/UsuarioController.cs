using Microsoft.AspNetCore.Mvc;
using tl2_tp09_2023_0ignacio.Models;
using tl2_tp09_2023_0ignacio.Repositories;
namespace tl2_tp09_2023_0ignacio.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;
    private UsuarioRepository usuarioRepository;
    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuarioRepository = new UsuarioRepository();
    }

    [HttpPost("api/usuario")]
    public ActionResult<Usuario> NewUsuario(Usuario usuario)
    {
        usuarioRepository.Create(usuario);
        return Ok(usuario);
    }

    [HttpGet("api/usuario")]
    public ActionResult<List<Usuario>> GetAllUsuarios()
    {
        var usuarios = usuarioRepository.GetAll();
        return Ok(usuarios);
    }

    [HttpGet("api/usuario/{id}")]
    public ActionResult<Usuario> GetUsuarioById(int idUsuario)
    {
        var usuario = usuarioRepository.GetById(idUsuario);
        return (usuario == null) ? NotFound("No se encontro un usuario con ese ID") : Ok(usuario);
    }

    [HttpPut("api/usuario/{id}/nombre")]
    public ActionResult<Usuario> UpdateUsuario(int idUsuario, Usuario usuario)
    {
        usuarioRepository.Update(idUsuario, usuario);
        return NoContent();
    }

    [HttpDelete("api/usuario/{id}")]
    public ActionResult<Usuario> DeleteUsuario(int idUsuario)
    {
        usuarioRepository.Delete(idUsuario);
        return NoContent();
    } 
}
