using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_04
{
    class Program
    {
        static Trip trip = new Trip();
        static Lecture lecture = new Lecture();
        static void Main(string[] args)
        {
            int flag = 1;
            Console.WriteLine("¡¡¡¡¡¡¡¡¡¡Bienvenido!!!!!!!!!!");
            SetTrip();
            SetLecture();
            lecture.LuminosityHours = new int[lecture.Hours];
            trip.Luminosity = SortDict(trip.Luminosity);
            foreach (var lumi in trip.Luminosity)
            {
                lecture.LuminosityHours[flag - 1] = lumi.Key;
                if (flag++ == lecture.Hours) break;
            }
            Console.WriteLine("\nNivel minimo de luz con el cual leerá: "
                + trip.Luminosity.Take(lecture.Hours).Min(key => key.Value));
            Console.WriteLine("Indice de horas a leer: ");
            Array.Sort(lecture.LuminosityHours);
            foreach (int lumi in lecture.LuminosityHours)
            {
                Console.Write("{0} ",lumi);
            }
            Console.WriteLine("\n>Presione Cualquier Tecla para terminar<");
            Console.ReadKey();
        }
        static void SetTrip()
        {
            int tripHours;
            Console.Write("\nIngrese la cantidad de horas que durará el viaje (1-1000): ");
            do
            {
                while (!Int32.TryParse(Console.ReadLine(), out tripHours))
                {
                    Console.Write("\nValor incorrecto, ingrese otro valor:");
                }
                if (tripHours < 1 || tripHours > 1000)
                {
                    Console.Write("\nValor incorrecto, ingrese otro valor:");
                }
            } while (tripHours < 1 || tripHours > 1000);
            trip.Hours = tripHours;
            trip.SetLuminosityValues();
        }
        static void SetLecture()
        {
            int lectureHours;
            Console.Write("\nIngrese la cantidad de horas que piensa leer en el viaje (1 - {0}): ", trip.Hours);
            do
            {
                while (!Int32.TryParse(Console.ReadLine(), out lectureHours))
                {
                    Console.Write("\nValor incorrecto, ingrese otro valor:");
                }
                if (lectureHours < 1 || !trip.EnoughHours(lectureHours))
                {
                    Console.Write("\nValor incorrecto, ingrese otro valor:");
                }
            } while (lectureHours < 1 || !trip.EnoughHours(lectureHours));
            lecture.Hours = lectureHours;
        }
        static Dictionary<int, int> SortDict(Dictionary<int, int> dict)
        {
            Dictionary<int, int> sorted = new Dictionary<int, int>();
            foreach (var item in dict.OrderByDescending(key => key.Value))
            {
                sorted.Add(item.Key,item.Value);
            }
            return sorted;
        }
    }
}
