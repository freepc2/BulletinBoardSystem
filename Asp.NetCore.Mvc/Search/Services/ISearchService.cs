using Bbs.Models;
using System.Collections.Generic;

namespace Asp.NetCore.Mvc.Search.Services
{
    public interface ISearchService
    {
        SearchResult GetSearchResult(List<Note> note, string query, int page, int pageSize);
        SearchResult GetResult(List<Note> note, int page, int pageSize);
    }
}
