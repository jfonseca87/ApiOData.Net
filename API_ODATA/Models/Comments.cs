namespace API_ODATA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comments
    {
        public int Id { get; set; }

        [StringLength(1000)]
        public string Comment { get; set; }

        public int? IdPerson { get; set; }

        public virtual People People { get; set; }
    }
}
