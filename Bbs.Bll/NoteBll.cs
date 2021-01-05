using Bbs.IDAL;
using Bbs.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bbs.Bll
{
    public class NoteBll 
    {
        private INoteDal _noteDal;
        public NoteBll(INoteDal noteDal)
        {
            _noteDal = noteDal;
        }

        public bool DeleteNote(Note note)
        {
            throw new NotImplementedException();
        }

        public Note GetNote(int No)
        {
            if (No <= 0) throw new ArgumentException();
            return _noteDal.GetNote(No);
        }

        public List<Note> GetNoteList()
        {
            return _noteDal.GetNoteList();
        }

        public bool PostNote(Note note)
        {
            if (note == null) throw new ArgumentException();
            return _noteDal.PostNote(note);
        }

        public bool UpdateNote(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
