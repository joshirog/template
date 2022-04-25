using System;
using System.Collections.Generic;
using System.Linq;

namespace Monkeylab.Templates.Domain.Entities
{
    public static class BasePaginate
    {
        public static BasePaginate<T> Response<T>(int currentPage, int pageSize, IEnumerable<T> data = default) => new BasePaginate<T>(currentPage, pageSize, data);
    }
    
    public class BasePaginate<T>
    {
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }
        
        public IEnumerable<T> Items { get; set; }

        public int TotalCount => Items.Count();

        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        
        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;
        
        public BasePaginate(int currentPage, int pageSize, IEnumerable<T> items)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            Items = items;
        }
    }
}