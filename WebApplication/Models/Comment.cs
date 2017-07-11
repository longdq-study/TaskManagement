using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public long ID { get; set; }
        public string Content { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ModifyDate { get; set; }
        public bool Status { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual MyTask MyTask { get; set; }

    }
}