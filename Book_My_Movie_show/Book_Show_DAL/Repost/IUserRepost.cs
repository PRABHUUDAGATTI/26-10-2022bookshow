using Book_Show_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Show_DAL.Repost
{
    public interface IUserRepost
    {
        void AddUserDetails(UserDetails userDetails);
        void UpdateUserDetails(UserDetails userDetails);
        void DeleteUserDetails(int UserDetailsId);
        UserDetails GetUserDetailsById(int id);
        IEnumerable<UserDetails> GetAll();

        int UserLogin(UserDetails userDetails);
    }
}
