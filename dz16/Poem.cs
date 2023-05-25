using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dz16
{
    internal class Poem
    {
        public static string[] authors =
        {
            "Diane Ackerman",
            "David Aaron",
            "Simon Bacher",
            "Anne Bacon",
            "Bruce Campbell",
            "Ethan Canin",
            "Janet Dailey",
            "Bill Dare",
            "John Fenn",
            "Johann Hari",
            "Emma Parker",
            "Derek Landy"
        };
        public static string[] names =
        {
            "The Greatest Waste",
            "The Real Beauty",
            "What Hides Inside",
            "If",
            "Power",
            "The Reasons For Living",
            "The Root",
            "Original Cause",
            "Errata",
            "New Start",
            "Again",
            "The Return"
        };

        public static string[] themes =
        {
            "Death",
            "Love",
            "Nature",
            "Beauty",
            "Desire",
            "Aging",
            "Identity",
            "Religion"
        };

        public static char[] symbols =
        {
            'a',
            'b',
            'c',
            'd',
            'e',
            'f',
            'g',
            'h',
            'i',
            'j',
            'k',
            'l',
            'm',
            'n',
            'o',
            'p',
            'q',
            'r',
            's',
            't',
            'u',
            'v',
            'w',
            'x',
            'y',
            'z'
        };

        public string Name { get; set; }
        public string Author { get; set; }
        public int CreationYear { get; set; }
        public StringBuilder[] Text { get; set; }
        public string Theme { get; set; }

        public static StringBuilder[] GenText(Random rnd)
        {
            int num = rnd.Next(2, 10);
            StringBuilder[] text = new StringBuilder[num];
            for (int row = 0; row < text.Length; ++row)
            {
                num = rnd.Next(5, 20);
                text[row] = new StringBuilder("");
                for (int i = 0; i < num; ++i)
                {
                    text[row] = text[row].Append(symbols[rnd.Next(symbols.Length)]);
                    if(rnd.Next(10)<3)
                        text[row] = text[row].Append(' ');
                }
                if (rnd.Next(0, 2) == 0 && row != text.Length - 1)
                    text[row] = text[row].Append(',');
                else
                    text[row] = text[row].Append('.');
            }
            return text;
        }

        public Poem(Random rnd)
        {
            Name = names[rnd.Next(names.Length)];
            Author = authors[rnd.Next(authors.Length)];
            CreationYear = rnd.Next(1800, 2000);
            Text = GenText(rnd);
            Theme = themes[rnd.Next(themes.Length)];
        }
        public Poem(string name, string author, int creationYear, StringBuilder[] text, string theme)
        {
            Name = name;
            Author = author;
            CreationYear = creationYear;
            Text = text;
            Theme = theme;
        }
        public Poem() : this(new Random()) 
        { }

        public void Edit()
        {
            Console.Write("Enter what to edit(name, author, year, text, theme): ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "name":
                    Console.WriteLine("Enter new name:");
                    input = Console.ReadLine();
                    Name = input;
                    break;
                case "author":
                    Console.WriteLine("Enter new author:");
                    input = Console.ReadLine();
                    Author = input;
                    break;
                case "year":
                    Console.WriteLine("Enter new year of creation:");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out int year))
                        CreationYear = year;
                    break;
                case "theme":
                    Console.WriteLine("Enter new theme:");
                    input = Console.ReadLine();
                    Theme = input;
                    break;
                case "text":
                    Console.WriteLine("Enter new text(enter nothing to stop):");
                    StringBuilder[] text = new StringBuilder[0];
                    do
                    {
                        input = Console.ReadLine();
                        if (input == string.Empty)
                            break;
                        text = text.Append(new StringBuilder(input)).ToArray();
                    } while (true);
                    Text = text;
                    break;
            }            
        }

        public override string ToString()
        {
            string result = $"Name:\n{Name}\nAuthor:\n{Author}\nCreation year:\n{CreationYear}\nText:\n";
            foreach(var item in Text)
            {
                result += item + "\n";
            }
            return result + $"Theme:\n{Theme}";
        }
        public string ToShortString()
        {
            return $"Book info: Name: {Name}|Author: {Author}({CreationYear})";
        }
    }
}
