namespace PrivateKeyApi.Models
{
    public class TimeTable
    {
        public string College { get; set; }
        public string Campus { get; set; }
        public List<FloorSelection> FloorSelection { get; set; }
    }
}
