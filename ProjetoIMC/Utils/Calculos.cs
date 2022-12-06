using System;

namespace API.Utils
{
    public class Calculos
    {
        public static double CalcularImc(double altura, double peso)
            => (altura * altura) / peso;
}
}