namespace RentalCarWebApi.Dtos
{
    public class MemberGetDto
    {

        public int MemberId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;


    }
}
