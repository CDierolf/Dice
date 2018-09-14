using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice.Classes
{
    public class Die
    {
        Random rand = new Random();

        public int MinValue { get; set; }
        public int MaxValue { get; set; }  // Equal to the number of sides.
        private int[] SideValues { get; set; }

        public Die(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            CreateDie();
        }

        public void CreateDie()
        {
            // Initialize the die's side array.
            SideValues = new int[MaxValue + 1];
            
            // Populate the die's side values.
            for (int i = MinValue; i <= MaxValue; i++)
            {
                SideValues[i] = i;
                //Console.WriteLine(sideValues[i]);
            }
        }

        public int RollDie()
        {
            int dieValue = 0;
            
            dieValue = SideValues[rand.Next(MinValue, MaxValue + 1)];
            //Console.WriteLine(dieValue + " ");

            return dieValue;
        }




        
    }
}
