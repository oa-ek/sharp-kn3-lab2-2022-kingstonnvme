using Microsoft.AspNetCore.Identity;
using Rozklad.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Repos.Dto
{
    public class StatusReadDto
    {

        public int statusId { get; set; }
        public string StatusValue { get; set; }
    }
}
