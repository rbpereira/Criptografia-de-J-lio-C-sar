using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;

namespace Descriptografia
{
    public partial class Descriptografar : Form
    {
        public Descriptografar()
        {
            InitializeComponent();
        }

       

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            string url = txtUrl.Text;
            string token = txtToken.Text;

            CallApi getcall = new CallApi();
            Criptografia criptografia = new Criptografia();

           var Resultado = await getcall.GetCallAPI(url + token);

            jsonCript.Text = Resultado;


            var jsonObj = JObject.Parse(Resultado);

            string cifra = jsonObj["cifrado"].ToString();

            string textDecript = criptografia.Decriptar(cifra);

            string textHash = Hashing.CalculateSHA1(textDecript);

            string textjson = (jsonObj.ToString().Replace(": \"\",", ": " + "\""+textDecript+"\","));

            textjson = textjson.Replace(": \"\"", ": \""+textHash+"\"");

            System.IO.File.WriteAllText(@"C:\Robert\CodeNation\Descriptografia\Descriptografia\Descriptografia\File\answer.json", textjson);

            txtDecript.Text = textjson;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            CallApi httpPost = new CallApi();

            await httpPost.HttpPost();
        }
    }
}
