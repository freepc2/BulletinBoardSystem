using Bbs.Models;
using PagedList.Core;

namespace Asp.NetCore.Mvc.Search
{
    public class SearchResult
    {
        public IPagedList<Note> SearchHits { get; set; }
        public string SearchQuery { get; set; }
    }
}
