using Mercado.Dados;
using Mercado.Dominio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mercado.WinApp
{
    public partial class GerenciarProdutoForm : Form
    {
        private ProdutoDAO _produtoDAO;
        private Produto _produtoBuscado;

        public GerenciarProdutoForm()
        {
            _produtoDAO = new ProdutoDAO();
            _produtoBuscado = new Produto();

            InitializeComponent();
        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            listaBusca.Items.Clear();

           var listaProdutos = _produtoDAO.BuscaTodos();

            foreach (var produto in listaProdutos)
            {
                listaBusca.Items.Add(produto);
            }

            var listaProdutosDT = _produtoDAO.BuscaTodosDT();

            dgvListaProdutos.DataSource = listaProdutosDT;
        }

        private void btnBuscarPorNome_Click(object sender, EventArgs e)
        {
            listaBuscaPorNome.Items.Clear();

            var produtosBuscado = _produtoDAO.BuscaPorNome(txtNomeBusca.Text);

            foreach (var produto in produtosBuscado)
            {
                listaBuscaPorNome.Items.Add(produto);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //POPULAR PRODUTO
            Produto novoProduto = new Produto();

            novoProduto.Nome = txtNome.Text;
            novoProduto.Preco = double.Parse(txtPreco.Text.Replace('.',','));
            novoProduto.Categoria = cmbCategoria.Text;

            //ADICIONAR NO BANCO
            _produtoDAO.AdicionarProduto(novoProduto);

            LimparCampos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listaBuscaPorNome.Items.Clear();

            _produtoBuscado = _produtoDAO.BuscarPorId(Convert.ToInt32(txtId.Text));

            lbProduto.Text = _produtoBuscado.Nome;
            numQntEstoque.Value = _produtoBuscado.QuantidadeEstoque;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            _produtoBuscado.AtualizarEstoque((int)numQntEstoque.Value);
            
            _produtoDAO.AtualizarProduto(_produtoBuscado);

            LimparCampos();
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtPreco.Clear();
            cmbCategoria.SelectedIndex = -1;
            txtId.Clear();
            txtNomeBusca.Clear();
            numQntEstoque.Value = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _produtoDAO.DeletarProduto(_produtoBuscado);

            LimparCampos();
        }
    }
}