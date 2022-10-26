using Book_Show_DAL.Repost;
using Book_Show_Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Show_BLL.Services
{
    public class LocationServices
    {
        ILocationRepost _LocationRepost;

        public LocationServices(ILocationRepost LocationRepost)
        {
            _LocationRepost = LocationRepost;
        }
        public void AddLocation(Location location)
        {
            _LocationRepost.AddLocation(location);
        }
        public void UpdateLocation(Location location)
        {
            _LocationRepost.UpdateLocation(location);
        }
        public void DeleteLocation(int Id)
        {
            _LocationRepost.DeleteLocation(Id);
        }
        public  Location GeLocationById(int id)
        {
            return _LocationRepost.GetLocationById(id);
        }
        public IEnumerable<Location> GetAll()
        {
            return _LocationRepost.GetAll();
        }
    }
}
