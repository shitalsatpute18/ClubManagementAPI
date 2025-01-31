using ClubManagementAPI.Common;
using ClubManagementAPI.DTO;
using ClubManagementAPI.Interfaces;


namespace ClubManagementAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMemberRepository _memberRepository;

        public BookingService(IBookingRepository bookingRepository, IMemberRepository memberRepository)
        {
            _bookingRepository = bookingRepository;
            _memberRepository = memberRepository;
        }
        public async Task<APIResponse<BookingDTO>> CreateBookingAsync(BookingDTO bookingDto)
        {
            // Check if participation date is in the future
            if (bookingDto.ParticipationDate <= DateTime.Now)
                return new APIResponse<BookingDTO>(400, false, "Participation date must be in the future.", null);

            // Validate that the class is not full
            bool isClassFull = await _bookingRepository.IsClassFullAsync(bookingDto.GymClassId);
            if (isClassFull)
                return new APIResponse<BookingDTO>(400, false, "Class is full, cannot book a spot.", null);

            // Check if booking already exists for the same member and class at the same date
            var member = await _memberRepository.GetMemberByNameAsync(bookingDto.MemberName);
            if (member == null)
                return new APIResponse<BookingDTO>(400, false, "Member not found.", null);

            bool isBookingExists = await _bookingRepository.IsBookingExistsAsync(bookingDto.GymClassId, member.Id, bookingDto.ParticipationDate);
            if (isBookingExists)
                return new APIResponse<BookingDTO>(400, false, "Booking already exists for the same class on this date.", null);

            // If all checks pass, create the booking
            int bookingId = await _bookingRepository.CreateBookingAsync(bookingDto.GymClassId, member.Id, bookingDto.ParticipationDate);

            // Return successful response
            return new APIResponse<BookingDTO>(200, true, "Booking created successfully.", new BookingDTO
            {
                MemberName = bookingDto.MemberName,
                GymClassId = bookingDto.GymClassId,
                ParticipationDate = bookingDto.ParticipationDate
            });
        }
    }
}
