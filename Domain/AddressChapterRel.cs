using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Beholder.AddressChapterRel")]
    public partial class AddressChapterRel
    {
        [Key]
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
