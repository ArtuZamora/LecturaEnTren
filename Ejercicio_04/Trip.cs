using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_04
{
    class Trip
    {
        public int Hours { get; set; }
        public Dictionary<int, int> Luminosity { get; set; }
        public bool EnoughHours(int lectureHours)
        {
            return lectureHours <= Hours ? true : false;
        }
        public void SetLuminosityValues()
        {
            int hour;
            Luminosity = new Dictionary<int, int>();
            for (int i = 0; i < Hours; i++)
            {
                Console.Write("\nIngrese la luminosidad que habrá en la {0}a hora (0-100): ", i + 1);
                do
                {
                    while (!Int32.TryParse(Console.ReadLine(), out hour))
                    {
                        Console.Write("\nValor incorrecto, ingrese otro valor:");
                    }
                    if (hour < 0 || hour > 100)
                    {
                        Console.Write("\nValor incorrecto, ingrese otro valor:");
                    }
                } while (hour < 0 || hour > 100);
                Luminosity.Add(i + 1, hour);
            }
        }
    }
}
