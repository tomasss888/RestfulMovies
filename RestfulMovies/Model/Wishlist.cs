using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulMovies.Model
{
    /// <summary>
    /// Defines Database table Wishlist
    /// </summary>
    /// <param name="Id"> Holds id number </param>>
    /// <param name="MovieId"> Links this table with one of chosen movies by id</param>>
    /// <param name="Date"> When the movie was added to watchlist </param>>
    public partial class Wishlist
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("Movie_ID")]
        public int? MovieId { get; set; }
        [StringLength(128)]
        public string Date { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("Wishlist")]
        public virtual Movie Movie { get; set; }
    }
}
