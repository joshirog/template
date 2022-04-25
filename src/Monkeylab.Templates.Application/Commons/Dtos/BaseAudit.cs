namespace Monkeylab.Templates.Application.Commons.Dtos
{
    public class BaseAudit
    {
        public string Tracking { get; set; }
        
        public string Ip { get; set; }

        public string Device { get; set; }

        public string Browser { get; set; }
    }
}