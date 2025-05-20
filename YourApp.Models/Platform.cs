using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourApp.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Command> Commands { get; set; } = new List<Command>();

    }
}
