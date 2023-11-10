using Microsoft.AspNetCore.Mvc;
using tl2_tp09_2023_0ignacio.Models;
using tl2_tp09_2023_0ignacio.Repositories;
namespace tl2_tp09_2023_0ignacio.Controllers;

[ApiController]
[Route("[controller]")]
public class kanbanController : ControllerBase
{
    private readonly ILogger<kanbanController> _logger;
    private UsuarioRepository usuarioRepository;
    public kanbanController(ILogger<kanbanController> logger)
    {
        _logger = logger;
        usuarioRepository = new UsuarioRepository();
    }

    [HttpPost("api/{usuario}")]
    public IEnumerable<Usuario> NewUsuario(Usuario usuario)
    {
        usuarioRepository.Create(usuario);
        return Ok(usuario);
    }
}
