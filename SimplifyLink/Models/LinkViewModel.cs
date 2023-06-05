using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyLink.Models
{
    public class LinkViewModel
    {
        public Guid Id { get; set; }

        public string? Url { get; set; }

        public string? MinUrl { get; set; }

        public int? Ticket { get; set; } = 0;

        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    }
}
