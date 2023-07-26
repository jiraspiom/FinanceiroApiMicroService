using Microsoft.AspNetCore.Mvc;
using Transacoes.Entity;
using Transacoes.Interface.Service;

namespace Transacoes.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ReceitaController : ControllerBase
    {
        private readonly IReceitaService _service;
        public ReceitaController(IReceitaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Contas()
        {
            try
            {
                var pagamentos = await _service.GetAllReceitaAsync();
                if (pagamentos == null) return NoContent();

                return Ok(pagamentos);
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
                var pagamento = await _service.GetByIdReceitaAsync(id);
                if (pagamento == null) return NoContent();

                return Ok(pagamento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Receita model)
        {
            try
            {
                var pagamento = await _service.AddReceita(model);
                if (pagamento == null) return NoContent();

                return Ok(pagamento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(string id, Receita model)
        {
            try
            {
                if (model.Id != id)
                    this.StatusCode(StatusCodes.Status409Conflict, "receita errada");

                await _service.UpdateReceita(id, model);
                return Ok(new { message = "atualizado" });

                //var pagamento = await _despesaService.UpdateConta(id, model);
                //if (pagamento == null) return NoContent();

                //return Ok(pagamento);
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
                var pagamento = await _service.GetByIdReceitaAsync(id);
                if (pagamento == null)
                    this.StatusCode(StatusCodes.Status409Conflict,
                        "Você está tentando deletar uma receita que não existe");

                await _service.DeleteReceita(id);
                return Ok(new { message = "Deletado" });

                //if (await _pagamentoService.DeletePagamento(id))
                //{
                //    return Ok(new { message = "Deletado" });
                //}
                //else
                //{
                //    return BadRequest("Ocorreu um problema não específico ao tentar deletar o pagamento.");
                //}
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar receita com id: ${id}. Erro: {ex.Message}");
            }
        }
    }
}
