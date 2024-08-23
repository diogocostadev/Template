using Microsoft.AspNetCore.Mvc;
using Template.Contratos.DTOs.Entrada;
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
    [Route("rota-exemplo-listar")]
    public async Task<IResult> Listar([FromQuery] string nome) => await _exemploService.Listar(nome);
    
    [HttpPost]
    [Route("rota-exemplo-inserir")]
    public async Task<IResult> Inserir([FromBody] InserirClienteDto dto) => await _exemploService.Inserir(dto);
    
}