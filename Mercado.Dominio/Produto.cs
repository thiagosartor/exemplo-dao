using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Dominio
{
    public class Produto
    {
        public int Id { get; set; }

        public string  Nome { get; set; }

        public string Categoria { get; set; }

        public double Preco { get; set; }

        public int QuantidadeEstoque { get; private set; }

        public void AtualizarEstoque(int quantidade) 
        {
            QuantidadeEstoque = quantidade;
        }
        public void QuantidadeEmEstoque(int quantidade)
        {
            QuantidadeEstoque = quantidade;
        }

        public override string ToString()
        {
            return String.Format("Id: {0} - Nome: {1} - Categoria: {2} - Estoque: {3}", Id, Nome, Categoria, QuantidadeEstoque);
        }
    }
}
