using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Entity
{
    [Table("User")]
   public class User
    {
        public int Id { get; set; }

        [StringLength(128)]
        public String FirstName { get; set; }

        [StringLength(128)]
        public String LastName { get; set; }

        [Column(TypeName ="datetime2")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(256)]
        public String Email { get; set; }

        [StringLength(1024)]
        public String HashedPassword { get; set; }

        [StringLength(1024)]
        public String Salt { get; set; }

        [StringLength(16)]
        public String PhoneNumber { get; set; }

        public bool? TwoFactorEnabled { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? LockoutEndDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? LastLoginDateTime { get; set; }

        public bool? IsLocked { get; set; }

        public int? AccessFailedCount { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Role> Roles { get; set; }

        public ICollection<Favorite> Favorites { get; set; }


        public ICollection<Purchase> Purchases { get; set; }

    }
}


