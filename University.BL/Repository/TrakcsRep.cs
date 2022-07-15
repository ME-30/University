using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Interface;
using University.DAL.DataBase;
using University.DAL.Entity;

namespace University.BL.Repository
{
    public class TracksRep : ITracksRep
    {
        private readonly UniversityContext db;

        public TracksRep(UniversityContext db)
        {
            this.db = db;
        }
        public IEnumerable<Tracks> GetAll()
        {
            var data = GetTrack();

            return data ;
        }

        public Tracks GetById(int id)
        {
            var data = db.Tracks.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }

        // ============================= Refactor ============================
        private IEnumerable<Tracks> GetTrack()
        {
            return db.Tracks.Select(a => a);
        }
    }
}
