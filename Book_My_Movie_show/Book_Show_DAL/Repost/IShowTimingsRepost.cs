using Book_Show_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Show_DAL.Repost
{
    public interface IShowTimingsRepost
    {
        void AddShowTiming(ShowTiming ShowTiming);
        void UpdateShowTiming(ShowTiming ShowTiming);
        void DeleteShowTiming(int ShowTimingId);
        ShowTiming GetShowTimingById(int id);
        IEnumerable<ShowTiming> GetAll();

        ShowTiming LastOne();
    }
}
