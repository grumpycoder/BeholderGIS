using System.Collections.Generic;

namespace Domain
{
    //[Table("Address", Schema = "Common")]
    public class Address
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public int? StateId { get; set; }

        public string Zip5 { get; set; }
        public string Zip4 { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<AddressChapterRel> AddressChapterRels { get; set; }
    }
}
