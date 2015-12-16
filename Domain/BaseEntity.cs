using System;

namespace Domain
{
    public class BaseEntity
    {
        public DateTime DateCreated { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? DateModified { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? DateDeleted { get; set; }
        public int? DeletedUserId { get; set; }
    }
}