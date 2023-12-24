namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.todos")]
    public partial class todos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int? todotodolist { get; set; }

        public bool? todoisdone { get; set; }

        [StringLength(256)]
        public string todoname { get; set; }

        public virtual todolists todolists { get; set; }
    }
}
