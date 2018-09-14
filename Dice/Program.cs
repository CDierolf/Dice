using Dice.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dieValues = DisplayMenu();                // # rolls, min die value, max die value
            GetRollSums(dieValues);
        }

        public static int[] DisplayMenu()
        {
            int rolls, min = 0, max = 0;
            int[] values = new int[3];
            bool validDieValues = false;
            Console.WriteLine("******DICE GAME******");

            Console.Write("Enter the number of rolls if greater than 72,000: ");
            Int32.TryParse(Console.ReadLine(), out rolls);

            // ensure there are at least 72000 rolls.
            rolls = ValidateRolls(rolls);

            do
            {
                Console.Write("Enter the minimum die value: ");
                Int32.TryParse(Console.ReadLine(), out min);

                Console.Write("Enter the maximum die value: ");
                Int32.TryParse(Console.ReadLine(), out max);

                validDieValues = ValidateDieValues(min, max);
            } while (validDieValues == false);

            values[0] = rolls;
            values[1] = min;
            values[2] = max;

            return values;
        }

        public static int ValidateRolls(int rolls)
        {
            if (rolls < 72000)
                return 72000;
            else
                return rolls;
        }

        public static bool ValidateDieValues(int min, int max)
        {
            if (min >= max)
            {
                Console.WriteLine("Your minimum value cannot be greater than your maximum value.");
                return false;
            }
            else
                return true;
        }

        public static void GetRollSums(int[] values)
        {
            int[] dieSums = new int[values[0]];    // Create an array the size of the number of rolls (dieValues[0]);
            int d1Value, d2Value = 0;              // Holds the return of RollDie() for each die.

            Die d1 = new Die(values[1], values[2]);       // Create first die object with minValue and maxValue
            Die d2 = new Die(values[1], values[2]);       // Create second die object with minValue and maxValue

            for (int i = 0; i < values[0]; i++)      // Roll each die dieValues[0] times and insert
            {                                           // the sums into the dieSums array.
                d1Value = d1.RollDie();
                d2Value = d2.RollDie();
                dieSums[i] = d1Value + d2Value;
            }

            GetDuplicates(dieSums);
        }

        public static void GetDuplicates(int[] sums)
        {
            var duplicateDict = new SortedDictionary<int, int>(); // Hold the duplicates in the array as a key/value pair in a dictionary
                                                            // Key = the number in the array index
                                                            // Value = the instance of that number in the array.

            // Loop through the array and insert them into the dictionary as key/value pairs
            // If the number doesn't exist yet, add it (key) and set its occurance as 1 (value);
            // If it does exist yet, incremnet it's value.
            foreach (var value in sums)
            {
                if (duplicateDict.ContainsKey(value))
                    duplicateDict[value]++;
                else
                    duplicateDict[value] = 1;
            }

            foreach (var pair in duplicateDict)
            {
                Console.WriteLine("Value: {0} Instances: {1}.", pair.Key, pair.Value);
            }

            Console.ReadLine();
        }
    }
}
