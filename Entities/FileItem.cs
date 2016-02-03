using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectCleaner.Entities
{
    public class FileItem : Item
    {
        public List<Item> Items { get; set; }

        public FileItem()
        {
            Items = new List<Item>();
        }
    }
}
