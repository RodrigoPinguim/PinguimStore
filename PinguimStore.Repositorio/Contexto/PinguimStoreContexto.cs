using Microsoft.EntityFrameworkCore;
using PinguimStore.Dominio.Entidades;
using PinguimStore.Dominio.ObjetoDeValor;
using PinguimStore.Repositorio.Config;

namespace PinguimStore.Repositorio.Contexto
{
    public class PinguimStoreContexto : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }


        public PinguimStoreContexto(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CLASSES de MAPEAMENTO
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());
            modelBuilder.ApplyConfiguration(new FormaPagamentoConfiguration());

            //CARGA na TABELA FORMAPAGAMENTO
            modelBuilder.Entity<FormaPagamento>().HasData(
               new FormaPagamento()
               {
                   Id = 1,
                   Nome = "Boleto",
                   Descricao = "Forma de Pagamento Boleto"
               },
               new FormaPagamento()
               {
                   Id = 2,
                   Nome = "Cartão de Crédito",
                   Descricao = "Forma de Pagamento Cartão de Crédito"
               },
               new FormaPagamento()
               {
                   Id = 3,
                   Nome = "Depósito",
                   Descricao = "Forma de Pagamento Depósito"
               });

            base.OnModelCreating(modelBuilder);
        }

    }

}
