using AutoszereloElszamolas;
using System.IO;



List<Szerelo> Szerelos = new List<Szerelo>();

foreach (string beolvasott in File.ReadAllLines("szerviz.txt"))
{
    string[] szetszed= beolvasott.Split(";");
    Szerelo aktualis = new Szerelo();
    aktualis.Nev = szetszed[0];
    aktualis.Javitottautok = int.Parse(szetszed[1]);
    aktualis.Munkaora = int.Parse(szetszed[2]);
    aktualis.GarancialisJavitasok = int.Parse(szetszed[3]);
    Szerelos.Add(aktualis);
}

int oraber = 0;
int darabber = 0;
int Teljesitmenybonusz = 0;
int Levonas = 0;
int napiber = 0;
int osszesitettMunkaber = 0;
int legnagyobbosszeg = 0;
string legjobbnev = "";

foreach (Szerelo aktualis in Szerelos)
{
    oraber = aktualis.Munkaora * 4000;
    darabber = aktualis.Javitottautok * 5000;
    if (aktualis.GarancialisJavitasok >= 2)
    {
        Levonas += 10000;
    }
    if (aktualis.Javitottautok >= 6 && aktualis.GarancialisJavitasok <=1)
    {
        Teljesitmenybonusz += 15000;
    }
    napiber = oraber + darabber + Teljesitmenybonusz - Levonas;
    osszesitettMunkaber += napiber;
    Console.WriteLine($"{aktualis.Nev}: {aktualis.Javitottautok} autó , {aktualis.Munkaora} óra (Garanciális javítások: {aktualis.GarancialisJavitasok}) - Munkabér: {napiber} Ft");
    if (napiber > legnagyobbosszeg)
    {
        legnagyobbosszeg = napiber;
        legjobbnev = aktualis.Nev;
    }
    napiber = 0;
    Levonas = 0;
    Teljesitmenybonusz = 0;
    darabber = 0;
    oraber = 0;
    
}

Console.WriteLine("A szerelők elszámolása:");
foreach (Szerelo szerelo in Szerelos)
{
}
Console.WriteLine("Összesített Statisztika:");
Console.WriteLine($"Szervíz általl kifizetett teljes munkabér: {osszesitettMunkaber} Ft");
Console.WriteLine($"Átlagos Munka Szerelőként: {Szerelos.Average(s => s.Munkaora):F0} Óra");
Console.WriteLine($"Legmagasabb napi bér: {legjobbnev} ({legnagyobbosszeg}) Ft");
Console.WriteLine($"Garanciális hiba nélkül dolgozó szerlők száma: {Szerelos.Count(s => s.GarancialisJavitasok == 0)} Fő");