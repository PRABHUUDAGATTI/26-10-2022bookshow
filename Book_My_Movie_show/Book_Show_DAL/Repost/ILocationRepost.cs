using Book_Show_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Show_DAL.Repost
{
    public interface ILocationRepost
    {
        void AddLocation(Location location);
        void UpdateLocation(Location location);
        void DeleteLocation(int LocationId);
        Location GetLocationById(int id);
        IEnumerable<Location> GetAll();
    }
}
