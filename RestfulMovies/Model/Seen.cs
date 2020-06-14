using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulMovies.Model
{
    public partial class Seen
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("Movie_ID")]
        public int? MovieId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
        public int? Rating { get; set; }
        [StringLength(128)]
        public string Comment { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("Seen")]
        public virtual Movie Movie { get; set; }
    }
}
