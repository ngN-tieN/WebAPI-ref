namespace ContosoPizza.Models
{
    public record BasePagingParameter
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }
}
