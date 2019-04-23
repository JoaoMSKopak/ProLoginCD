using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DATAACESS;
using MODEL;


namespace BUSINESS
{
    public class UsuarioBusiness
    {
        // Cria um novo acesso a dados.
        AcessoDados acesso = new AcessoDados();

        #region Inserir
        public void Inserir(Usuario usuario)
        {
            try
            {
                acesso.LimparParametro();
                acesso.AdicionarParametro("@NOME", usuario.NomeUsu);
                acesso.AdicionarParametro("@USUARIO", usuario.Usu);
                acesso.AdicionarParametro("@SENHA", usuario.Senha);
                acesso.AdicionarParametro("@DATANASC", usuario.DataNasc.ToShortDateString());
                acesso.AdicionarParametro("@EMAIL", usuario.Email);
                acesso.AdicionarParametro("@TELEFONE", usuario.Telefone);
                


                string query = "INSERT INTO usuario (NOME, USUARIO, SENHA, DATANASC, EMAIL, TELEFONE) " +
                    "VALUES (@NOME, @USUARIO, @SENHA, @DATANASC, @EMAIL, @TELEFONE)";

                
                acesso.ExecutarPersistência(CommandType.Text, query, false);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }
        #endregion

        #region Busca de login de usuário
        public DataTable BuscarUsuario(Usuario usuario)
        {
            try
            {
                acesso.LimparParametro();
                acesso.AdicionarParametro("@USUARIO", usuario.Usu);
                acesso.AdicionarParametro("@SENHA", usuario.Senha);

                string query = "SELECT USUARIO, SENHA FROM usuario WHERE USUARIO = @USUARIO AND SENHA = @SENHA COLLATE SQL_Latin1_General_CP1_CS_AS";

                // Retorna um DataTable que faz a consulta caso o usuário e senha estejam no banco. (Se retornar vazio, usuário ou senha inválidos).
                return acesso.ExecutarConsulta(CommandType.Text, query);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        #endregion
    }
}