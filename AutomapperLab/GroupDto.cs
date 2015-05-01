using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class GroupDto
    {
        public ShopDto MainShop { get; set; }
        public List<ShopDto> SubShops { get; set; }
    }
}
