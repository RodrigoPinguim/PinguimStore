using PinguimStore.Dominio.Contratos;
using PinguimStore.Dominio.Entidades;
using PinguimStore.Repositorio.Contexto;

namespace PinguimStore.Repositorio.Repositorios
{
    public class ProdutoRepositorio : BaseRepositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(PinguimStoreContexto pinguimStoreContexto) : base(pinguimStoreContexto)
        {
        }
    }
}
