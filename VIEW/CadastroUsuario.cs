using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MODEL;
using BUSINESS;

namespace VIEW
{
    public partial class CadastroUsuario : Form
    {
        public CadastroUsuario()
        {
            InitializeComponent();
        }

        public void LimparCampos()
        {
            txtNome.Clear();
            txtUsu.Clear();
            txtSenha.Clear();
            txtEmail.Clear();
            mTBTel.Clear();
            dTPNasc.Value = DateTime.Now;
        }

        #region Validação de campos Nome e E-mail
        // Validação de campos Nome, E-mail
        public string ValidarCamposUsuario()
        {
            string erro = "";

            // Verifica se campo Nome tem números.
            if (Regex.IsMatch(txtNome.Text, "^[0-9]"))
            {
                erro += "Nome inválido.\n";
            }

            // Verifica se campo E-mail começa com número, não contém @ ou não contém pelo menos um . depois do @.
            if (Regex.IsMatch(txtEmail.Text.Substring(0), "^[0-9]") || !txtEmail.Text.Contains("@") || txtEmail.Text.LastIndexOf(".") < txtEmail.Text.LastIndexOf("@"))
            {
                erro += "E-mail inválido.\n";
            }

            return erro;
        }
        #endregion

        #region Verificação de campos vazios
        //Verificar se não foi digitado nada
        public string ErroVazio()
        {
            string retorno = "";

            if (txtNome.Text == string.Empty)
            {
                retorno += "O nome não pode ser vazio!\n";

            }
            if (txtUsu.Text == string.Empty)
            {
                retorno += "O usuário não pode ser vazio!\n";

            }
            if (txtSenha.Text == string.Empty)
            {
                retorno = retorno + "A senha não pode ser vazia!\n";

            }

            mTBTel.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mTBTel.Text == string.Empty)
            {
                retorno += "O campo telefone não pode ser vazio!\n";
            }

            if (txtEmail.Text == string.Empty)
            {
                retorno += "O campo email não pode ser vazio!";

            }

            return retorno;

        }
        #endregion

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            ErroVazio();
            bool certo = true;

            if (ErroVazio() != "")
            {
                MessageBox.Show(ErroVazio());
                if (txtNome.Text == string.Empty)
                {
                    txtNome.Focus();
                    certo = false;
                }
                else if (txtUsu.Text == string.Empty)
                {
                    txtUsu.Focus();
                    certo = false;
                }
                else if (txtSenha.Text == string.Empty)
                {
                    txtSenha.Focus();
                    certo = false;
                }
                else if (mTBTel.Text == string.Empty)
                {
                    mTBTel.Focus();
                    certo = false;
                }

                else if (txtEmail.Text == string.Empty)
                {
                    txtEmail.Focus();
                    certo = false;
                }
                
            }

            else if((ValidarCamposUsuario() != "") &&(certo == true))
            {
                MessageBox.Show(ValidarCamposUsuario());
                certo = false;
            }

            else
            {
                Usuario usuario = new Usuario();
                UsuarioBusiness usuarioBusiness = new UsuarioBusiness();
                usuario.NomeUsu = txtNome.Text;
                usuario.Usu = txtUsu.Text;
                usuario.Senha = txtSenha.Text;
                usuario.DataNasc = Convert.ToDateTime(dTPNasc.Text);
                usuario.Email = txtEmail.Text;
                usuario.Telefone = mTBTel.Text;

                usuarioBusiness.Inserir(usuario);

                MessageBox.Show("Dados Cadastrados com sucesso.");
            }
            
        }

        private void btnCanc_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnVolt_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
