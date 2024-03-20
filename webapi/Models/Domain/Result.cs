namespace webapi.Models.Domain
{
    public class Result
    {
        public  List <int> NumbersDrawn { get; set; }
        public Boolean IsThereWinner  { get; set; }
        public List<int>  WinnerTicketId { get; set; } // list because more than one ticket can win

        public Result( ) 
        {
        }

    }
}
