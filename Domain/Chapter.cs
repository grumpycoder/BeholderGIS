using System;
using System.Collections.Generic;

namespace Domain
{
    public class Chapter
    {
        public int Id { get; set; }
        public string ChapterName { get; set; }
        public string ChapterDesc { get; set; }
        public int? ChapterTypeId { get; set; }
        public int ApprovalStatusId { get; set; }
        public int? ActiveStatusId { get; set; }
        public int? ActiveYear { get; set; }
        public bool ReportStatusFlag { get; set; }
        public DateTime? FormedDate { get; set; }
        public DateTime? DisbandDate { get; set; }
        public int? MovementClassId { get; set; }
        public int? ConfidentialityTypeId { get; set; }
        public int? RemovalStatusId { get; set; }
        public string RemovalReason { get; set; }
        public bool IsHeadquarters { get; set; }

        public virtual ActiveStatus ActiveStatus { get; set; }
        public virtual ApprovalStatus ApprovalStatus { get; set; }
        public virtual ChapterType ChapterType { get; set; }
        public virtual ConfidentialityType ConfidentialityType { get; set; }
        public virtual MovementClass MovementClass { get; set; }
        public virtual RemovalStatus RemovalStatus { get; set; }

        public virtual ICollection<AddressChapterRel> AddressChapterRels { get; set; }
    }
}