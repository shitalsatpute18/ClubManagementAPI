namespace ClubManagementAPI.Models
{
    public class GymClass
    {
        public int Id { get; set; }  // Primary Key
        public string Name { get; set; }  // Class Name
        public DateTime StartDate { get; set; }  // Start Date of Class
        public DateTime EndDate { get; set; }  // End Date of Class
        public TimeSpan StartTime { get; set; }  // Start Time
        public int Duration { get; set; }  // Duration in Minutes
        public int Capacity { get; set; }  // Maximum number of members per session
    }
}





