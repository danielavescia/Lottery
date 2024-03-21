namespace webapi.Models.Domain
{
    public class Result
    {
        public  List <int> NumbersDrawn { get; set; }
        public Boolean IsThereWinner  { get; set; }
        public List<Ticket> WinnerTicket { get; set; } // list because more than one ticket can win
        public int Attempts { get; set; }
        public int Winners { get; set; }

        public Result( ) 
        {
             WinnerTicket = new List<Ticket>();
             NumbersDrawn = new List<int>();
             
        }

    }
}
