using System;
using System.Collections.Generic;

namespace Source.CodeBase.Infrastructure.Services.Rondomizer
{
    public class RandomShuffler
    {
        private static readonly Random Rng = new Random();

        public static void Shuffle<T>(List<T> list)
        {
            var n = list.Count;
            
            while (n > 1)
            {
                n--;
                var k = Rng.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }
    }
}