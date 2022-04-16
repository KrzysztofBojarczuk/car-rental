namespace RentalCarWebApi.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string CarName { get; set; } = string.Empty;
        public decimal RentalCost { get; set; }
        public int RentalDuration { get; set; }

        //Many to Many Relation
        public IList<CarRental> CarRentals { get; set; }
    }
}
