using Bbs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bbs.IDAL
{
    public interface INoteDal
    {
        /// <summary>
        /// 게시판
        /// </summary>
        /// <param name="No"></param>
        /// <returns></returns>
        Note GetNote(int No);

        /// <summary>
        /// 게시판
        /// </summary>
        /// <param name="No"></param>
        /// <returns></returns>
        Note GetNoteAndUpdateView(int No);
        /// <summary>
        /// 게시판 리스트 받아오기
        /// </summary>
        /// <returns></returns>
        List<Note> GetNoteList();
        /// <summary>
        /// 게시판 리스트 갯수로
        /// </summary>
        /// <returns></returns>
        List<Note> GetNoteList(int ListNo);
        /// <summary>
        /// 게시판 게시
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        /// 
        List<Note> GetNoteList(int ListNo, int count);
        /// <summary>
        /// 게시판 게시
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        bool PostNote(Note note);
        /// <summary>
        /// 게시판 내용 업데이트
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        bool UpdateNote(Note note);
        /// <summary>
        /// View 카운트 증가
        /// </summary>
        /// <returns></returns>
        bool UpdateViewNote(Note No);
        /// <summary>
        /// 게시판 삭제
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        bool DeleteNote(int No);
        /// <summary>
        /// 게시판 내용 삭제
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        bool DeleteNote(Note note);

    }
}
