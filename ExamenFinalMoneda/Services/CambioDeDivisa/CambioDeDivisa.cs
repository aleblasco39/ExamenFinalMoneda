using System;

namespace ExamenFinalMoneda.Services.CambioDeDivisa
{
    public class CambioDeDivisa
    {
        decimal Cantidad;
        decimal resultado;

        public void USDtoCAD()
        {
            Console.WriteLine("Escriba una cantidad para convertir");
            Cantidad = Convert.ToDecimal(Console.ReadLine());
            resultado = Cantidad * (decimal) 0.736;
            resultado = resultado * (decimal) 1.366;
            Console.WriteLine("El resultado será de "+ resultado);
        }
    }
}