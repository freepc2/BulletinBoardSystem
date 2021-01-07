using Bbs.Models;
using PagedList.Core;
using System.Collections.Generic;
using System.Linq;

namespace Asp.NetCore.Mvc.Search.Services
{
    public class SearchService : ISearchService
    {
        private IList<Note> _searchList = new List<Note>();
        public SearchService()
        {
        }

        public SearchResult GetResult(List<Note> note, int page, int pageSize)
        {
            _searchList = note;
            var searchResult = new SearchResult()
            {
                SearchHits = new StaticPagedList<Note>(_searchList.Skip((page - 1) * pageSize).Take(pageSize), page, pageSize, _searchList.Count()),
                SearchQuery = ""
            };
            return searchResult;
        }

        public SearchResult GetSearchResult(List<Note> note, string query, int page, int pageSize)
        {
            _searchList = note;
            var searchHits = this._searchList
                .Where(x => 
                x.Contents.Contains(query, System.StringComparison.CurrentCultureIgnoreCase)|
                x.Title.Contains(query, System.StringComparison.CurrentCultureIgnoreCase)
                );

            var searchResult = new SearchResult()
            {
                SearchHits = new StaticPagedList<Note>(searchHits.Skip((page - 1) * pageSize).Take(pageSize), page, pageSize, searchHits.Count()),
                SearchQuery = query
            };

            return searchResult;
        }
    }
}
