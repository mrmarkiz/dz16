using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dz16
{
    internal class FileManager
    {
        public static void SavePoems(List<Poem> poems, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate)) ;
            using (FileStream fs = new FileStream(path, FileMode.Truncate))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var poem in poems)
                    {
                        sw.WriteLine(poem.ToString());
                        sw.WriteLine("//////////////////////////////////");
                    }
                }
            }
        }

        public static List<Poem> ReadPoems(string path)
        {
            List<Poem>result = new List<Poem>();
            string name, author, year, theme;
            StringBuilder[] poemText = new StringBuilder[0];
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string[] text = sr.ReadToEnd().Split("//////////////////////////////////\r\n");
                        string[] poem;
                        text = Array.FindAll(text, line => line != string.Empty);
                        foreach (string t in text)
                        {
                            poem = t.Split("\n");
                            poem = Array.FindAll(poem, line => line != string.Empty);
                            name = poem[1];
                            author = poem[3];
                            year = poem[5];
                            theme = poem[poem.Length - 1];
                            for (int i = 7; i < poem.Length - 2; i++)
                                poemText = poemText.Append(new StringBuilder(poem[i])).ToArray();
                            result = result.Append(new Poem(name, author, int.Parse(year), poemText, theme)).ToList();
                        }

                    }
                }


            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occured: {e.Message}");
                return new List<Poem>();
            }
            return result;
        }
    }
}
