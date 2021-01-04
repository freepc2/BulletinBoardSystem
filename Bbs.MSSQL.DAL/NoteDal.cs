using Bbs.IDAL;
using Bbs.Models;
using Bbs.MSSQL.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Bbs.MSSQL.DAL
{
    public class NoteDal : INoteDal
    {
        public Note GetNote(int No)
        {
            using (var db = new BbsDbContext())
            {
                var note = db.Notes.FirstOrDefault(x => x.No.Equals(No));
                return note;
            }
        }

        public List<Note> GetNoteList()
        {
            using (var db = new BbsDbContext())
            {
                var note = db.Notes.ToList();
                return note;
            }
        }

        public bool SetNote(Note note)
        {
            using (var db = new BbsDbContext())
            {
                db.Notes.Add(note);

                return (db.SaveChanges() > 0) ? true : false;
            }

        }
    }
}
