using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FengShuiNumber.Models.Entities
{
    public class BaseEntity
    {
        [Key]
        [Column("Id")]
        [Required]
        public virtual Guid Id { get; set; } = Guid.NewGuid();
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
