 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hahn.ticket.Entity
{
    [Table("Ticket")]
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public DateTime? Date { get; set; }
    }
}
