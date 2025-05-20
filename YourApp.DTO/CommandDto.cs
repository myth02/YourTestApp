using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourApp.DTO
{
    public class CommandDto
    {
        public int Id { get; set; }
        public string Instruction { get; set; }
        public int PlatformId { get; set; }
    }
}
