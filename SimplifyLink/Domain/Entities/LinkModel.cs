using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimplifyLink.Domain.Entities
{
    public class LinkModel
    {

        [Required] 
        public Guid Id { get; set; }

        [Display(Name = "Url")]
        public string? Url { get; set; }
        [Display(Name = "Url")]
        public string? MinUrl { get; set; }
        [Display(Name = "MinUrl")]
        public int? Ticket { get; set; } = 0;
        [Display(Name = "Ticket")]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        [Required]
        public Guid UserId { get; set; }

    }
}
