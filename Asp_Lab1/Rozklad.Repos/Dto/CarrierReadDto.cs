using Microsoft.AspNetCore.Identity;
using Rozklad.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.Repos.Dto
{
    public class CarrierReadDto
    {
        public int carrierId { get; set; }

        public string Name { get; set; }

        public string Transport { get; set; }


    }
}
