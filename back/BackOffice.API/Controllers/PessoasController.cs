using BackOffice.Aplicacao.DTOs;
using BackOffice.Aplicacao.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaService _pessoasService;

        public PessoasController(IPessoaService pessoasService)
        {
            _pessoasService = pessoasService;
        }

        [HttpGet]
        [Route("ListarPessoas")]
        public async Task<ActionResult<IEnumerable<PessoaDTO>>> ListarPessoas()
        {

            try
            {
                var pessoas = await _pessoasService.ListarPessoas();

                if (pessoas.ToList().Count == 0) return NotFound("Nenhum registro encontrado.");

                return Ok(pessoas);
            }
            catch (Exception _error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar listar as pessoas. Erro: {_error.Message}");
            }

        }

        [HttpGet]
        [Route("BuscarPessoa")]
        public async Task<ActionResult<PessoaDTO>> BuscarPessoa(long id)
        {
            try
            {
                var pessoa = await _pessoasService.BuscarPessoa(id);

                if (pessoa == null) return NotFound("Pessoa não encontrada.");

                return Ok(pessoa);
            }
            catch (Exception _error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar buscar pessoa. Erro: {_error.Message}");
            }
        }

        [HttpPost]
        [Route("CadastrarPessoa")]
        public async Task<ActionResult> CadastrarPessoa([FromBody] PessoaDTO pessoaDTO)
        {
            try
            {
                if (pessoaDTO == null)
                    return BadRequest("Dados inválidos.");

                await _pessoasService.CadastrarPessoa(pessoaDTO);

                return new CreatedAtRouteResult("CadastrarPessoa", new { id = pessoaDTO.Id }, pessoaDTO);
            }
            catch (Exception _error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar cadastrar pessoa. Erro: {_error.Message}");
            }
        }

        [HttpPut]
        [Route("AtualizarPessoa")]
        public async Task<ActionResult> AtualizarPessoa(long id, [FromBody] PessoaDTO pessoaDTO)
        {
            try
            {
                if (id != pessoaDTO?.Id)
                    return BadRequest();

                if (pessoaDTO == null)
                    return BadRequest();

                await _pessoasService.AtualizarPessoa(pessoaDTO);

                return Ok(pessoaDTO);
            }
            catch (Exception _error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar pessoa. Erro: {_error.Message}");
            }
        }

        [HttpDelete]
        [Route("DeletarPessoa")]
        public async Task<ActionResult<PessoaDTO>> DeletarPessoa(long id)
        {
            var pessoa = await _pessoasService.BuscarPessoa(id);

            if (pessoa == null)
                return NotFound("Produto não encontrado.");

            await _pessoasService.RemoverPessoa(id);

            return Ok(pessoa);
        }

        [HttpGet]
        [Route("ListarTiposPessoa")]
        public async Task<ActionResult<IEnumerable<TipoPessoaDTO>>> ListarTiposPessoa()
        {

            try
            {
                var tiposPessoa = await _pessoasService.ListarTiposPessoa();

                if (tiposPessoa.ToList().Count == 0) return NotFound("Nenhum registro encontrado.");

                return Ok(tiposPessoa);
            }
            catch (Exception _error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar listar os registros. Erro: {_error.Message}");
            }

        }

        [HttpGet]
        [Route("ListarTiposPerfil")]
        public async Task<ActionResult<IEnumerable<TipoPerfilDTO>>> ListarTiposPerfil()
        {

            try
            {
                var tiposPerfil = await _pessoasService.ListarTiposPerfil();

                if (tiposPerfil.ToList().Count == 0) return NotFound("Nenhum registro encontrado.");

                return Ok(tiposPerfil);
            }
            catch (Exception _error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar listar os registros. Erro: {_error.Message}");
            }

        }

        [HttpGet]
        [Route("ListarQualificacoes")]
        public async Task<ActionResult<IEnumerable<QualificacaoDTO>>> ListarQualificacoes()
        {

            try
            {
                var qualificacoes = await _pessoasService.ListarQualificacoes();

                if (qualificacoes.ToList().Count == 0) return NotFound("Nenhum registro encontrado.");

                return Ok(qualificacoes);
            }
            catch (Exception _error)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar listar os registros. Erro: {_error.Message}");
            }

        }

    }
}
