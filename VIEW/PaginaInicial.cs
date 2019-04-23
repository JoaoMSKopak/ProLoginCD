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
    public partial class PaginaInicial : Form
    {
        public PaginaInicial(string usulog)
        {
            InitializeComponent();
            label2.Text = usulog;
            label3.Text = DateTime.Now.ToShortDateString();
        }

        public void CarregarDados()
        {
            ComponenteBusiness componenteBusiness = new ComponenteBusiness();
            dGVComp.DataSource = null;
            dGVComp.DataSource = componenteBusiness.CarregarDados();

        }


        public PaginaInicial()
        {
            InitializeComponent();
        }

        private void PaginaInicial_Load(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void PaginaInicial_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            CadastroComp cadastroComp = new CadastroComp(label2.Text);
            cadastroComp.ShowDialog();
            this.Hide();
        }
    }
}
