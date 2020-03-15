namespace elanora.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Makaleler")]
    public partial class Makaleler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Makaleler()
        {
            Etiketlers = new HashSet<Etiketler>();
        }

        [Key]
        public int Mid { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Makale Baþlýðý")]
        public string Baslik { get; set; }

        [Required]
        [Display(Name = "Makale Ýçeriði")]
        public string Icerik { get; set; }

        [Column(TypeName = "date")]
        public DateTime Tarih { get; set; }

        public int KategoriId { get; set; }

        [StringLength(50)]

        [Display(Name = "Makale Resmi")]
        public string MakaleResim { get; set; }

        public virtual Kategoriler Kategoriler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Etiketler> Etiketlers { get; set; }
    }
}
