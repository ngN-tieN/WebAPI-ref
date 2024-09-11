namespace ContosoPizza.Shared.Extensions.PagingExtensions
{
    public sealed class Paging<T> : IPaging<T>
    {
        private readonly int _totalPage;
        private readonly int _totalCount;
        private readonly IEnumerable<T> _items;
        public Paging(IEnumerable<T> items, int totalCount, int totalPage)
        {
            _items = items;
            _totalCount = totalCount;
            _totalPage = totalPage;
        }

        public IEnumerable<T> Items { get => _items; set => _ = Items; }
        public int TotalCount { get => _totalCount; }
        public int TotalPage { get => _totalPage; }
    }
}
