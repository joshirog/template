using System.Collections.Generic;


namespace Monkeylab.Templates.Application.Commons.Dtos
{
    public class BaseResponsePaginate<T>
    {
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }
        
        public List<T> Items { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }
        
        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }
    }
}