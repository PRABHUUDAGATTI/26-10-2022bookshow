using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Book_Show_Entity
{
    public class ShowTiming
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShowTimingId { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [ForeignKey("Theater")]
        public int TheatreId { get; set; }

        public Theater Theater { get; set; }
        public DateTime ShowTime { get; set; }
    /*    public ShowTiming(int showTimingId, int movieId, *//*Movie movie*//* int theatreId, *//*Theater theater,*//* DateTime showTime)
        {
            ShowTimingId = showTimingId;
            MovieId = movieId;
           // Movie = movie;
            TheatreId = theatreId;
            //Theater = theater;
            ShowTime = showTime;
        }*/
    }
}
