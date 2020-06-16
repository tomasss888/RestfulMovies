using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulMovies.Model
{
    /// <summary>
    /// Defines Database table Seen
    /// </summary>
    /// <param name="Id"> Holds id number </param>>
    /// <param name="MovieId"> Links this table with one of chosen movies by id</param>>
    /// <param name="Date"> When the movie was watched </param>>
    /// <param name="Rating"> User rating of a movie </param>>
    /// <param name="Comment"> Comment abot movie </param>>
    public partial class Seen
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("Movie_ID")]
        public int? MovieId { get; set; }
        [StringLength(128)]
        public string Date { get; set; }
        
        public int? Rating { get; set; }
        [StringLength(128)]
        public string Comment { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("Seen")]
        public virtual Movie Movie { get; set; }
    }
}
