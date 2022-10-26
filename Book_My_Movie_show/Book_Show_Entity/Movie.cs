using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Book_Show_Entity
{
    public class Movie
    {
        [Key]//primary key is id
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//auto generate col
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieDesc { get; set; }
        public string MovieType { get; set; }
        public string MovieLanguage { get; set; }
        public byte[] ImgPoster { get; set; }
        /* public Movie(int movieId, string movieName, string movieDesc, string movieType)
         {
             MovieId = movieId;
             MovieName = movieName;
             MovieDesc = movieDesc;
             MovieType = movieType;
         }*/
    }
}
