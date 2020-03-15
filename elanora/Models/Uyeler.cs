namespace elanora.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Uyeler")]
    public partial class Uyeler
    {
        [Key]
        public int Uid { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Kullanýcý Adý")]
        public string Uadi { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Þifre")]
        public string Sifre { get; set; }

        [StringLength(20)]
        [Display(Name = "Adý")]
        public string UAd { get; set; }

        [StringLength(20)]
        [Display(Name = "Soyadý")]
        public string USoyad { get; set; }

        public int Yetkiid { get; set; }

        public virtual Yetkiler Yetkiler { get; set; }
    }
}
