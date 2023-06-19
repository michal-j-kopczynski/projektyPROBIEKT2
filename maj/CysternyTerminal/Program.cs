using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CysternyTerminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            CysternyF.Zadanie.pozbieraj_klasy(); //statycznie!
            System.IO.StreamReader tr = new System.IO.StreamReader("dane.TXT");
            string string_temp = tr.ReadLine();
            int how_many_tasks = Convert.ToInt32(string_temp);
            for(int i = 0; i < how_many_tasks; i++)
            {
                CysternyF.Zadanie zadanie1 = new CysternyF.Zadanie();
                zadanie1.wczytaj(tr);
                double temp_rezultat = zadanie1.rozwiaz();
                Console.WriteLine($"X m^3 to: { Math.Round(temp_rezultat, 2)} metrowy poziom");
            }
            
            /*
            wczytaj ilosc zadan - 1 liczba/linijka
            while(3 razy działaj)
            {
            CysternyF.Zadanie zadanie1 = new CysternyF.Zadanie();
            zadanie1.wczytaj() //wczytaj tworzy kolekcje (np liste) przypisana do obiektu
            // zadanie1 - w liscie sa wszystkie obiekty typu (figura.jakas_figura z odpowiednio ustawionymi polami)
            zadanie1.rozwiąż()
            //pokaz_zadanie_w_konsoli(zadanie1);
            }
             
             */



            
            
            
        }
      
    }

}
