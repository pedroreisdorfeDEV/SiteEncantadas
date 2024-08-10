namespace SiteEncantadas.Models.Entities
{
    public class Pagamento
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DatePaid { get; set; }
    }
}
