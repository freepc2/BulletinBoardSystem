using Bbs.IDAL;
using Bbs.Models;
using Bbs.MSSQL.DAL.DataContext;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bbs.MSSQL.DAL
{
    public class NoteDal : INoteDal
    {
        private readonly IConfiguration _configuration;
        public NoteDal(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Note GetNote(int No)
        {
            using(var db = new BbsDbContext(_configuration))
            {
                var note = db.Notes.FirstOrDefault(x => x.No == No);
                return note;
            }
        }
        public Note GetNoteAndUpdateView(int No)
        {
            using (var db = new BbsDbContext(_configuration))
            {
                var note = db.Notes.FirstOrDefault(x => x.No == No);
                note.Views++;
                db.Notes.Update(note);
                return db.SaveChanges()>0 ? note: null;
            }
        }

        public List<Note> GetNoteList()
        {
            using (var db = new BbsDbContext(_configuration))
            {
                // DB에서 연동하고 List 출력
                return db.Notes.Include(x => x.User)
                    .OrderByDescending(n => n.No)
                    .ToList();
            }
        }
        public List<Note> GetNoteList(int ListNo)
        {
            using (var db = new BbsDbContext(_configuration))
            {
                // DB에서 연동하고 List 출력
                return db.Notes.Include(x => x.User)
                    .Where(x=>x.Available == true)
                    .OrderByDescending(n => n.No)
                    .Skip(ListNo * 10)
                    .Take(10)
                    .ToList();
            }
        }
        public bool PostNote(Note note)
        {
            using (var db = new BbsDbContext(_configuration))
            {
                db.Notes.Add(note);          
                return (db.SaveChanges() > 0) ? true : false;
            }
        }

        public bool UpdateNote(Note note)
        {
            using (var db = new BbsDbContext(_configuration))
            {
                db.Notes.Update(note);
                return (db.SaveChanges() > 0) ? true : false;
            }
        }

        public bool UpdateViewNote(Note note)
        {
            using(var db = new BbsDbContext(_configuration))
            {
                note.Views++;
                db.Notes.Update(note);
                return (db.SaveChanges() > 0) ? true : false;
            }
        }


        public bool DeleteNote(int No)
        {
            using (var db = new BbsDbContext(_configuration))
            {
                var note = db.Notes.FirstOrDefault(x => x.No.Equals(No));
                note.Available = false;
                db.Notes.Update(note);
                return (db.SaveChanges() > 0) ? true : false;
            }
        }

        public bool DeleteNote(Note note)
        {
            using (var db = new BbsDbContext(_configuration))
            {
                note.Available = false;
                db.Notes.Update(note);
                return (db.SaveChanges() > 0) ? true : false;
            }
        }


    }
}
