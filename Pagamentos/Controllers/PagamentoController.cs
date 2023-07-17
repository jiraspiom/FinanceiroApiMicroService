using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Pagamentos.DataBase;
using Pagamentos.Entity;

namespace Pagamentos.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class PagamentoController : ControllerBase
    {
        private readonly IMongoContexto _contexto;
        protected IMongoCollection<Pagamento> _dbCollection;
        public PagamentoController(IMongoContexto contexto)
        {
            _contexto = contexto;
            _dbCollection = _contexto.GetCollection<Pagamento>(typeof(Pagamento).Name);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pagamento>>> GetAll()
        {
            var all = await _dbCollection.FindAsync(Builders<Pagamento>.Filter.Empty);
            return Ok(all.ToList());
        }
    }
}
