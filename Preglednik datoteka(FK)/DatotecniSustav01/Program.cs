using System;
using System.Diagnostics;
using System.IO;

namespace DatotecniSustav01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_________________________________________________________________\n      Ispisivanje svih prisutnih diskova na računalu    ");
            DriveInfo[] diskovi = DriveInfo.GetDrives();
            try
            {
                foreach (DriveInfo d in diskovi)
                {
                    if (d.IsReady == true)      // provjeravamo ako je disk spreman za koristenje
                    {
                        Console.WriteLine("Disk {0} ukupno {1}GB(slobodno {2}GB, zauzeto {4}GB); Format: {3}  ", d.Name, d.TotalSize / (1024 * 1024 * 1024), d.AvailableFreeSpace / (1024 * 1024 * 1024), d.DriveFormat, (d.TotalSize - d.AvailableFreeSpace) / (1024 * 1024 * 1024));
                    }
                }
            }
            catch (IOException e)       // za dohvat moguce greske
            {
                Console.WriteLine("Greška u dohvatu diska: {0}", e);
            }
            Console.WriteLine("_________________________________________________________________");

            Console.WriteLine("Unesi direktorij koji zeliš pregledat: ");
            string direktorij = Console.ReadLine();
            DirectoryInfo dirInfo = new DirectoryInfo(direktorij);

            var datoteke = dirInfo.GetFiles();
            long velicina = 0;

            Console.WriteLine("+------------------+-------------+---------+------------------------------------------+");
            Console.WriteLine("| Veličina       B |          KB |      MB | Imena datoteka                           |");
            Console.WriteLine("+------------------+-------------+---------+------------------------------------------+");
            foreach (FileInfo d in datoteke)
            {
                velicina += d.Length;
                Console.WriteLine("|{0, 10} B | {1, 10} KB | {2, 10} MB | {3,10} |",
                    d.Length,
                    d.Length / 1024,
                    d.Length / (1024 * 1024),
                    d.FullName);
            }
            Console.WriteLine("+------------------+-------------+---------+------------------------------------------+");
            Console.WriteLine("|{0, 10} B | {1, 10} KB | {2, 10} MB |                                       |",
                velicina,
                velicina / 1024,
                velicina / (1024 * 1024));
            Console.WriteLine("+------------------+-------------+---------+------------------------------------------+");

            Console.SetCursorPosition(1, 3);
            Console.Write(">");
            int brojRedova = datoteke.Length + 6;

            int cekanjeTreperenje = 500;
            Console.CursorVisible = false;
            int pokazivacY = 3;
            while (true)
            {
                System.Threading.Thread.Sleep(cekanjeTreperenje);
                Console.SetCursorPosition(1, pokazivacY);
                System.Threading.Thread.Sleep(cekanjeTreperenje);
                Console.SetCursorPosition(1, pokazivacY);
                Console.Write(">");

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pritisnutaTipka = Console.ReadKey(true);
                    if (pritisnutaTipka.Key == ConsoleKey.DownArrow)
                    {
                        Console.SetCursorPosition(1, pokazivacY);
                        Console.WriteLine(" ");
                        pokazivacY++;
                    }
                }
            }

        }
    }
}