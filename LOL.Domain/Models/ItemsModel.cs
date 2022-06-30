using System;
using System.Collections.Generic;
using System.Text;

namespace LOL.Domain.Models
{
    public class ItemsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsRune { get; set; }
        public string Type { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
    }
}
