namespace ContosoPizza.Shared.Extensions.PagingExtensions
{
    public interface IPaging<T>
    {
        IEnumerable<T> Items { get; set; }
        public int TotalCount { get; }
        public int TotalPage { get; }  
    }
}
