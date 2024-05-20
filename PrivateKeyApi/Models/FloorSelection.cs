namespace PrivateKeyApi.Models
{
    public class FloorSelection
    {
        public int Floor { get; set; }
        public string Department { get; set; }
        public string Course { get; set; }
        public string Lecture { get; set; }
        public string ClassroomNo { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Status { get; set; }
        public string FacultyName { get; set; }
        public List<string> EligibleStudents { get; set; }
    }
}
