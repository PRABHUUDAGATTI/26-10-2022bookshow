using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Book_Show_Entity
{
    public class Location
    {
        [Key]//primary key is id
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//auto generate col
        public int LocationId { get; set; }
        public string LocationDesc { get; set; }
     /*public Location(int locationId, string locationDesc)
        {
            LocationId = locationId;
            LocationDesc = locationDesc;
        }*/
    }
}
