using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace dz16
{
    internal class MyTask
    {
        public static void Run()
        {
            List<Poem> poems = new List<Poem>();
            Random rnd = new Random();
            for (int i = 0; i < 3; i++)
                poems = poems.Append(new Poem(rnd)).ToList();
            string input, secondInput;
            int choice;
            do
            {
                Console.WriteLine("Enter what to do(1 - add poem, 2 - remove poem, 3 - show poems, 4 - edit poem, 5 - find poem, 6 - save poems in file, 7 - get poems from file, 8 - make report:");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        poems = poems.Append(new Poem(rnd)).ToList();
                        break;
                    case 2:
                        Console.WriteLine("Enter the name of the poem to remove:");
                        input = Console.ReadLine();
                        poems.Remove(poems.Find(somePoem => somePoem.Name == input));
                        break;
                    case 3:
                        foreach (var poem in poems)
                        {
                            Console.WriteLine(poem);
                            Console.WriteLine("//////////////////////////////////");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter the name of the poem to edit:");
                        input = Console.ReadLine();
                        poems.Find(somePoem => somePoem.Name == input)?.Edit();
                        break;
                    case 5:
                        Console.WriteLine("Enter by what to search(name, author, year, theme):");
                        input = Console.ReadLine();
                        Console.WriteLine("Enter value to find:");
                        secondInput = Console.ReadLine();
                        List<Poem> result = new List<Poem>();
                        switch (input)
                        {
                            case "name":
                                result = poems.FindAll(somePoem => somePoem.Name == secondInput);
                                break;
                            case "author":
                                result = poems.FindAll(somePoem => somePoem.Author == secondInput);
                                break;
                            case "year":
                                result = poems.FindAll(somePoem => somePoem.CreationYear.ToString() == secondInput);
                                break;
                            case "theme":
                                result = poems.FindAll(somePoem => somePoem.Theme == secondInput);
                                break;
                        }
                        Console.WriteLine("Search result:");
                        foreach (var poem in result)
                        {
                            Console.WriteLine(poem);
                            Console.WriteLine("///////////////////////////////////");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Enter path to the file for saving:");
                        input = Console.ReadLine();
                        FileManager.SavePoems(poems, input);
                        break;
                    case 7:
                        Console.WriteLine("Enter path to the file for saving:");
                        input = Console.ReadLine();
                        poems = FileManager.ReadPoems(input);
                        break;
                    case 8:
                        ReportManager.MakeReport(poems);
                        break;
                }
            } while (choice != 0);
        }

        
    }
}