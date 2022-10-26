using Book_Show_DAL.Repost;
using Book_Show_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Show_BLL.Services
{
    public class UserServices
    {
        IUserRepost _UserDetailsRepost;

        public UserServices(IUserRepost UserRepost)
        {
            _UserDetailsRepost = UserRepost;
        }
        public void AddUserDetails(UserDetails userDetails)
        {
            _UserDetailsRepost.AddUserDetails(userDetails);
        }
        public void UpdateUserDetails(UserDetails userDetails)
        {
            _UserDetailsRepost.UpdateUserDetails(userDetails);
        }
        public void DeleteUserDetails(int Id)
        {
            _UserDetailsRepost.DeleteUserDetails(Id);
        }
        public UserDetails GeUserDetailsById(int id)
        {
            return _UserDetailsRepost.GetUserDetailsById(id);
        }
        public IEnumerable<UserDetails> GetAll()
        {
            return _UserDetailsRepost.GetAll();
        }
        public int UserLogin(UserDetails userDetails)
        {
            return _UserDetailsRepost.UserLogin(userDetails);
        }

    }
}
