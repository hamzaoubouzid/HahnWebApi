 
namespace Hahn.Shared
{
    public static class PagerUtil
    {
        public static PaginatedList<T> List<T>(T[] items, Pager pager) where T : class
        {
            if (items == null)
                return null;
            if (pager == null)
                throw new ArgumentNullException("pager");

            return new PaginatedList<T>(items, pager);
        }

        public static PaginatedList<T> List<T>(List<T> items, Pager pager) where T : class
        {
            if (items == null)
                return null;
            if (pager == null)
                throw new ArgumentNullException("pager");

            return List(items.ToArray(), pager);
        }
    }
    public class Pager
    {
        /// <summary>
        /// Index de page de résultats à renvoyer (base 1).
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Taille de page de résultats à renvoyer.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Index de dernière page.
        /// </summary>
        public int LastPage { get; set; }

        /// <summary>
        /// Nombre d'article total
        /// </summary>
        public int TotalItemsCount { get; set; }
    }
    public static class QueryExtensions
    {
        /// <summary>
        /// Applique une pagination à une requête.
        /// </summary>
        /// <typeparam name="T">Le type d'éléments renvoyés par la requête.</typeparam>
        /// <param name="query">La requête à paginer.</param>
        /// <param name="pager">La pagination.</param>
        /// <returns>Une requête paginée.</returns>
        /// <remarks>La requête doit avoir été triée au préalable.</remarks>
        public static List<T> GetPage<T>(this IQueryable<T> query, Pager pager)
        {
            Normalize(pager);
            var totalResults = query.Count();
            FetchCount(pager, totalResults);

            return totalResults > 0 ? query.Skip((pager.Page - 1) * pager.PageSize).Take(pager.PageSize).ToList() : new List<T>();
        }
        private static void Normalize(Pager pager)
        {
            if (pager.PageSize < 1)
                pager.PageSize = 1;
            //if (pager.PageSize > Settings.Default.MaxPageSize)
            //    pager.PageSize = Settings.Default.MaxPageSize;

            if (pager.Page < 1)
                pager.Page = 1;
        }
        private static void FetchCount(Pager pager, int totalResults)
        {
            var totalPages = (totalResults - 1) / pager.PageSize + 1;

            if (pager.Page > totalPages)
                pager.Page = totalPages;
            pager.LastPage = totalPages;
            pager.TotalItemsCount = totalResults;
        }

    }
}
