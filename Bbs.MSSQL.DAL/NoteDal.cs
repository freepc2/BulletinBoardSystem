using Bbs.IDAL;
using Bbs.Models;
using Bbs.MSSQL.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bbs.MSSQL.DAL
{
    public class NoteDal : INoteDal
    {
        private readonly IConfiguration _configuration;
        public NoteDal(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool DeleteNote(Note note)
        {
            throw new NotImplementedException();
        }

        public Note GetNote(int No)
        {
            using (var db = new BbsDbContext(_configuration))
            {
                var note = db.Notes.FirstOrDefault(x => x.No.Equals(No));
                return note;
            }
        }

        public List<Note> GetNoteList()
        {
            using (var db = new BbsDbContext(_configuration))
            {
                // DB에서 연동하고 List 출력
                return db.Notes.Include(x => x.User)
                    .OrderByDescending(n=>n.No)
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
            throw new NotImplementedException();
        }
    }
}
