using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Book_Show_Entity
{
    public class BookShow
    {
        [Key]//primary key is id
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//auto generate col
        public int BookShowId { get; set; }

        [ForeignKey("ShowTiming")]
        public int ShowTimingId { get; set; }
        public ShowTiming ShowTiming { get; set; }

        [ForeignKey("UserDetails")]
        public int UserId { get; set; }
        public UserDetails UserDetails { get; set; }
        
        public int NoOfTickets { get; set; }
        public double TicketCost { get; set; }
        /*public double TotalCost { get; set; }*/
        /*  public BookShow(int bookShowId, int showTimingId,  int userId,  int noOfTickets, double ticketCost)
          {
              BookShowId = bookShowId;
              ShowTimingId = showTimingId;
              //ShowTiming = showTiming;
              UserId = userId;
              //UserDetails = userDetails;
              NoOfTickets = noOfTickets;
              TicketCost = ticketCost;
          }*/
    }
}
