using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MavroBeholderImport.Models
{
    [Table("Beholder.MediaWebsiteEGroup")]
    public partial class MediaWebsiteEGroup
    {
        public int Id { get; set; }

        public int MediaTypeId { get; set; }

        public int? WebsiteEGroupTypeId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string URL { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateDiscovered { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DatePublished { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateOffline { get; set; }

        [StringLength(20)]
        public string IPAddress { get; set; }

        public int? NewsSourceId { get; set; }

        public int? MovementClassId { get; set; }

        public int? ConfidentialityTypeId { get; set; }

        public int? ActiveYear { get; set; }

        public int? ActiveStatusId { get; set; }

        public bool? IsReported { get; set; }

        public int? ApprovalStatusId { get; set; }

        [StringLength(4000)]
        public string WhoIsInfo { get; set; }

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

        public int? MediaWebsiteEGroupContextId { get; set; }
    }
}
