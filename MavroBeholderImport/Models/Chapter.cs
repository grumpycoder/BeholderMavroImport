using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MavroBeholderImport.Models
{
    [Table("Beholder.Chapter")]
    public partial class Chapter
    {
        public Chapter()
        {
            ChapterMediaPublishedRels = new HashSet<ChapterMediaPublishedRel>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ChapterName { get; set; }

        [StringLength(512)]
        public string ChapterDesc { get; set; }

        public int? ChapterTypeId { get; set; }

        public int ApprovalStatusId { get; set; }

        public int ActiveStatusId { get; set; }

        public int? ActiveYear { get; set; }

        public bool ReportStatusFlag { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? FormedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DisbandDate { get; set; }

        public int? MovementClassId { get; set; }

        public int? ConfidentialityTypeId { get; set; }

        public bool IsHeadquarters { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }

        public int CreatedUserId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateModified { get; set; }

        public int? ModifiedUserId { get; set; }

        public int? RemovalStatusId { get; set; }

        [StringLength(50)]
        public string RemovalReason { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateDeleted { get; set; }

        public int? DeletedUserId { get; set; }

        public virtual ICollection<ChapterMediaPublishedRel> ChapterMediaPublishedRels { get; set; }
    }
}
