using webapi.Models.Domain;

namespace webapi.Services
{
    public class TicketService
    {
        //private readonly List<Ticket> ticketList;
        //private readonly Result results;
      

        /*public TicketService( List<Ticket> ticketList, Result results )   //DI
        {
            this.ticketList = ticketList;
            this.results = results;
        }*/


        public int CreateTicketId( List<Ticket> ticketList )
        {

            if ( ticketList.Count == 0  )
            {
                return 1000;
            }

            return ticketList.Count +1000;  //it will return the Id initializing in 1000 plus the number of tickets in tickeList
        }

        public List<int> GenerateRandomTicket() //generates a new list with 5 random numbers
        {
            List<int> numbersDrawn = new();
            bool numberIsRepeated;
            int number;

            for ( int i = 0 ; i <5 ; i++ )
            {
                do
                {
                    number = Utils.GenerateRandomNumber();
                    numberIsRepeated = Utils.NumberIsRepeated( numbersDrawn, number );

                } while ( numberIsRepeated == true );

                numbersDrawn.Add( number );
            }

            return numbersDrawn;
        }

    }
}