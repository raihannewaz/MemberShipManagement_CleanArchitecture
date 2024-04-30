using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManagement_CleanArchitecture.Application.Helpers
{
    public class Pagination<T>
    {
        public List<T> Items { get; }

        public int Page { get; }

        public int PageSize { get;  }

        public int TotalPages { get; }


        public bool HasNextPage => Page * PageSize < TotalPages;

        public bool HasPrevoiusPage => Page > 1;



        private Pagination(List<T> items, int page, int pageSize, int totalPages)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalPages = totalPages;
        }


        public static Pagination<T> CreatePgination(IEnumerable<T> query, int page, int pageSize)
        {
            int totalPages =  query.Count();
            var items =  query.Skip((page-1)*pageSize).Take(pageSize).ToList();

            return new Pagination<T>(items, page, pageSize, totalPages);
        }
    }
}
