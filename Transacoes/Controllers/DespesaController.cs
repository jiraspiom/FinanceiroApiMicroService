﻿using Microsoft.AspNetCore.Mvc;
using Transacoes.Entity;
using Transacoes.Interface.Service;

namespace Transacoes.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class DespesaController : ControllerBase
    {
        private readonly IDespesaService _service;
        public DespesaController(IDespesaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Contas()
        {
            try
            {
                var pagamentos = await _service.GetAllDespesaAsync();
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
                var pagamento = await _service.GetByIdDespesaAsync(id);
                if (pagamento == null) return NoContent();

                return Ok(pagamento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Despesa model)
        {
            try
            {
                var pagamento = await _service.AddDespesa(model);
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
        public async Task<IActionResult> Update(string id, Despesa model)
        {
            try
            {
                if (model.Id != id)
                    this.StatusCode(StatusCodes.Status409Conflict, "despesa errada");

                await _service.UpdateDespesa(id, model);
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
                var pagamento = await _service.GetByIdDespesaAsync(id);
                if (pagamento == null)
                    this.StatusCode(StatusCodes.Status409Conflict,
                        "Você está tentando deletar uma despesa que não existe");

                await _service.DeleteDespesa(id);
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
                    $"Erro ao tentar deletar despesa com id: ${id}. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("total")]
        public async Task<IActionResult> TotalDespesa()
        {
            try
            {
                var total = await _service.GetTotalDespesa();
                if (total == null) return NoContent();

                return Ok(total);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {ex.Message}");
            }
        }
    }
}
