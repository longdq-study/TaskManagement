namespace WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MyTask")]
    public partial class MyTask
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string TaskName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? DueDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ModifyDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? PlanedStartDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? PlanedEndDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ActualStartDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ActualEndDate { get; set; }

        public long? AssigneeID { get; set; }

        public long? ReporterID { get; set; }

        public short? PercentDone { get; set; }

        public short? Status { get; set; }

        [Column(TypeName = "ntext")]
        public string Attachment { get; set; }

        public string CommentID { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
