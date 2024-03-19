namespace webapi.Models.DTO
{
    public class TicketDto
    {
        public int Id { get; set; }
        public required string Cpf { get; set; }
        public required List<int> SelectedNumbers { get; set; }


        public TicketDto() { }
    }
}
