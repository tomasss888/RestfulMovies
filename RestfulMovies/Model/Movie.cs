using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulMovies.Model
{
    public partial class Movie
    {
        public Movie()
        {
            Seen = new HashSet<Seen>();
            Wishlist = new HashSet<Wishlist>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(128)]
        public string Name { get; set; }
        [StringLength(128)]
        public string Genre { get; set; }
        [StringLength(128)]
        public string Length { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [InverseProperty("Movie")]
        public virtual ICollection<Seen> Seen { get; set; }
        [InverseProperty("Movie")]
        public virtual ICollection<Wishlist> Wishlist { get; set; }
    }
}