using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kocsistem.RabbitMQ.Customers.Domain.Entities
{
    public class CustomersTable
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }


    }
}
