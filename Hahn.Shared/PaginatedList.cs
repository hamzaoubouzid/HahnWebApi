using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.Shared
{
    public class PaginatedList<T> : IDisposable where T : class
    {
        /// <summary>
        /// Current page index. (First page index is <c>1</c>).
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Page size (maximum items count on page, last page may have less items.)
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Last page index.
        /// </summary>
        public int LastPage { get; set; }

        /// <summary>
        /// Total items count (unpaginated).
        /// </summary>
        public int TotalItemsCount { get; set; }

        /// <summary>
        /// Current page items.
        /// </summary>
        public T[] Items { get; set; }

        /// <summary>
        /// Free memory
        /// </summary>
        public void Dispose()
        {
            if (this.Items == null)
                return;

            var arr = Items;
            Array.Clear(arr, 0, arr.Length);
            Array.Resize(ref arr, 0);
            arr = null;
            this.Items = arr;
        }

        public PaginatedList()
        {

        }
        public PaginatedList(T[] items, Pager pager)
        {
            Items = items;
            CurrentPage = pager.Page;
            PageSize = pager.PageSize;
            LastPage = pager.LastPage;
            TotalItemsCount = pager.TotalItemsCount;
        }

        public override string ToString()
        {
            return $"{{{nameof(CurrentPage)}={CurrentPage.ToString()}, {nameof(PageSize)}={PageSize.ToString()}, {nameof(LastPage)}={LastPage.ToString()}, {nameof(TotalItemsCount)}={TotalItemsCount.ToString()}}}";
        }
    }
}
