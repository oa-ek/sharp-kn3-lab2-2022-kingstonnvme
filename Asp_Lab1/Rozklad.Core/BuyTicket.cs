using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace Rozklad.Core
{
    public class BuyTicket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int buyTicketId { get; set; }
        public string BuyerName { get; set; }
        public int numTicket { get; set; }
        public string NomerTel { get; set; }


        public int AllPrice { get; set; }
        public int cardId { get; set; }
        public Card card { get; set; }

        public virtual ICollection<BusShedule> BusShedules { get; set; }
    }
}
