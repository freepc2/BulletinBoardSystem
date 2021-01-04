using Bbs.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bbs.IDAL
{
    public interface INoteDal
    {
        Note GetNote();
        IEnumerable<Note> GetNoteList();
        bool SetNote(Note note);
    }
}
