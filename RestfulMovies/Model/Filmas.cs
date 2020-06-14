using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulMovies.Model
{
    public partial class Filmas
    {
        public Filmas()
        {
            Peržiurėti = new HashSet<Peržiurėti>();
            StebėjimoSąrašas = new HashSet<StebėjimoSąrašas>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(128)]
        public string Pavadinimas { get; set; }
        [StringLength(128)]
        public string Žanras { get; set; }
        public int? Trukmė { get; set; }
        [Column("Sukurimo data", TypeName = "date")]
        public DateTime? SukurimoData { get; set; }

        [InverseProperty("Filmas")]
        public virtual ICollection<Peržiurėti> Peržiurėti { get; set; }
        [InverseProperty("Filmas")]
        public virtual ICollection<StebėjimoSąrašas> StebėjimoSąrašas { get; set; }
    }
}
