using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PinguimStore.Dominio.Entidades;


namespace PinguimStore.Repositorio.Config
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            //BUILDER utiliza o padrao FLUENT , permite mapeamento aos metodos de builder de forma encadeada
            builder
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(400);
            builder
                .Property(p => p.Preco)
                .IsRequired();
        }
    }
}
