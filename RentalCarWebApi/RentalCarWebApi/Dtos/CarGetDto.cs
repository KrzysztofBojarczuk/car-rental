namespace RentalCarWebApi.Dtos
{
    public class CarGetDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; } = string.Empty;
        public decimal RentalCost { get; set; }
        public int RentalDuration { get; set; }
    }
}
