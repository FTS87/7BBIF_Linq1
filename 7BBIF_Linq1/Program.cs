using System;
using System.Linq;

namespace LinqInAction.LinqBooks.Common
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testergebnis

            var ergebnis =
            from b in SampleData.Books
            where b.Price > 0
            orderby b.Price descending
            select new { b.Isbn, b.Title, Preis2 = b.Price };

            Console.WriteLine("Testergebnis: \n ");
            ObjectDumper.Write(ergebnis);

            // Aufgabe 1

            var erg1 =
            from b in SampleData.Books
            where b.PageCount > 200
            orderby b.PageCount descending
            select new { b.Isbn, b.Title, AnzahlSeite = b.PageCount };

            Console.WriteLine("\n~~~~~~~~~~~~~~ Aufgabe 1 ~~~~~~~~~~~~~~ \n ");
            ObjectDumper.Write(erg1);

            // Aufgabe 2

            var dateAug = new DateTime(2007, 8, 1);
            
            var erg2 =
            from b in SampleData.Books
            where b.PublicationDate < dateAug
            orderby b.Title 
            select new { b.Isbn, b.PublicationDate, b.Title};

            Console.WriteLine("\n~~~~~~~~~~~~~~ Aufgabe 2 ~~~~~~~~~~~~~~ \n ");
            ObjectDumper.Write(erg2);

            // Aufgabe 3

            var erg3 =
            from b in SampleData.Books
            where b.Publisher.Name == "FunBooks"         
            select new { b.Isbn, b.Publisher.Name, b.Title};

            Console.WriteLine("\n~~~~~~~~~~~~~~ Aufgabe 3 ~~~~~~~~~~~~~~ \n ");
            ObjectDumper.Write(erg3);


            // Aufgabe 4

            var erg4 =
            from b in SampleData.Books            
            where b.Subject.Name == "Software development"
            select new { b.Subject.Description, b.Subject.Name, b.Title  };

            Console.WriteLine("\n~~~~~~~~~~~~~~ Aufgabe 4 ~~~~~~~~~~~~~~ \n ");
            ObjectDumper.Write(erg4);

            // Aufgabe 5

            var erg5 =
            from b in SampleData.Books                     
            select new { b.Publisher.Name, b.Publisher.WebSite, b.Title, b.Price, Subject_Name = b.Subject.Name };

            Console.WriteLine("\n~~~~~~~~~~~~~~ Aufgabe 5 ~~~~~~~~~~~~~~ \n ");
            ObjectDumper.Write(erg5);

            // Aufgabe 6

            var erg6 =
            from b in SampleData.Books
            from a in b.Authors
            select new { b.Title, b.PageCount, a.LastName, a.FirstName };

            Console.WriteLine("\n~~~~~~~~~~~~~~ Aufgabe 6 ~~~~~~~~~~~~~~ \n ");
            ObjectDumper.Write(erg6);

            // Aufgabe 7

            var erg7 =
            from b in SampleData.Books
            from a in b.Authors
            where a.FirstName.Equals("Octavio") && a.LastName.Equals("Prince")
            select new { b.Title, a.LastName, a.FirstName };

            Console.WriteLine("\n~~~~~~~~~~~~~~ Aufgabe 7 ~~~~~~~~~~~~~~ \n ");
            ObjectDumper.Write(erg7);

            // Aufgabe 8

            var erg8 =
            from b in SampleData.Books  
            from a in b.Authors
            where b.Authors.First().FirstName.Equals("Octavio") && b.Authors.First().LastName.Equals("Prince")
            select new { b.Title, a.LastName, a.FirstName };

            Console.WriteLine("\n~~~~~~~~~~~~~~ Aufgabe 8 ~~~~~~~~~~~~~~ \n ");
            ObjectDumper.Write(erg8);

            Console.ReadKey();
        }
    }
}
