using PinguimStore.Dominio.Contratos;
using PinguimStore.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PinguimStore.Repositorio.Repositorios
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class
    {
        protected readonly PinguimStoreContexto PinguimStoreContexto;

        public BaseRepositorio(PinguimStoreContexto pinguimStoreContexto)
        {
            PinguimStoreContexto = pinguimStoreContexto;
        }

        public void Adicionar(TEntity entity)
        {
            PinguimStoreContexto.Set<TEntity>().Add(entity);
            PinguimStoreContexto.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            PinguimStoreContexto.Set<TEntity>().Update(entity);
            PinguimStoreContexto.SaveChanges();
        }
        //DISPOSE DESCARTA O OBJETO de CONTEXTO da MEMORIA
        public void Dispose()
        {
            PinguimStoreContexto.Dispose();
        }

        public TEntity ObterPorId(int id)
        {
            return PinguimStoreContexto.Set<TEntity>().Find();
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return PinguimStoreContexto.Set<TEntity>().ToList();
        }

        public void Remover(TEntity entity)
        {
            PinguimStoreContexto.Set<TEntity>().Remove(entity);
            PinguimStoreContexto.SaveChanges();
        }
    }
}
