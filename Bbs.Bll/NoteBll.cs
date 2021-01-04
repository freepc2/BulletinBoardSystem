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
        public Note GetNote(int No)
        {
            return _noteDal.GetNote(No);
        }

        public List<Note> GetNoteList()
        {
            return _noteDal.GetNoteList();
        }

        public bool SetNote(Note note)
        {
            return _noteDal.SetNote(note);
        }
    }
}
