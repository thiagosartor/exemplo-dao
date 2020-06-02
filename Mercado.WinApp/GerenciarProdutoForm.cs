using System;
using System.Windows.Forms;

namespace Mercado.WinApp
{
    public partial class GerenciarProdutoForm : Form
    {
        public GerenciarProdutoForm()
        {
            InitializeComponent();
        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            listaBusca.Items.Clear();
        }

        private void btnBuscarPorNome_Click(object sender, EventArgs e)
        {
            listaBuscaPorNome.Items.Clear();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listaBuscaPorNome.Items.Clear();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
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
    }
}