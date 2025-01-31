namespace ClubManagementAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string MemberName { get; set; }
        public int ClassId { get; set; }
        public DateTime ParticipationDate { get; set; }
    }
}
