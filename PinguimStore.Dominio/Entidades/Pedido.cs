using PinguimStore.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PinguimStore.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EnderecoCompleto { get; set; }
        public int NumeroEndereco { get; set; }


        //FORMA de PAGAMENTO 
        public int FormaPagamentoId { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }

        //PEDIDO
        public virtual ICollection<ItemPedido> ItensPedido { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();
            if (!ItensPedido.Any())
                AdicionarCritica("Critica - Pedido não pode ficar sem item de pedido");

            if (string.IsNullOrEmpty(CEP))
                AdicionarCritica("Critica - CEP deve estar preenchido");

            if (FormaPagamentoId == 0)
                AdicionarCritica("Critica - Não foi informada a forma de pagamento");
        }
    }
}
