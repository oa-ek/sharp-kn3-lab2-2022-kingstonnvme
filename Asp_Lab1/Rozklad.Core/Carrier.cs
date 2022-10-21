using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Core
{
    public class Carrier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int carrierId { get; set; }

        public string Name { get; set; }

        public string Transport { get; set; }
        public virtual ICollection<BusShedule> BusShedules { get; set; }

    }
}
