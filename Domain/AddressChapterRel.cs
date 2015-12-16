using System;

namespace Domain
{
    public class AddressChapterRel
    {
        public int Id { get; set; }
        public int ChapterId { get; set; }
        public int AddressId { get; set; }
        public int? AddressTypeId { get; set; }
        public DateTime? FirstKnownUseDate { get; set; }
        public DateTime? LastKnownUseDate { get; set; }
        public int PrimaryStatusId { get; set; }

        public virtual Address Address { get; set; }
    }
}
