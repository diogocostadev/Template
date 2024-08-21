using Microsoft.AspNetCore.Mvc;
using Template.Servicos.Interfaces;

namespace Template.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExemploController : ControllerBase
{
    private readonly ILogger<ExemploController> _logger;
    private readonly IExemploService _exemploService;
    
    public ExemploController(ILogger<ExemploController> logger, IExemploService exemploService)
    {
        _logger = logger;
        _exemploService = exemploService;
    }

    [HttpGet]
    [Route("rota-exemplo")]
    public async Task<IResult> Get() => Results.Ok(await _exemploService.Selecionar());
    
}