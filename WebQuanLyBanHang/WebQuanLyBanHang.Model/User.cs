namespace WebQuanLyBanHang.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int Userid { get; set; }

        [Required]
        [StringLength(30)]
        public string Username { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Avatar { get; set; }

        public int? Allowed { get; set; }
    }
}
