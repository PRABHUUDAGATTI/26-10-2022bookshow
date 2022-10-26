using Book_Show_Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Book_Show_DAL.Repost
{
    public class LocationRepost:ILocationRepost
    {
        Book_show_db _db;
        public LocationRepost(Book_show_db db)
        {
            _db = db;
        }
        public void AddLocation(Location location)
        {
            _db.location.Add(location);
            _db.SaveChanges();
        }
        public void DeleteLocation(int LocationId)
        {
            var Location = _db.location.Find(LocationId);
            _db.location.Remove(Location);
            _db.SaveChanges();
        }
        public Location GetLocationById(int LocationId)
        {
            return _db.location.Find(LocationId);
        }
        public IEnumerable<Location> GetAll()
        {
            return _db.location.ToList();
        }
        public void UpdateLocation(Location location)
        {
            _db.Entry(location).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
