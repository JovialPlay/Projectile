namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.tasks")]
    public partial class tasks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tasks()
        {
            todolists = new HashSet<todolists>();
            tags = new HashSet<tags>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int? taskpriority { get; set; }

        public int? taskcard { get; set; }

        public DateTime? taskdeadline { get; set; }

        public string taskdescription { get; set; }

        public bool? taskisdone { get; set; }

        public int? taskchecker { get; set; }

        [StringLength(256)]
        public string taskname { get; set; }

        public int? taskstatus { get; set; }

        public int? worker { get; set; }

        public virtual cards cards { get; set; }

        public virtual priorities priorities { get; set; }

        public virtual statuses statuses { get; set; }

        public virtual users users { get; set; }

        public virtual users users1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<todolists> todolists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tags> tags { get; set; }
    }
}
