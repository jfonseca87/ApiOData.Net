namespace API_ODATA.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class People
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public People()
        {
            Comments = new HashSet<Comments>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Names { get; set; }

        [StringLength(100)]
        public string LastNames { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int? Age { get; set; }

        public bool Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
