using Microsoft.AspNetCore.Mvc;
using Transacoes.Entity;
using Transacoes.Interface.Service;

namespace Transacoes.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransferenciaService _service;
        public TransferenciaController(ITransferenciaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Tranferencias()
        {
            try
            {
                var pagamentos = await _service.GetAllTransferenciaAsync();
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
        public async Task<IActionResult> Tranferencia(string id)
        {
            try
            {
                var pagamento = await _service.GetByIdTransferenciaAsync(id);
                if (pagamento == null) return NoContent();

                return Ok(pagamento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Transferencia model)
        {
            try
            {
                var pagamento = await _service.AddTransferencia(model);
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
        public async Task<IActionResult> Update(string id, Transferencia model)
        {
            try
            {
                if (model.Id != id)
                    this.StatusCode(StatusCodes.Status409Conflict, "Transferencia errada");

                await _service.UpdateTransferencia(id, model);
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
                var pagamento = await _service.GetByIdTransferenciaAsync(id);
                if (pagamento == null)
                    this.StatusCode(StatusCodes.Status409Conflict,
                        "Você está tentando deletar uma Transferencia que não existe");

                await _service.DeleteTransferencia(id);
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
                    $"Erro ao tentar deletar Transferencia com id: ${id}. Erro: {ex.Message}");
            }
        }
    }
}
