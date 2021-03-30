using System;
using System.Collections.Generic;
using System.Text;

namespace Bbs.Models
{
    public class Image
    {
        public int No { get; set; }
        public string FileName { get; set; }
        public int Views { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        /// <summary>
        /// 댓글 기능을 위해서 추가
        /// </summary>

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
