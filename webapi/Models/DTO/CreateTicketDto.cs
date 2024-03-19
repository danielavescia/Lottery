using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace webapi.Models.DTO
{
    public class CreateTicketDto
    {
        [Required]
        [MaxLength( 12, ErrorMessage = "Cpf has 12 numbers! Please, try again!" )] // requirement to cpf number to create TicketDto
        public required string Cpf { get; set; }

        [Required( ErrorMessage = "Please, enter your name to validate your lottery ticket!" )]
        public required string Name { get; set; }

        //model validations
        [Required]
        [MaxLength( 5, ErrorMessage = "Your ticket lottery need 5 numbers!" )]// numbers required to create TicketDto
        public required List<int>  SelectedNumbers { get; set; }


    }
}
