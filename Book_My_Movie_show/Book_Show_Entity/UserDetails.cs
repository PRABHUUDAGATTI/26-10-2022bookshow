using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Book_Show_Entity
{
    public class UserDetails
    {
        [Key]//primary key is id
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//auto generate col
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public double UserPhoneNo { get; set; }

       /* public string Role { get; set; }*/
      /*  public UserDetails(int userId, string userName, string userEmail, string userPhoneNo)
        {
            UserId = userId;
            UserName = userName;
            UserEmail = userEmail;
            UserPhoneNo = userPhoneNo;
        }*/
    }
}
