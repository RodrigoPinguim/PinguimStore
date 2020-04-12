using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PinguimStore.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PinguimStore.Repositorio.Config
{
    public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(i => i.Id);

            //BUILDER utiliza o padrao FLUENT , permite mapeamento aos metodos de builder de forma encadeada
            builder
                .Property(i => i.ProdutoId)
                .IsRequired();
            builder
                .Property(i => i.Quantidade)
                .IsRequired();
        }
    }
}
