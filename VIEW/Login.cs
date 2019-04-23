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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //Método para limpar os campos
        public void LimparCampos()
        {
            txtUsu.Clear();
            txtSenha.Clear();
        }

        //Validação de campos vazios
        public string ErroVazio()
        {
            //Cria-se uma variável com valor vazio
            string retorno = "";

            //Se o campo usuário estiver vazio
            if (txtUsu.Text == string.Empty)
            {
                //A variável irá receber a mensagem abaixo
                retorno = retorno + "Digite o seu nome de usuário.";

            }

            //Se o campo senha estiver vazio
            if (txtSenha.Text == string.Empty)
            {
                //A variável irá receber a mensagem abaixo
                retorno = retorno + "Digite sua senha.";

            }

            return retorno;
        }

        //Evento do botão cancelar
        private void btnCanc_Click(object sender, EventArgs e)
        {
            //Chama o método de limpar campos
            LimparCampos();
        }

        //Evento do botão cadastrar
        private void btnCad_Click(object sender, EventArgs e)
        {
            //Se instancia uma nova view cadastro
            CadastroUsuario cadastro = new CadastroUsuario();
            //Mostra a view como diálogo
            cadastro.ShowDialog();
            //Esconde essa view
            this.Hide();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            ErroVazio();
            bool certo = false;
            if (ErroVazio() != "")
            {
                MessageBox.Show(ErroVazio());
                certo = true;
            }

            if (certo == false)
            {
                UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
                Usuario usuario = new Usuario()
                {
                    Usu = txtUsu.Text,
                    Senha = txtSenha.Text
                };

                // Cria um DataTable que busca o login no banco.
                DataTable dt = usuarioBusiness.BuscarUsuario(usuario);

                // Verifica se o número de linhas é maior que 0, se for o login é válido
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Logado com sucesso!", "Login efetuado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                    PaginaInicial pagina = new PaginaInicial(txtUsu.Text);
                    pagina.Show();
                }
                else
                {
                    MessageBox.Show("Usuário ou senha inválidos!", "Erro no login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsu.SelectAll();
                    txtUsu.Focus();
                }
            }
        }
    }
}
