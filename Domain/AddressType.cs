namespace Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Common.AddressType")]
    public partial class AddressType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }


    }
}
