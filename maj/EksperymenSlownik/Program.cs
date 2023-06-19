using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;



public interface Iodpowiedni_typ_sl
{
    void Ustaw(int val1);
}


public class KlasaD: Iodpowiedni_typ_sl 
{
    
    private int liczba_do_hash;
    
    public void Ustaw(int val1)
    {
        this.liczba_do_hash = val1;
    }

    public override bool Equals(object obj)
    {
        return obj is KlasaD other2 && liczba_do_hash == other2.liczba_do_hash;
        
    }
    public override int GetHashCode()
    {

        return liczba_do_hash;//% 100;
 
    }

   
}

public class KlasaZ : Iodpowiedni_typ_sl
{
    
    private int liczba_do_hash;
   
    public void Ustaw(int val1)
    {
        this.liczba_do_hash = val1;
    }

    public override bool Equals(object obj)
    {
        return obj is KlasaZ other2 && liczba_do_hash == other2.liczba_do_hash;

    }
    public override int GetHashCode()
    {
        return liczba_do_hash%2;

    }

   
}

public class KlasaBezHash : Iodpowiedni_typ_sl
{

    private int liczba_do_hash;

    public void Ustaw(int val1)
    {
        this.liczba_do_hash = val1;
    }
    
    /*
      public override bool Equals(object obj)
    {
        return obj is KlasaBezHash other2 && liczba_do_hash == other2.liczba_do_hash;

    }
    */
     




}


public struct StructD : Iodpowiedni_typ_sl
{
    private int liczba_do_hash;

    public void Ustaw(int val1)
    {
        this.liczba_do_hash = val1;
    }

    public override bool Equals(object obj)
    {
        if (obj is StructD other)
        {
            return liczba_do_hash == other.liczba_do_hash;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return liczba_do_hash % 100;
    }
}

public struct StructZ : Iodpowiedni_typ_sl
{
    private int liczba_do_hash;

    public void Ustaw(int val1)
    {
        this.liczba_do_hash = val1;
    }

    public override bool Equals(object obj)
    {
        if (obj is StructZ other)
        {
            return liczba_do_hash == other.liczba_do_hash;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return liczba_do_hash%2;
    }
}

public struct StructBezHash : Iodpowiedni_typ_sl
{
    private int liczba_do_hash;

    public void Ustaw(int val1)
    {
        this.liczba_do_hash = val1;
    }

    
}
public class ProgramSlownik
{

    static public void Test<T>() where T : Iodpowiedni_typ_sl, new()
    {
        Dictionary<T, int> dict = new Dictionary<T, int>();
        DateTime czas_start = DateTime.Now;

        Random random = new Random(13);
        int ilosc_dodanych_el = 20000;

        
        for (int i=0;i< ilosc_dodanych_el; i++)
        {
            T x = new T();
            x.Ustaw(i);
            dict[x] = i+1;

            
        }

        TimeSpan czas_koniec = DateTime.Now - czas_start;
        Console.WriteLine("Czas dodawania elementów do słownika: " + czas_koniec.ToString());

        
        int temp_int, counter = 0;
        czas_start = DateTime.Now;
        T y = new T();
        int ilość_wyszukań = 50000;
        for (int i = 0; i < ilość_wyszukań; i++)
        {
            y.Ustaw(random.Next(0, ilosc_dodanych_el));
            if (!dict.TryGetValue(y, out temp_int))
            {
                counter++;
            }
            

        }
        czas_koniec = DateTime.Now - czas_start;
        Console.WriteLine("Czas szukania elementów w słowniku: " + czas_koniec.ToString());
        Console.WriteLine("Ilosć nie znalezionych elementów mimo istniejących obiektów o szukanych polach: " + counter);

        T z = new T();
        z.Ustaw(500);
        y.Ustaw(500);
        Console.WriteLine("Czy dwa obiekty o takiej samej wartości pól są sobie równe? "+ y.Equals(z));
        Console.WriteLine("Czy dwa obiekty o takiej samej referencji są sobie równe? " + y.Equals(y));
    }


  
    public static void Main()
    {
        Console.WriteLine("Dobry GetHashCode() dla klas:");
        Test<KlasaD>();
        Console.WriteLine("\n\nZły GetHashCode() dla klas:");
        Test<KlasaZ>();
        Console.WriteLine("\n\nBrak GetHashCode() dla klas");
        Test<KlasaBezHash>();

        Console.WriteLine("\n\nDobry GetHashCode() dla struktur:");
        Test<StructD>();
        Console.WriteLine("\n\nZły GetHashCode() dla struktur:");
        Test<StructZ>();
        Console.WriteLine("\n\nBrak GetHashCode() dla struktur");
        Test<StructBezHash>();

    }
}
