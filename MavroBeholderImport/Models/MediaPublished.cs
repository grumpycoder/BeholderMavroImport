using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MavroBeholderImport.Models
{
    [Table("Beholder.MediaPublished")]
    public partial class MediaPublished
    {
        public MediaPublished()
        {
            ChapterMediaPublishedRels = new HashSet<ChapterMediaPublishedRel>();
            PersonMediaPublishedRels = new HashSet<PersonMediaPublishedRel>();
        }

        public int Id { get; set; }

        public int MediaTypeId { get; set; }

        public int? PublishedTypeId { get; set; }

        public int? LibraryCategoryTypeId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DatePublished { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateReceived { get; set; }

        [StringLength(80)]
        public string Author { get; set; }

        public int? NewsSourceId { get; set; }

        public int? MovementClassId { get; set; }

        public int? ConfidentialityTypeId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateRenewalPermission { get; set; }

        public int? RenewalPermissionTypeId { get; set; }

        [StringLength(500)]
        public string RenewalPermission { get; set; }

        [StringLength(4000)]
        public string Summary { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string County { get; set; }

        public int? StateId { get; set; }

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

        public int? MediaPublishedContextId { get; set; }

        [StringLength(15)]
        public string CatalogId { get; set; }

        public virtual ICollection<ChapterMediaPublishedRel> ChapterMediaPublishedRels { get; set; }

        public virtual ICollection<PersonMediaPublishedRel> PersonMediaPublishedRels { get; set; }
    }
}
