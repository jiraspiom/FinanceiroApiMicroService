using Contas.Entity;
using Contas.Interface;
using Microsoft.AspNetCore.Mvc;

namespace financeiro.Controllers
{
    [ApiController]
    [Route("v1/[Controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;
        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpGet]
        public async Task<IActionResult> Contas()
        {
            try
            {
                var contas = await _contaService.GetAllContaAsync();
                if (contas == null) return NoContent();

                return Ok(contas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Conta(string id)
        {
            try
            {
                var conta = await _contaService.GetByIdContaAsync(id);
                if (conta == null) return NoContent();

                return Ok(conta);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Conta model)
        {
            try
            {
                var conta = await _contaService.AddConta(model);
                if (conta == null) return NoContent();

                return Ok(conta);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(string id, Conta model)
        {
            try
            {
                if (model.Id != id)
                    this.StatusCode(StatusCodes.Status409Conflict, "conta errada");

                await _contaService.UpdateConta(id, model);
                return Ok(new { message = "atualizado" });

                //var conta = await _contaService.UpdateConta(id, model);
                //if (conta == null) return NoContent();

                //return Ok(conta);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var conta = await _contaService.GetByIdContaAsync(id);
                if (conta == null)
                    this.StatusCode(StatusCodes.Status409Conflict,
                        "Você está tentando deletar um conta que não existe");

                await _contaService.DeleteConta(id);
                return Ok(new { message = "Deletado" });

                //if (await _contaService.DeleteConta(id))
                //{
                //    return Ok(new { message = "Deletado" });
                //}
                //else
                //{
                //    return BadRequest("Ocorreu um problema não específico ao tentar deletar o usuario.");
                //}
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar conta com id: ${id}. Erro: {ex.Message}");
            }
        }

    }
}
