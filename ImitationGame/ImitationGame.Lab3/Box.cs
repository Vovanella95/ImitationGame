using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitationGame.Lab3
{
    public class Box
    {
        public int N { get; set; }
        public List<bool> Cards { get; set; }
        private Random rand;

        public Box()
        {
            rand = new Random();
            N = 100;
            Cards = new List<bool>();
            for (int i = 0; i < 100; i++)
            {
                Cards.Add(false);
            }
            int num = rand.Next(N);
            Cards[num] = true;
        }

        public bool GetRandomCard()
        {
            var num = rand.Next(N);
            var card = Cards[num];
            Cards.RemoveAt(num);
            N--;
            return card;
        }
    }
}
