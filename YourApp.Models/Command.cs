using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourApp.Models
{
    public class Command
    {
        public int Id { get; set; }
        public string Instruction { get; set; }

        // Foreign key
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}
