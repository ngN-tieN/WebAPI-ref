using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Shared.Extensions.PagingExtensions
{
    public static class PagingExtensions
    {
        public static async Task<IPaging<T>> PagingAsync<T>(this IQueryable<T> entities, int pageNumber, int pageSize)
        {
            int count = await entities.CountAsync();
            IEnumerable<T> items = entities.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            var totalPage = (int)Math.Ceiling(count / (double)pageSize);
            return new Paging<T>(items, count, totalPage);
        }
    }
}
