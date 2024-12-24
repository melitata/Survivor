using Survivor.Models.Base;

namespace Survivor.Models.Entities
{
    public class CompetitorEntity : BaseEntity
    {
        internal readonly object DTO;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int CategoryId { get; set; }

        public required CategoryEntity Category { get; set; }
    }
}//Sebep: Entity'ler veritabanı tablolarımızı temsil eder ve aralarındaki ilişkileri tanımlar.
