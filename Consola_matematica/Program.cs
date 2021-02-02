using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Consola_matematica
{
    class Operacion
    {
        public string tipoOperacion { get; set; }
    public double valor1 { get; set; }
    public double valor2 { get; set; }
    public double resultado { get; set; }

    public Operacion(string tipoOperacion, double valor1, double valor2)
    {
        this.tipoOperacion = tipoOperacion;
        this.valor1 = valor1;
        this.valor2 = valor2;
    }
    }

class Program
    {
        public static Operacion op;
        static void Main(string[] args)
        {
            Sumar();
        }

        public static void Sumar()
        {
            double valor1;
            double valor2;

            Console.WriteLine("Digite el valor numero uno");
            valor1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite el valor numero dos");
            valor2 = Convert.ToInt32(Console.ReadLine());

            op = new Operacion("Suma", valor1, valor2);

            procesar(op);

        }

        private static async void procesar(Operacion op)
        {
            string json = JsonConvert.SerializeObject(op);

            using (var client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "https://localhost:44399/api/operacion";

                var result = await client.PostAsync(url, content);
                string resultContent = await result.Content.ReadAsStringAsync();

                op = JsonConvert.DeserializeObject<Operacion>(resultContent);

                string r = "el resultado es " + op.resultado;
                Console.WriteLine(r);
            }
        }

    }
}
