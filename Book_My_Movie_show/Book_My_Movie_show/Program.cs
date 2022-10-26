using Book_Show_Entity;
using System;

namespace Book_My_Movie_show
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------WELCOME TO BOOK MY MOVIE SHOW-------");
            Console.WriteLine("1) click 1 to movie");
            Console.WriteLine("2) clik 2 to Theater");
            Console.WriteLine("3) clik 3 to Timinhg");
            int m=Convert.ToInt32(Console.ReadLine());
            switch (m)
            {
                case 1:
                    MoviePL moviePL = new MoviePL();
                    moviePL.Menu();
                    break;
                    case 2:
                    TheaterPL theaterPL = new TheaterPL();
                    theaterPL.Menu();
                    break;
                case 3:
                    ShowTimingPL showTiming = new ShowTimingPL();
                    showTiming.Menu();
                    break;

            }

           
        }
    }
}
