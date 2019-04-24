using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Descriptografia
{
    class CallApi
    {
        public async Task<string> GetCallAPI(string completeURL)
        {
            try
            {
                HttpClient cliente = new HttpClient();

                var resultado = await cliente.GetStringAsync(completeURL);

                //var jsonObj = JObject.Parse(resultado);

                //int numero_casas = Convert.ToInt16(jsonObj["numero_casas"]);
                //string token = jsonObj["token"].ToString();
                //string cifrado = jsonObj["cifrado"].ToString();
                //string decifrado;
                //string resumo_criptografico;

                //ToDoItem[] items = JsonConvert.DeserializeObject<ToDoItem[]>(resultado);

                return resultado;
            }
            catch
            {
                throw;
            }
        }

        public async Task HttpPost()
        {
            try
            {
                string FilePath = @"C:\Robert\CodeNation\Descriptografia\Descriptografia\Descriptografia\File\answer.json";
                HttpClient client = new HttpClient();

                MultipartFormDataContent form = new MultipartFormDataContent();
                HttpContent content = new StringContent("fileToUpload");
                form.Add(content, "fileToUpload");
                //var stream = new FileStream(FilePath, FileMode.Open);
                var stream = File.Open(FilePath, FileMode.Open);
                var fileToUpload = new FileInfo(FilePath);



                content = new StreamContent(stream);
                var fileName =
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "answer",
                    FileName = Path.GetFileName(FilePath),
                };
                form.Add(content);
                HttpResponseMessage response = null;

                var url = new Uri("https://api.codenation.dev/v1/challenge/dev-ps/submit-solution?token=a1af12a7b640118c08fa2326c6c7166a34b10690");

                response = await client.PostAsync(url, form);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Arquivo enviado com sucesso.");
                }
                else
                {
                    MessageBox.Show("Ouve algum problema no envio do arquivo, por favor verifique e tente novamente.");
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
