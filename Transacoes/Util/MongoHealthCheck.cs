using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Driver;

namespace Pagamentos.Util
{
    public class MongoHealthCheck : IHealthCheck
    {
        private readonly IMongoClient _mongoClient;

        public MongoHealthCheck(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
			try
			{
                await _mongoClient.ListDatabaseNamesAsync(cancellationToken);

                return HealthCheckResult.Healthy();
            }
			catch (Exception ex)
			{
                return HealthCheckResult.Unhealthy("Erro ao verificar a conexão com o MongoDB", ex);
            }
        }
    }
}
