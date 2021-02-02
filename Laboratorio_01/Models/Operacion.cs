using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio_01.Models
{
    public class Operacion
    {
        public String TipoOperacion { get; set; }
        public Double Valor1 { get; set; }
        public Double Valor2 { get; set; }
        public Double Resultado { get; set; }

        public static Operacion Procesar(Operacion op)
        {
            Double Resultado = 0;
            switch (op.TipoOperacion)
            {
                case "Suma":
                    Resultado = op.Valor1 + op.Valor2;
                break;
                case "Resta":
                    Resultado = op.Valor1 - op.Valor2;
                    break;
                case "Multiplicacion":
                    Resultado = op.Valor1 * op.Valor2;
                    break;
                case "Division":
                    Resultado = op.Valor1 / op.Valor2;
                    break;
                default:
                break;
            }

            op.Resultado = Resultado;
            return op;
        }
    }
}