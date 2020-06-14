using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulMovies.Model
{
    public partial class Peržiurėti
    {
        [Key]
        public int Id { get; set; }
        [Column("Filmas id")]
        public int FilmasId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Data { get; set; }
        public int? Įvertinimas { get; set; }
        [StringLength(250)]
        public string Komentaras { get; set; }

        [ForeignKey(nameof(FilmasId))]
        [InverseProperty("Peržiurėti")]
        public virtual Filmas Filmas { get; set; }
    }
}
