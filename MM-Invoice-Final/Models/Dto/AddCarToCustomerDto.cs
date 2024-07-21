namespace MM_Invoice_Final.Models.Dto
{
    public class AddCarToCustomerDto
    {
        public int CustomerId { get; set; }
        public string CarRego { get; set; }
        public string CarMake { get; set; }
        public string? CarModel { get; set; }
    }
}
