using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MavroBeholderImport.Models
{
    [Table("Beholder.Person")]
    public partial class BeholderPerson
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int? MovementClassId { get; set; }

        public int? ConfidentialityTypeId { get; set; }

        [StringLength(1012)]
        public string DistinguishableMarks { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateCreated { get; set; }

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


    }
}
