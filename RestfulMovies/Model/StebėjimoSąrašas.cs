using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulMovies.Model
{
    [Table("Stebėjimo sąrašas")]
    public partial class StebėjimoSąrašas
    {
        [Key]
        public int Id { get; set; }
        [Column("Filmas id")]
        public int? FilmasId { get; set; }
        [Column("Pridėjimo data", TypeName = "date")]
        public DateTime? PridėjimoData { get; set; }

        [ForeignKey(nameof(FilmasId))]
        [InverseProperty("StebėjimoSąrašas")]
        public virtual Filmas Filmas { get; set; }
    }
}
