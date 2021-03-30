using System;
using System.Collections.Generic;
using System.Text;

namespace Bbs.Models
{
    public class Comment
    {
        /// <summary>
        /// 댓글 글번호
        /// </summary>
        public int No { get; set; }
        public int NoteNo { get; set; }
        public int UserNo { get; set; }
        public DateTime Date { get; set; }
        public int Parent { get; set; }
        public string Contents { get; set; }
    }
}
