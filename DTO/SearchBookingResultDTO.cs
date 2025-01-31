namespace ClubManagementAPI.DTO
{
    public class SearchBookingResultDTO
    {
        public string GymClassName { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime ParticipationDate { get; set; }
        public string MemberName { get; set; }
    }
}
