using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descriptografia
{
    class Criptografia
    {
        public string Decriptar(string texto)
        {
            
            int unicodeValue = 0;
            bool isNumber;
            string palavra;
            string decript = "";
            int j = 0;
            string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower();

            palavra = texto.Replace(" ","/").ToLower();



            foreach (char c in palavra)
            {

                if (char.IsDigit(c.ToString()[0]))
                {
                    isNumber = true;
                }
                else
                {
                    isNumber = false;
                }

                char current;
                if (c.ToString() != "/" && isNumber == false && c.ToString() != ":" && c.ToString() != "." && c.ToString() != "," && c.ToString() != "’")
                {
                    current = c;
                    int valor = 0;
                    bool ultimaLetra = false;
                    int pos = 0;

                    do
                    {
                        if (ultimaLetra == false && valor == 0)
                        {
                            pos = alfabeto.IndexOf(c.ToString());
                        }
                        else if (ultimaLetra == false)
                        {
                            pos = alfabeto.IndexOf(current.ToString());
                        }
                        
                        
                        if (pos == 0 && ultimaLetra == false)
                        {
                            unicodeValue = 90;
                            current = ((char)((int)90));
                            string teste = ($"{current}={unicodeValue}\t");
                            ultimaLetra = true;
                            valor++;
                        }
                        else
                        {
                            current--;
                            valor++;
                            unicodeValue = c;
                            string teste = ($"{c}={unicodeValue}\t");
                        }

                    } while (valor <= 6);

                    decript += current.ToString();
                }
                else
                {
                    decript += c.ToString();
                }
            }

            return decript.Replace("/", " ").ToLower();


        }
    }
}
