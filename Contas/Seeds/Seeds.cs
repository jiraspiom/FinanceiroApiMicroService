using Amazon.Runtime.Internal.Util;
using Contas.Entity;
using financeiro.DataBase;
using MongoDB.Driver;

namespace Contas.Seeds
{
    public class Seeds
    {
        public async static void SeedContexto(IMongoContext contexto)
        {
            await SeedInsertInstituicao(contexto.Instituicoes);
            await SeedInsertContaTipo(contexto.ContaTipos);
            await SeedInsertCor(contexto.Cores);
            await SeedInsertCategoria(contexto.Categorias);

        }

        private async static Task SeedInsertInstituicao(IMongoCollection<Instituicao> collection)
        {
            if (collection.Find(_ => true).Any())
            {
                return;
            }

            var dados = new List<Instituicao>
            {
                new Instituicao {Id = 1, Nome = "Bradesco", Created_at = DateTime.Now },
                new Instituicao {Id = 2, Nome = "Banco do Brasil", Created_at = DateTime.Now },
                new Instituicao {Id = 3, Nome = "Santander", Created_at = DateTime.Now },
                new Instituicao {Id = 4, Nome = "Itaú", Created_at = DateTime.Now },
                new Instituicao {Id = 5, Nome = "NuBank", Created_at = DateTime.Now },
                new Instituicao {Id = 6, Nome = "Caixa", Created_at = DateTime.Now },
                new Instituicao {Id = 7, Nome = "Inter", Created_at = DateTime.Now },
            };

            await collection.InsertManyAsync(dados);
        }

        private async static Task SeedInsertContaTipo(IMongoCollection<ContaTipo> collection)
        {
            if (collection.Find(_ => true).Any())
            {
                return;
            }

            var dados = new List<ContaTipo>
            {
                new ContaTipo {Id = 1, Nome = "Conta corrente", Created_at = DateTime.Now },
                new ContaTipo {Id = 2, Nome = "Dinheiro", Created_at = DateTime.Now },
                new ContaTipo {Id = 3, Nome = "Poupanca", Created_at = DateTime.Now },
                new ContaTipo {Id = 4, Nome = "Investimento", Created_at = DateTime.Now },
                new ContaTipo {Id = 5, Nome = "Vale Refeição", Created_at = DateTime.Now },
                new ContaTipo {Id = 6, Nome = "Vale Alimentação", Created_at = DateTime.Now },
                new ContaTipo {Id = 7, Nome = "Outros", Created_at = DateTime.Now },
            };

            await collection.InsertManyAsync(dados);
        }

        private async static Task SeedInsertCor(IMongoCollection<Cor> collection)
        {
            if (collection.Find(_ => true).Any())
            {
                return;
            }

            var dados = new List<Cor>
            {
                new Cor {Id = 1, Nome = "azul" },
                new Cor {Id = 2, Nome = "verde" },
                new Cor {Id = 3, Nome = "vermelho" },
                new Cor {Id = 4, Nome = "laranja" },
                new Cor {Id = 5, Nome = "amarelo" }
            };

            await collection.InsertManyAsync(dados);
        }

        private async static Task SeedInsertCategoria(IMongoCollection<Categoria> collection)
        {
            if (collection.Find(_ => true).Any())
            {
                return;
            }

            var dados = new List<Categoria>
            {
                new Categoria { Id = 101, Nome = "Casa", Tipo = "despesa", Status= true},
                new Categoria { Id = 102, Nome = "Educação", Tipo = "despesa", Status= true },
                new Categoria { Id = 103, Nome = "Eletrônicos", Tipo = "despesa", Status= true },
                new Categoria { Id = 104, Nome = "Lazer", Tipo = "despesa", Status= true },
                new Categoria { Id = 105, Nome = "Outros", Tipo = "despesa", Status= true },
                new Categoria { Id = 105, Nome = "Restaurante", Tipo = "despesa", Status= true },
                new Categoria { Id = 106, Nome = "Saúde", Tipo = "despesa", Status= true },
                new Categoria { Id = 107, Nome = "Serviços", Tipo = "despesa", Status= true },
                new Categoria { Id = 108, Nome = "Supermercado", Tipo = "despesa", Status= true },
                new Categoria { Id = 109, Nome = "Transportes", Tipo = "despesa", Status= true },
                new Categoria { Id = 110, Nome = "Vestuario", Tipo = "despesa", Status= true },
                new Categoria { Id = 111, Nome = "Viagem", Tipo = "despesa", Status= true },

                new Categoria { Id = 301, Nome = "Investimento", Tipo = "receita", Status = true },
                new Categoria { Id = 302, Nome = "Outros", Tipo = "receita", Status = true },
                new Categoria { Id = 303, Nome = "Prêmio", Tipo = "receita", Status = true },
                new Categoria { Id = 304, Nome = "Presente",Tipo = "receita", Status = true },
                new Categoria { Id = 305, Nome = "Salário", Tipo = "receita", Status = true },
            };

            await collection.InsertManyAsync(dados);
        }


    }
}
