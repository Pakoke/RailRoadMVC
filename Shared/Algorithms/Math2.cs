using System;

namespace BTAlgorithms
{
    internal class Math2
    {
        
        private static Random rnd = new Random(21*21);

        internal static int getRandomInt(int a, int b)
        {
            int valor;
            
            if (b - a == 1)
            {
                valor = a;
            }
            else
            {
                valor = a + rnd.Next(b - a);
            }
            return valor;
        }
    }
}