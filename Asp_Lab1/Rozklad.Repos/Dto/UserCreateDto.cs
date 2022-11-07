using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Repos.Dto
{
   public class UserCreateDto
    {
        

        [Required(ErrorMessage ="Введіть емейл")]
        [StringLength(128, ErrorMessage = "Must be between 5 and 16 characters", MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$",ErrorMessage ="Must be a valid email")]

        public string? Email { get; set; }

        [Required(ErrorMessage = "Введіть пароль")]
        [DataType(DataType.Password)]

        public string? Password { get; set; }

        [Required(ErrorMessage = "Введіть фамілію")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Введіть ім'я")]
        public string? FirstName { get; set; }
    }
}
