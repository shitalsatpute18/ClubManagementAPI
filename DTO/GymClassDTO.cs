namespace ClubManagementAPI.DTO
{
    public class GymClassDTO
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public int Duration { get; set; }
        public int Capacity { get; set; }
    }
}
