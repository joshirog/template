namespace Monkeylab.Templates.Application.Commons.Dtos
{
    public class BaseRequestPaginate
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 20;
    }
}
