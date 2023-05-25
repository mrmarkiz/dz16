using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz16
{
    internal class ReportManager
    {
        public static void MakeReport(List<Poem> poems)
        {
            Console.WriteLine("Enter feature to make report by(name, author, year, length, theme)");
            string input = Console.ReadLine();
            switch (input)
            {
                case "name":
                    MakeReportByName(poems);
                    break;
                case "author":
                    MakeReportByAuthor(poems);
                    break;
                case "year":
                    MakeReportByYear(poems);
                    break;
                case "length":
                    MakeReportByLength(poems);
                    break;
                case "theme":
                    MakeReportByTheme(poems);
                    break;
            }
        }

        public static void MakeReportByName(List<Poem> poems)
        {
            string[] names = new string[0];
            foreach (var poem in poems)
            {
                names = names.Append(poem.Name).ToArray();
            }
            names = names.Distinct().ToArray();
            using (FileStream fs = new FileStream("report_by_name.txt", FileMode.OpenOrCreate)) ;
            using (FileStream fs = new FileStream("report_by_name.txt", FileMode.Truncate))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    for (int i = 0; i < names.Length; i++)
                    {
                        sw.WriteLine($"Name: {names[i]}:");
                        foreach (var poem in poems)
                        {
                            if (poem.Name == names[i])
                                sw.WriteLine(poem.ToShortString());
                        }
                        sw.WriteLine();
                    }
                }
            }
        }

        public static void MakeReportByAuthor(List<Poem> poems)
        {
            string[] authors = new string[0];
            foreach (var poem in poems)
            {
                authors = authors.Append(poem.Author).ToArray();
            }
            authors = authors.Distinct().ToArray();
            using (FileStream fs = new FileStream("report_by_author.txt", FileMode.OpenOrCreate)) ;
            using (FileStream fs = new FileStream("report_by_author.txt", FileMode.Truncate))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    for (int i = 0; i < authors.Length; i++)
                    {
                        sw.WriteLine($"Author: {authors[i]}:");
                        foreach (var poem in poems)
                        {
                            if (poem.Author == authors[i])
                                sw.WriteLine(poem.ToShortString());
                        }
                        sw.WriteLine();
                    }
                }
            }
        }

        public static void MakeReportByYear(List<Poem> poems)
        {
            int[] years = new int[0];
            foreach (var poem in poems)
            {
                years = years.Append(poem.CreationYear).ToArray();
            }
            years = years.Distinct().ToArray();
            using (FileStream fs = new FileStream("report_by_year.txt", FileMode.OpenOrCreate)) ;
            using (FileStream fs = new FileStream("report_by_year.txt", FileMode.Truncate))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    for (int i = 0; i < years.Length; i++)
                    {
                        sw.WriteLine($"Year: {years[i]}:");
                        foreach (var poem in poems)
                        {
                            if (poem.CreationYear == years[i])
                                sw.WriteLine(poem.ToShortString());
                        }
                        sw.WriteLine();
                    }
                }
            }
        }

        public static void MakeReportByLength(List<Poem> poems)
        {
            int[] lengths = new int[0];
            foreach (var poem in poems)
            {
                lengths = lengths.Append(poem.Text.Length).ToArray();
            }
            lengths = lengths.Distinct().ToArray();
            using (FileStream fs = new FileStream("report_by_texts_lengths.txt", FileMode.OpenOrCreate)) ;
            using (FileStream fs = new FileStream("report_by_texts_lengths.txt", FileMode.Truncate))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    for (int i = 0; i < lengths.Length; i++)
                    {
                        sw.WriteLine($"Length: {lengths[i]}:");
                        foreach (var poem in poems)
                        {
                            if (poem.Text.Length == lengths[i])
                                sw.WriteLine(poem.ToShortString());
                        }
                        sw.WriteLine();
                    }
                }
            }
        }

        public static void MakeReportByTheme(List<Poem> poems)
        {
            string[] themes = new string[0];
            foreach (var poem in poems)
            {
                themes = themes.Append(poem.Theme).ToArray();
            }
            themes = themes.Distinct().ToArray();
            using (FileStream fs = new FileStream("report_by_themes.txt", FileMode.OpenOrCreate)) ;
            using (FileStream fs = new FileStream("report_by_themes.txt", FileMode.Truncate))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    for (int i = 0; i < themes.Length; i++)
                    {
                        sw.WriteLine($"Theme: {themes[i]}:");
                        foreach (var poem in poems)
                        {
                            if (poem.Theme == themes[i])
                                sw.WriteLine(poem.ToShortString());
                        }
                        sw.WriteLine();
                    }
                }
            }
        }
    }
}
