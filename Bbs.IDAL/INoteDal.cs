using Bbs.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bbs.IDAL
{
    public interface INoteDal
    {
        Note GetNote(int No);
        List<Note> GetNoteList();
        bool PostNote(Note note);

        bool UpdateNote(Note note);

        bool DeleteNote(Note note);
    }
}
