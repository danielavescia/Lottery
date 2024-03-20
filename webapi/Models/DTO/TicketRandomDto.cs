using System.ComponentModel.DataAnnotations;

namespace webapi.Models.DTO
{
    public class TicketRandomDto
    {

        [Required]
        [MaxLength( 11, ErrorMessage = "Cpf has 11 numbers! Please, try again!" )]
        public string Cpf { get; set; }

        [Required( ErrorMessage = "Please, enter your name to validate your lottery ticket!" )]
        public string Name { get; set; }
    }
}
