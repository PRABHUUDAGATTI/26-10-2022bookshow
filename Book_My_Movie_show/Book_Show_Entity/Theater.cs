using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Book_Show_Entity
{
    public class Theater
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TheatreId { get; set; }
        public string Name { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        public Location Location { get; set; }
        public string Comment { get; set; }
      /*  public Theater(int theatreId, string name, int locationId, *//*Location location*//* string comment)
        {
            TheatreId = theatreId;
            Name = name;
            LocationId = locationId;
           // Location = location;
            Comment = comment;
        }
        public Theater()
        {

        }*/
    }
}
