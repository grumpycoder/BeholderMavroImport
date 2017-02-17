using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MavroBeholderImport.Models
{
    [Table("Beholder.MediaWebsiteEGroupContext")]
    public partial class MediaWebsiteEGroupContext
    {
        public int Id { get; set; }

        public Guid FileStreamID { get; set; }

        public int MimeTypeId { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }

        [StringLength(10)]
        public string DocumentExtension { get; set; }

        public byte[] ContextText { get; set; }

        public int? MediaWebsiteEGroupId { get; set; }

        public bool? IsUncompressed { get; set; }

        public byte[] ContextText1 { get; set; }
    }
}
