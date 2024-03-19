namespace webapi.Models.DTO
{
    public class ResultDto
    {
        public required List<int> NumbersDrawn { get; set; }
        public Boolean isThereWinner { get; set; }

        public List<int>  WinnerTicketId { get; set; }
    }
}
