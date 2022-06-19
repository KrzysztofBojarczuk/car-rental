namespace RentalCarWebApi.Dtos
{
    public class CarCreateDto
    {
        public string CarName { get; set; } = string.Empty;
        public decimal RentalCost { get; set; }
        public int RentalDuration { get; set; }

    }
}
