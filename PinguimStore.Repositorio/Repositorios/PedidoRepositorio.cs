using PinguimStore.Dominio.Contratos;
using PinguimStore.Dominio.Entidades;
using PinguimStore.Repositorio.Contexto;

namespace PinguimStore.Repositorio.Repositorios
{
    public class PedidoRepositorio : BaseRepositorio<Pedido>, IPedidoRepositorio
    {
        public PedidoRepositorio(PinguimStoreContexto pinguimStoreContexto) : base(pinguimStoreContexto)
        {
        }
    }
}
