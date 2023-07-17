using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Pagamentos.DataBase;
using Pagamentos.Entity;
using Pagamentos.Interface;

namespace Pagamentos.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _pagamentoService;
        public PagamentoController(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> Contas()
        {
            try
            {
                var pagamentos = await _pagamentoService.GetAllPagamentoAsync();
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
                var pagamento = await _pagamentoService.GetByIdPagamentoAsync(id);
                if (pagamento == null) return NoContent();

                return Ok(pagamento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pagamento model)
        {
            try
            {
                var pagamento = await _pagamentoService.AddPagamento(model);
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
        public async Task<IActionResult> Update(string id, Pagamento model)
        {
            try
            {
                if (model.Id != id)
                    this.StatusCode(StatusCodes.Status409Conflict, "pagamento errada");

                await _pagamentoService.UpdatePagamento(id, model);
                return Ok(new { message = "atualizado" });

                //var pagamento = await _pagamentoService.UpdateConta(id, model);
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
                var pagamento = await _pagamentoService.GetByIdPagamentoAsync(id);
                if (pagamento == null)
                    this.StatusCode(StatusCodes.Status409Conflict,
                        "Você está tentando deletar um Pagamento que não existe");

                await _pagamentoService.DeletePagamento(id);
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
                    $"Erro ao tentar deletar pagamento com id: ${id}. Erro: {ex.Message}");
            }
        }
    }
}
