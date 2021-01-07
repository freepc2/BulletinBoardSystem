using Bbs.IDAL;
using Bbs.Models;
using Bbs.MSSQL.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bbs.Bll
{
    public class NoteBll
    {
        private readonly INoteDal _noteDal;
        public NoteBll(INoteDal noteDal)
        {
            _noteDal = noteDal;
        }

        public Note GetNote(int No)
        {
            if (No <= 0) throw new NotImplementedException();
            return _noteDal.GetNote(No);
        }
        public Note GetNoteAndUpdateView(int No)
        {
            if (No <= 0) throw new NotImplementedException();
            return _noteDal.GetNoteAndUpdateView(No);
        }
        public List<Note> GetNoteList()
        {
            return _noteDal.GetNoteList();
        }

        public List<Note> GetNoteList(int ListNo)
        {
            if (ListNo < 0) throw new NotImplementedException();
            return _noteDal.GetNoteList(ListNo);
        }
        public bool PostNote(Note note)
        {
            if (note == null) throw new ArgumentException();
            return _noteDal.PostNote(note);
        }

        public bool UpdateNote(Note note)
        {
            if (note == null) throw new ArgumentException();
            return _noteDal.UpdateNote(note);
        }

        public bool UpdateViewNote(Note note)
        {
            if (note == null) throw new ArgumentException();
            return _noteDal.UpdateViewNote(note);
        }

        public bool DeleteNote(int No)
        {
            if(No <= 0) throw new NotImplementedException();
            return _noteDal.DeleteNote(No);
        }

        public bool DeleteNote(Note note)
        {
            if (note == null) throw new ArgumentException();
            return _noteDal.DeleteNote(note);
        }


    }
}
