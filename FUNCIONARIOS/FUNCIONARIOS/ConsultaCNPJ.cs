using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGT_FORMS
{
    internal class ConsultaCNPJ
    {
        public class Program
        {
            public static async Task<ConsultaCNPJ.ReceitaFederal> ConsultarCNPJAsync(string token, string cnpj, string plugin)
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"https://www.sintegraws.com.br/api/v1/execute-api.php?token={token}&cnpj={cnpj}&plugin={plugin}";
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var dados = JsonConvert.DeserializeObject<ConsultaCNPJ.ReceitaFederal>(json);
                        return dados;
                    }
                    else
                    {
                        throw new Exception("Erro ao consultar API: " + response.StatusCode);
                    }
                }
            }
        }

        public class ReceitaFederal
        {
            public String code { get; set; }
            public string status { get; set; }
            public String message { get; set; }
            public List<AtividadePrincipal> atividade_principal { get; set; }
            public string data_situacao { get; set; }
            public string complemento { get; set; }
            public string nome { get; set; }
            public string uf { get; set; }
            public string telefone { get; set; }
            public string email { get; set; }
            public List<AtividadesSecundaria> atividades_secundarias { get; set; }
            public List<Qsa> qsa { get; set; }
            public string situacao { get; set; }
            public string bairro { get; set; }
            public string logradouro { get; set; }
            public string numero { get; set; }
            public string cep { get; set; }
            public string municipio { get; set; }
            public string abertura { get; set; }
            public string natureza_juridica { get; set; }
            public string cnpj { get; set; }
            public string ultima_atualizacao { get; set; }
            public string tipo { get; set; }
            public string fantasia { get; set; }
            public string efr { get; set; }
            public string motivo_situacao { get; set; }
            public string situacao_especial { get; set; }
            public string data_situacao_especial { get; set; }
            public string capital_social { get; set; }
            public string porte { get; set; }
            public Ibge ibge { get; set; }
        }

        public class AtividadePrincipal
        {
            public string text { get; set; }
            public string code { get; set; }
        }

        public class AtividadesSecundaria
        {
            public string text { get; set; }
            public string code { get; set; }
        }

        public class Qsa
        {
            public string qual { get; set; }
            public string qual_rep_legal { get; set; }
            public string nome_rep_legal { get; set; }
            public string pais_origem { get; set; }
            public string nome { get; set; }
        }

        public class Ibge
        {
            public string codigo_municipio { get; set; }
            public string codigo_uf { get; set; }
        }
    }
}
