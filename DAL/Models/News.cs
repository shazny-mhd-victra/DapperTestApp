using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class News
    {
        //public News()
        //{
        //    Priority._priority_id = _priority_id;
        //}
        [Key]
        [Column("_news_id")]
        public int _news_id { get; set; }
        [Column("_priority_id")]
        public int _priority_id { get; set; }
        [Column("_title")]
        public string? _title { get; set; }
        [Column("_description")]
        public string? _description { get; set; }
        [Column("_start_date")]
        public DateTime? _start_date { get; set; }
        [Column("_end_date")]
        public DateTime? _end_date { get; set; }
        [Column("_primary_image")]
        public string? _primary_image { get; set; }
        [Column("_secondary_image")]
        public string? _secondary_image { get; set; }
        [Column("_is_deleted")]
        public bool _is_deleted { get; set; }
        [Column("_video_url")]
        public string? _video_url { get; set; }
        [Column("_short_description")]
        public string? _short_description { get; set; }
        [NotMapped]
        public virtual Priorities? Priority { get; set; }
    }
}
