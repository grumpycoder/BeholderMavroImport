using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MavroBeholderImport.Models
{
    [Table("Common.Person")]
    public partial class CommonPerson
    {
        public int Id { get; set; }

        [StringLength(9)]
        public string SSN { get; set; }

        public int? PrefixId { get; set; }

        [StringLength(256)]
        public string FName { get; set; }

        [StringLength(256)]
        public string MName { get; set; }

        [Required]
        [StringLength(256)]
        public string LName { get; set; }

        public int? SuffixId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DOB { get; set; }

        public bool? ActualDOBIndicator { get; set; }

        public int? GenderId { get; set; }

        public int? LicenseTypeId { get; set; }

        [StringLength(125)]
        public string DriversLicenseNumber { get; set; }

        public int? DriversLicenseStateId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DeceasedDate { get; set; }

        public bool? ActualDeceasedDateIndicator { get; set; }

        public int? HairColorId { get; set; }

        public int? HairPatternId { get; set; }

        public int? EyeColorId { get; set; }

        [StringLength(20)]
        public string Height { get; set; }

        [StringLength(20)]
        public string Weight { get; set; }

        public int? RaceId { get; set; }

        public int? MartialStatusId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }

        public int? CreatedUserId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateModified { get; set; }

        public int? ModifiedUserId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateDeleted { get; set; }

        public int? DeletedUserId { get; set; }

        public int? OldId { get; set; }

        public int? OldContactId { get; set; }

        public String FullName
        {
            get { return string.Format("{0} {1}", FName, LName); }
        }
    }
}
