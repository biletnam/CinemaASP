namespace ClassworkPractic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sessions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sessions()
        {
            Order = new HashSet<Order>();
        }

        [Key]
        public long SessionId { get; set; }

        public long FilmID { get; set; }

        public DateTime Date { get; set; }

        public long HallID { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public virtual FilmLibrary FilmLibrary { get; set; }

        public virtual Halls Halls { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
