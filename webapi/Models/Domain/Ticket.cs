namespace webapi.Models.Domain
{
  
    public class Ticket
    {
        public int Id { get; set; }
        public required string Cpf { get; set; }
        public required string Name { get; set; }
        public required List<int>  SelectedNumbers { get; set; }
    }

}

