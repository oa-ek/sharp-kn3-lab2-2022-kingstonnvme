using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Core
{
 public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cardId { get; set; }
        public string NomerCard { get; set; }

        public string DateEnd { get; set; }
        public string CVC_kod { get; set; }

        public virtual ICollection<BuyTicket> BuyTickets { get; set; }
    }
}
