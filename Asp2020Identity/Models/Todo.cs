using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp2020Identity.Models
{
    public class Todo
    {
        [Key]
        [StringLength(70)]
        public string Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public DateTime CreationTime { get; set; }

        [StringLength(70)]
        public string UserId { get; set; }

        public virtual SiteUser Creator { get; set; }
    }
}
