namespace elanora.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yetkiler")]
    public partial class Yetkiler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Yetkiler()
        {
            Uyelers = new HashSet<Uyeler>();
        }

        [Key]
        public int YetkiId { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Yetki Adý")]
        public string YetkiAdi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uyeler> Uyelers { get; set; }
    }
}
