using PinguimStore.Dominio.Contratos;
using PinguimStore.Dominio.Entidades;
using PinguimStore.Repositorio.Contexto;

namespace PinguimStore.Repositorio.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(PinguimStoreContexto pinguimStoreContexto) : base(pinguimStoreContexto)
        {
        }
    }
}
