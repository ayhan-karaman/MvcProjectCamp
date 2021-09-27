using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public  class Admin
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string AdminUserName { get; set; }

        [StringLength(500)]
        public string AdminPassword { get; set; }

        public bool AdminStatus { get; set; }

        public virtual int? RoleId { get; set; }
        public virtual Role Role { get; set; }




    }
}
