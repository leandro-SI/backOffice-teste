using BackOffice.Aplicacao.DTOs;
using BackOffice.Aplicacao.Services;
using BackOffice.Aplicacao.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;

        public DepartamentosController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        [HttpGet]
        [Route("ListarDepartamentos")]
        public async Task<ActionResult<IEnumerable<DepartamentoDTO>>> ListarDepartamentos()
        {

            try
            {
                var departamentos = await _departamentoService.ListarDepartamentos();

                if (departamentos.ToList().Count == 0) return NotFound("Nenhum registro encontrado.");

                return Ok(departamentos);
            }
            catch (Exception _error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar listar os departamentos. Erro: {_error.Message}");
            }

        }

        [HttpGet]
        [Route("BuscarDepartamento")]
        public async Task<ActionResult<DepartamentoDTO>> BuscarDepartamento(long id)
        {
            try
            {
                var departamento = await _departamentoService.BuscarDepartamento(id);

                if (departamento == null) return NotFound("Departamento não encontrado.");

                return Ok(departamento);
            }
            catch (Exception _error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar buscar o departamento. Erro: {_error.Message}");
            }
        }

        [HttpPost]
        [Route("CadastrarDepartamento")]
        public async Task<ActionResult> CadastrarDepartamento([FromBody] DepartamentoDTO departamentoDTO)
        {
            try
            {
                if (departamentoDTO == null)
                    return BadRequest("Dados inválidos.");

                await _departamentoService.CadastrarDepartamento(departamentoDTO);

                return Ok("true");
            }
            catch (Exception _error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar cadastrar o departamento. Erro: {_error.Message}");
            }
        }

        [HttpPut]
        [Route("AtualizarDepartamento/{id}")]
        public async Task<ActionResult> AtualizarDepartamento(long id, [FromBody] DepartamentoDTO departamentoDTO)
        {
            try
            {
                if (id != departamentoDTO?.Id)
                    return BadRequest();

                if (departamentoDTO == null)
                    return BadRequest();

                await _departamentoService.AtualizarDepartamento(departamentoDTO);

                return Ok(departamentoDTO);
            }
            catch (Exception _error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar o departamento. Erro: {_error.Message}");
            }
        }

    }
}
