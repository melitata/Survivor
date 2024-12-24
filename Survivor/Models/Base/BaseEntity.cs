namespace Survivor.Models.Base
{
        public abstract class BaseEntity
        {
            public int Id { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime? ModifiedDate { get; set; }
            public bool IsDeleted { get; set; }
        }
    //Sebep: Tüm entity'lerde ortak olacak alanları tek bir yerde tanımlayarak kod tekrarını önlüyoruz ve merkezi bir yapı oluşturuyoruz.
}
