namespace Survivor.Models.DTOs
{
    public class CompetitorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int CategoryId { get; set; }
    }
}//Sebep: DTO'lar client ile API arasındaki veri transferini yönetir ve entity'leri direkt olarak expose etmekten kaçınmamızı sağlar.
