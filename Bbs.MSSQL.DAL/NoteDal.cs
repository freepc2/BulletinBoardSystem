using Bbs.IDAL;
using Bbs.Models;
using Bbs.MSSQL.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
                // DB에서 연동하고 List 출력
                var note = db.Notes.Include(x => x.User).ToList();                
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
