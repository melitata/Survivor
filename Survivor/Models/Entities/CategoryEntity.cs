using Survivor.Models.Base;

namespace Survivor.Models.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string? Description  { get; set; }
        public required string? Name { get; set; }
        public ICollection<CompetitorEntity> Competitors { get; set; } = new List<CompetitorEntity>();

    }
}
