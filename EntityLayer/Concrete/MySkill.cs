using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class MySkill
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string SkillName { get; set; }

        public int Rate { get; set; }
        public int TalentCardId { get; set; }

        public virtual TalentCard TalentCard { get; set; }
    }
}
