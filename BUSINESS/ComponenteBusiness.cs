using System;
using System.Data;
using DATAACESS;
using MODEL;

namespace BUSINESS
{
    public class ComponenteBusiness
    {
        AcessoDados acesso = new AcessoDados();

        #region Inserir
        public void Inserir(Componente componente)
        {
            try
            {
                acesso.LimparParametro();
                acesso.AdicionarParametro("@NOMECOMP", componente.Nomecomp);
                acesso.AdicionarParametro("@PRECOCOMP", componente.Precocomp.ToString().Replace(",", "."));


                string query = "INSERT INTO componente (NOMECOMP, PRECOCOMP) " +
                    "VALUES (@NOMECOMP, @PRECOCOMP)";

                // Executa o comando para enviar ao banco os valores. (Tipo de comando Texto, enviando a 'query', false é para INSERT/UPDATE/DELETE).
                acesso.ExecutarPersistência(CommandType.Text, query, false);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }
        #endregion

        #region Carregar Dados
        public ComponenteLista CarregarDados()
        {

            ComponenteLista componentes = new ComponenteLista();
            try
            {
                acesso.LimparParametro();
                string query = "SELECT * FROM componente";
                DataTable dataTableComp = acesso.ExecutarConsulta(CommandType.Text, query);

                foreach (DataRow linha in dataTableComp.Rows)
                {
                    Componente componente = new Componente();
                    componente.Codcomp = Convert.ToInt32(linha["CODCOMP"]);
                    componente.Nomecomp = Convert.ToString(linha["NOMECOMP"]);
                    componente.Precocomp = Convert.ToDecimal(linha["PRECOCOMP"]);
                    
                    componentes.Add(componente);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return componentes;
        }
        #endregion
    }
}
