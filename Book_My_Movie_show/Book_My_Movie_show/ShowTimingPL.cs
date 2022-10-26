using Book_Show_DAL;
using Book_Show_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_My_Movie_show
{
    public class ShowTimingPL
    {
        public void AddShowTiming()
        {
            ShowTimingsDAL theaterDAL = new ShowTimingsDAL();
            ShowTiming showTiming = new ShowTiming();
            Console.WriteLine("enter a Theater id");
            showTiming.TheatreId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter a Movie Id");
            showTiming.MovieId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter a date time");
            showTiming.ShowTime = Convert.ToDateTime(Console.ReadLine());
            string msg = theaterDAL.AddShowTiming(showTiming);
            if (msg != null)
            {
                Console.WriteLine("ShowTiming added succesfully", Console.ForegroundColor = ConsoleColor.Cyan);
            }

            Menu();
        }
        public void ShowAllShowTiming()
        {
            ShowTimingsDAL movieOperations = new ShowTimingsDAL();
            List<ShowTiming> showTiming = movieOperations.showAllShowTiming();
            foreach (var item in showTiming)
            {
                Console.Write("ShowTiming id : " + item.Id);
                Console.Write("     MovieId name : " + item.MovieId);
                Console.Write("     ShowTime adress : " + item.ShowTime);
                Console.WriteLine("     TheatreId : " + item.TheatreId);

            }
            Menu();
        }
        public void DeleteShowTiming()
        {
            Console.WriteLine("Enter ShowTiming Id:");
            int ShowTimingId = Convert.ToInt32(Console.ReadLine());
            ShowTimingsDAL ShowTimingOperations = new ShowTimingsDAL();
            Console.WriteLine(ShowTimingOperations.RemoveShowTiming(ShowTimingId));
            Menu();


        }
        public void Menu()
        {
            Console.WriteLine("-------welcom to ShowTiming section-------- ", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.WriteLine("1 add ", Console.ForegroundColor = ConsoleColor.White);
            Console.WriteLine("2 showall ");
            Console.WriteLine("3 delete");
            Console.WriteLine("4 update ");
            Console.WriteLine("5 Search ");
            int MovieId = Convert.ToInt32(Console.ReadLine());
            switch (MovieId)
            {
                case 1:
                    AddShowTiming();
                    break;
                case 2:
                    ShowAllShowTiming();
                    break;
                case 3:
                    DeleteShowTiming();
                    break;
                case 4:
                    UpadteShowTiming();
                    break;

            }
        }
        public void UpadteShowTiming()
        {
            ShowTimingsDAL movieOperations = new ShowTimingsDAL();
            ShowTiming showTiming = new ShowTiming();
            Console.WriteLine("enter a ShowTiming id");
            showTiming.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter a ShowTime");
            showTiming.ShowTime = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("enter a TheatreId");
            showTiming.TheatreId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter a MovieId");
            showTiming.MovieId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(movieOperations.UpadteShowTiming(showTiming));

            Menu();
        }
    }
}
