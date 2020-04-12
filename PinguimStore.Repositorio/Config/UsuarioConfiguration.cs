using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PinguimStore.Dominio.Entidades;

namespace PinguimStore.Repositorio.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            //BUILDER utiliza o padrao FLUENT , permite mapeamento aos metodos de builder de forma encadeada
            builder
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(400);
            builder
                .Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(u => u.SobreNome)
                .IsRequired()
                .HasMaxLength(50);
            //DEFINE RELACIONAMENTO COM PEDIDOS - 1 pra Muitos
            builder
                 .HasMany(u => u.Pedidos)
                 .WithOne(p => p.Usuario);
        }
    }
}
