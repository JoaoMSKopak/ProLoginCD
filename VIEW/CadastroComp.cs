using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MODEL;
using BUSINESS;

namespace VIEW
{
    public partial class CadastroComp : Form
    {
        public CadastroComp()
        {
            InitializeComponent();
        }

        public CadastroComp(string usulog)
        {
            InitializeComponent();
            label5.Text = usulog;
            label7.Text = DateTime.Now.ToShortDateString();
        }


        public void LimparCampos()
        {
            txtNomeC.Clear();
            txtPre.Clear();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Componente componente = new Componente();
            ComponenteBusiness componenteBusiness = new ComponenteBusiness();
            componente.Nomecomp = txtNomeC.Text;
            componente.Precocomp = Convert.ToDecimal(txtPre.Text);
           
            componenteBusiness.Inserir(componente);

           MessageBox.Show("Dados inseridos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCanc_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            PaginaInicial pagina = new PaginaInicial(label5.Text);
            pagina.Show();
            Hide();
        }

        private void CadastroComp_FormClosing(object sender, FormClosingEventArgs e)
        {
           //PaginaInicial pagina = new PaginaInicial(label5.Text);
           //pagina.Show();
        }
    }
}
