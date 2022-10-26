using Book_Show_DAL;
using Book_Show_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_My_Movie_show
{
    public class TheaterPL
    {
        public void AddTheater()
        {
            TheaterDAL theaterDAL = new TheaterDAL();
            Theater theater = new Theater();
            Console.WriteLine("enter a Theater name");
            theater.Name = Console.ReadLine();
            Console.WriteLine("enter a Theater adress");
            theater.Adress = Console.ReadLine();
            Console.WriteLine("enter a Theater comments");
            theater.Comment = Console.ReadLine();
            string msg = theaterDAL.AddTheater(theater);
            if(msg != null)
            {
                Console.WriteLine("Theater added succesfully", Console.ForegroundColor = ConsoleColor.Cyan);
            }

            Menu();
        }
        public void ShowAllTheater()
        {
            TheaterDAL movieOperations = new TheaterDAL();
            List<Theater> theater = movieOperations.showAllTheater();
            foreach (var item in theater)
            {
                Console.Write("Theater id : " + item.Id);
                Console.Write("     Theater name : " + item.Name);
                Console.Write("     Theater adress : " + item.Adress);
                Console.WriteLine("     Theater comments : " + item.Comment);

            }
            Menu();
        }
        public void DeleteTheater()
        {
            Console.WriteLine("Enter Theater Id:");
            int TheaterId = Convert.ToInt32(Console.ReadLine());
            TheaterDAL TheaterOperations = new TheaterDAL();
            Console.WriteLine(TheaterOperations.RemoveTheater(TheaterId));
            Menu();


        }
        public void Menu()
        {
            Console.WriteLine("-------welcom to movie section-------- ",Console.ForegroundColor=ConsoleColor.Cyan);
            Console.WriteLine("1 add ", Console.ForegroundColor = ConsoleColor.White);
            Console.WriteLine("2 showall ");
            Console.WriteLine("3 delete");
            Console.WriteLine("4 update ");
            Console.WriteLine("5 Search ");
            int MovieId = Convert.ToInt32(Console.ReadLine());
            switch (MovieId)
            {
                case 1:
                    AddTheater();
                    break;
                case 2:
                    ShowAllTheater();
                    break;
                case 3:
                    DeleteTheater();
                    break;
                case 4:
                    UpadteTheater();
                    break;
              
            }
        }
        public void UpadteTheater()
        {
            TheaterDAL movieOperations = new TheaterDAL();
            Theater theater = new Theater();
            Console.WriteLine("enter a Theater id");
            theater.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter a Theater name");
            theater.Name = Console.ReadLine();
            Console.WriteLine("enter a theater adress");
            theater.Adress = Console.ReadLine();
            Console.WriteLine("enter a some comments");
            theater.Comment = Console.ReadLine();
            Console.WriteLine(movieOperations.UpadteTheater(theater));

            Menu();
        }
    }
}
