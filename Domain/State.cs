namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Common.State")]
    public partial class State
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "State Code")]
        public string StateCode { get; set; }
        [Display(Name = "State Name")]
        public string StateName { get; set; }


        public virtual ICollection<Address> Addresses { get; set; }
    }
}
