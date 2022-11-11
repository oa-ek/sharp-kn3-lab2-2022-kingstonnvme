using Rozklad.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Repos.Dto
{
   public class BuyTicketCreateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Введіть своє імя")]
        public string buyerName { get; set; }

        
        [Required(ErrorMessage = "Введіть кількість квитків")]
        public int numTicket { get; set; }
     
        [Required(ErrorMessage = "Введіть номер телефону")]
        public string nomerTel { get; set; }

        [Required(ErrorMessage = "Введіть правильно дані про картку!")]
        public Card? card { get; set; }
      
public int Allprice { get; set; }
      







    }
}
