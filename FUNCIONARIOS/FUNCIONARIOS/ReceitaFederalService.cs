using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGT_FORMS
{
    internal class ReceitaFederalService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<dynamic> ConsultarCNPJAsync(string cnpj)
        {
            string url = $"https://www.receitaws.com.br/v1/cnpj/{cnpj}";

            try
            {
                var response = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao consultar CNPJ: {ex.Message}");
                return null;
            }
        }
    }
}
