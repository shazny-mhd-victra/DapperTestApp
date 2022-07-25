using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Priorities")]
    public class Priorities
    {
        public Priorities()
        {
            News = new HashSet<News>();
        }
        [Key]
        [Required]
        public int _priority_id { get; set; }
        [Required]
        public int _level { get; set; }
        public string? _description { get; set; }
        public bool _active { get; set; }
        public virtual ICollection<News>? News { get; set; }

    }
}
