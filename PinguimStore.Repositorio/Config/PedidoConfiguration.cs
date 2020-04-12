using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PinguimStore.Dominio.Entidades;
using System;


namespace PinguimStore.Repositorio.Config
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(pe => pe.Id);

            //builder.HasOne(pe => pe.UsuarioId); 

            //BUILDER utiliza o padrao FLUENT , permite mapeamento aos metodos de builder de forma encadeada

            builder.HasOne(pe => pe.FormaPagamento);

            builder
                .Property(pe => pe.DataPedido)
                .IsRequired();
            builder
                .Property(pe => pe.DataPrevisaoEntrega)
                .IsRequired();
            builder
                .Property(pe => pe.CEP)
                .IsRequired()
                .HasMaxLength(10);
            builder
                .Property(pe => pe.Estado)
                .IsRequired()
                .HasMaxLength(20);
            builder
                .Property(pe => pe.Cidade)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(pe => pe.EnderecoCompleto)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(pe => pe.NumeroEndereco)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
