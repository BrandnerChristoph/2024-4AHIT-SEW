using System.Security.Policy;

namespace StudentApi.Models
{
    public class Helper
    {
        public DateTime Timestamp { get; set; }
        public string Response {  get; set; }

        public Helper(string resp)
        {
            Timestamp = DateTime.Now;
            Response = resp;            
        }
    }
}
