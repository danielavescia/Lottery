
using webapi.Models.Domain;


namespace webapi.Services
{
    public class ResultService
    {
        private readonly List<Ticket> ticketsList;
        private readonly Result results;
        public ResultService( List<Ticket> ticketList, Result results )
        {
            this.ticketsList = ticketsList;
            this.results = results;
        }

        public Result GenerateResults( List<Ticket> ticketsList )
        {
            int maxAttempts = 25;
            Result results = new();

            if ( ticketsList == null )
            {
                throw new Exception( "Please, You ned to bet first!" );
            }

            else if ( ticketsList != null & results.NumbersDrawn == null )
            {
                GenerateFirstResult( results ); //If resultList is empty, then it will receive 5 different random numbers
                HasWinner( ticketsList, results );

                if ( results.isThereWinner == true ) //on the first attempt, it has a winning ticket, then return the result
                {
                    return results;
                }

            }

            return GenerateResults( ticketsList, results, maxAttempts ); //If the winning ticket is not found, then another number will be drawn recursively

        }

        private Result GenerateResults( List<Ticket> ticketList, Result results, int maxAttempts )
        {

            if ( maxAttempts == 0 ) //stop condition - when attempts ==0 
            {
                return results;
            }


            if ( results.isThereWinner != true && maxAttempts > 0 )
            {
                int numberDrawn = Utils.GenerateAnotherNumber( results.NumbersDrawn );

                results.NumbersDrawn.Add( numberDrawn );

            }

            return GenerateResults( ticketList, results, maxAttempts-1 );
        }


        public void GenerateFirstResult(Result results )
        {
            int randomNumber;
            bool isRepeated;
            results.NumbersDrawn = new List<int>();

            for ( int i = 0 ; i <= 4 ; i++ )
            {
                randomNumber = Utils.GenerateAnotherNumber( results.NumbersDrawn );
                results.NumbersDrawn.Add( randomNumber );
            }

            results.NumbersDrawn = results.NumbersDrawn.OrderBy( number => number ).ToList();

            //return results;
        }

        public Result HasWinner( List<Ticket> ticketsList, Result results )
        {

            bool hasSameNumbers;

            foreach ( Ticket ticket in ticketsList )
            {

                hasSameNumbers = ( ( ticket.SelectedNumbers ).Intersect( results.NumbersDrawn ).Count() == 5 );

                if ( hasSameNumbers == true )
                {
                    results.isThereWinner = true;
                    results.WinnerTicketId.Add( ticket.Id );

                }
            }
            results.isThereWinner = false;

            return results;

        }
    }
    
}
