using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.CodeDom.Compiler;
using System.Net.Http.Headers;

/**
 * Name: Aaron Audet
 * Student Number: 000367464
 * File Date: October 23, 2020
 * Program purpose: The purpose of this program is to display a list of media items based on the user option
 * Statement of Authorship: I, Aaron Audet, 000367464 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
 */

namespace Lab3A
{
    class Program
    {
        /// <summary>
        /// Creates the menu and handles creating the lists
        /// </summary>
        /// <param name="args">Not Used</param>
        static void Main(string[] args)
        {
            Media[] media = ReadData();
            string choice;
            bool exit = false;

            do
            {
                // Create menu
                Console.Clear();
                Console.WriteLine("Aaron's Media Collection:");
                Console.WriteLine("1. List All Books");
                Console.WriteLine("2. List All Movies");
                Console.WriteLine("3. List All Songs");
                Console.WriteLine("4. List All Media");
                Console.WriteLine("5. Search All Media by Title\n");
                Console.WriteLine("6. Exit Program\n");

                Console.Write("Enter choice: ");
                choice = Console.ReadLine().ToLower();

                // Filter input
                if (int.TryParse(choice, out int num))
                {
                    switch(num)
                    {
                        case 1: // List all books
                            var bookOnly = from item in media
                                           where item != null && item.GetType() == typeof(Book)
                                           select item;

                            Console.WriteLine();
                            foreach(var item in bookOnly)
                            {
                                Console.Write(item.ToString());
                                Console.WriteLine("\n--------------------");
                            }
                            break;
                        case 2: // List all movies
                            var movieOnly = from item in media
                                           where item != null && item.GetType() == typeof(Movie)
                                           select item;

                            Console.WriteLine();
                            foreach (var item in movieOnly)
                            {
                                Console.Write(item.ToString());
                                Console.WriteLine("\n--------------------");
                            }
                            break;
                        case 3: // List all songs
                            var songOnly = from item in media
                                           where item != null && item.GetType() == typeof(Song)
                                           select item;

                            Console.WriteLine();
                            foreach (var item in songOnly)
                            {
                                Console.Write(item.ToString());
                                Console.WriteLine("\n--------------------");
                            }
                            break;
                        case 4: // List all media
                            var allMedia = from item in media
                                           where item != null
                                           select item;

                            Console.WriteLine();
                            foreach (var item in allMedia)
                            {
                                Console.Write(item.ToString());
                                Console.WriteLine("\n--------------------");
                            }
                            break;
                        case 5: // List all media based on search
                            Console.Write("\nEnter a search string: ");
                            string search = Console.ReadLine();
                            Console.WriteLine();
                            var searchTitle = from item in media
                                              where item != null && item.Search(search)
                                              select item;
                            foreach(var item in searchTitle)
                            {
                                // Depending on type output result
                                if (item.GetType() == typeof(Book))
                                {
                                    Book book = (Book)item;
                                    Console.Write($"{item}\n\n{book.Decrypt()}\n--------------------\n");
                                } else if(item.GetType() == typeof(Movie))
                                {
                                    Movie movie = (Movie)item;
                                    Console.Write($"{item}\n\n{movie.Decrypt()}\n--------------------\n");
                                } else
                                {
                                    Console.Write($"{item}\n--------------------\n");
                                }
                            }
                            break;
                        case 6: // Exit
                            exit = true;
                            break;
                        default: // Out of bounds
                            Console.WriteLine("\n*** Invalid Choice - Try Again ***\n");
                            Console.Write("Press any key to continue . . .");
                            Console.ReadKey();
                            break;
                    }
                    Console.Write("\nPress any key to continue . . .");
                    Console.ReadKey();
                } else // Not a number
                {
                    Console.WriteLine("\n*** Invalid Choice - Try Again ***\n");
                    Console.Write("Press any key to continue . . .");
                    Console.ReadKey();
                }
            } while (!exit);
        }

        /// <summary>
        /// Will read the data from the Data.txt file and sort it into the appropriate classes
        /// </summary>
        /// <returns>Media array of lenght 100</returns>
        public static Media[] ReadData()
        {
            // Create requiered variables
            FileStream file = new FileStream("Data.txt", FileMode.Open);
            StreamReader data = new StreamReader(file);
            Media[] media = new Media[100];
            int itemCount = 0;
            string[] info = new string[5];
            string summary = "";

            // Get data and store it
            while (data.Peek() >= 0)
            {
                string temp = data.ReadLine();
                if (temp.Contains("BOOK") || temp.Contains("SONG") || temp.Contains("MOVIE"))
                {
                    info = temp.Split('|');
                } else
                {
                    if(temp.Contains("-----"))
                    {
                        // Add Entry
                        if(info[0].Equals("BOOK"))
                        {
                            media[itemCount] = new Book(info[1], int.Parse(info[2]), info[3], summary);
                        } else if(info[0].Equals("MOVIE"))
                        {
                            media[itemCount] = new Movie(info[1], int.Parse(info[2]), info[3], summary);
                        } else if(info[0].Equals("SONG"))
                        {
                            media[itemCount] = new Song(info[1], int.Parse(info[2]), info[3], info[4]);
                        }
                        
                        // Reset, Update Data
                        itemCount++;
                        summary = "";
                        for(int i = 0; i < info.Length; i++)
                        {
                            info[i] = "";
                        }
                    } else
                    {
                        summary += temp;
                    }
                }
            }

            // Closing file to prevent futur errors
            data.Close();
            file.Close();
            return media;
        }
    }
}
