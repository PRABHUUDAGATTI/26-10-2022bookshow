using Book_Show_Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Book_Show_DAL.Repost
{
    public class UserRepost : IUserRepost
    {
        Book_show_db _db;
        public UserRepost(Book_show_db db)
        {
            _db = db;
        }
        public void AddUserDetails(UserDetails userDetails)
        {
            _db.userDetails.Add(userDetails);
            _db.SaveChanges();
        }
        public void DeleteUserDetails(int UserDetailsId)
        {
            var UserId = _db.userDetails.Find(UserDetailsId);
            _db.userDetails.Remove(UserId);
            _db.SaveChanges();
        }
        public UserDetails GetUserDetailsById(int UserDetailsId)
        {
            return _db.userDetails.Find(UserDetailsId);
        }
        public IEnumerable<UserDetails> GetAll()
        {
            return _db.userDetails.ToList();
        }
        public void UpdateUserDetails(UserDetails userDetails)
        {
            _db.Entry(userDetails).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public int UserLogin(UserDetails userDetails)
        {
            List<UserDetails> users = _db.userDetails.ToList();

            foreach (var user in users)
            {
                if (user.UserEmail == userDetails.UserEmail && user.UserPhoneNo == userDetails.UserPhoneNo)
                {
                    return user.UserId;
                }
                

                /* UserDetails user1 = null;
                 var result = _db.user1.Where(obj => obj.UserEmail == userDetails.UserEmail && obj.UserPhoneNo == userDetails.UserPhoneNo).ToList();
                     if (result.Count > 0)
                     {
                     user1 = result[0];
                     }
                     return user1;*/
            }
            return 0;

        }
    }
}

