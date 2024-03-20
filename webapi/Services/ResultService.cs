
using System.Collections.Generic;
using webapi.Data;
using webapi.Models.Domain;


namespace webapi.Services
{
    public class ResultService
    {
        private readonly DataPersistance dbContext; //An object of DataPersistance that simulates a dbContext
        private readonly List<Ticket> ticketsList;
        private readonly Result results;
        public ResultService( DataPersistance dbContext, List<Ticket> ticketList, Result results )
        {
            this.dbContext = dbContext;
            this.ticketsList = ticketsList;
            this.results = results;
        }

        public Result GenerateResults( List<Ticket> ticketsList )
        {
            int maxAttempts = 25;
            Result results = new();

            if ( ticketsList.Count == 0 )
            {
                throw new Exception( "Please, You need to bet first!" );
            }

            else if ( ticketsList != null & results.NumbersDrawn == null )
            {
                GenerateFirstResult( results ); //If resultList is empty, then it will receive 5 different random numbers
                HasWinner( ticketsList, results ); 

            }

            else if ( results.IsThereWinner == true )  //checks if there is a winner
            {
                return results;
            }

            return GenerateResults( ticketsList, results, maxAttempts ); //If the winning ticket is not found, then another number will be drawn recursively

        }

        private Result GenerateResults( List<Ticket> ticketList, Result results, int maxAttempts )
        {

            if ( maxAttempts == 0 ) //stop condition - when attempts ==0 
            {
                return results;
            }


            else if ( results.IsThereWinner == false && maxAttempts > 0 )  //if there isnt winner then generate another number and add to results.
            {
                int numberDrawn = Utils.GenerateAnotherNumber( results.NumbersDrawn ); //generate another number and add into results                                                                         
                results.NumbersDrawn.Add( numberDrawn );                               //then verifies if there is a winner after that
                HasWinner( ticketList,  results );

            }

            else if ( results.IsThereWinner == true )  //checks if there is a winner
            {
               
                return results;
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

        }

        public Result HasWinner( List<Ticket> ticketsList, Result results )  //verifies if there is a winner by the intersection
                                                                             //between equals numbers in ticket.SelectedNumbers andresults.NumbersDrawn
        {
            results.WinnerTicketId = new List<int>();
            bool hasSameNumbers;

            foreach ( Ticket ticket in ticketsList )
            {

                hasSameNumbers = ( ( ticket.SelectedNumbers ).Intersect( results.NumbersDrawn ).Count() == 5 );

                if ( hasSameNumbers == true ) //if 5 numbers are equal in both lists then change results attributes 
                {
                    int winnerId = ticket.Id;
                    results.IsThereWinner = true;
                    results.WinnerTicketId.Add( winnerId );

                }
                else 
                {
                    results.IsThereWinner = false;
                }
            }
           

            return results;

        }
    }

}
