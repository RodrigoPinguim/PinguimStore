using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PinguimStore.Dominio.ObjetoDeValor;


namespace PinguimStore.Repositorio.Config
{
    public class FormaPagamentoConfiguration : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            builder.HasKey(f => f.Id);

            //BUILDER utiliza o padrao FLUENT , permite mapeamento aos metodos de builder de forma encadeada
            builder
                .Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(f => f.Descricao)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
