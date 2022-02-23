namespace EFDBFirstDemo.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contact
    {
        public int ContactID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(12)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Location { get; set; }
    }
}
