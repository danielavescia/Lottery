using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Sockets;
using webapi.Models.Domain;

namespace webapi.Data
{
    public class DataPersistance
    {

        public List<Ticket> LotteryTickets { get; set; }
        public Result LotteryResults { get; set; }

        public DataPersistance( List<Ticket> LotteryTickets, Result LotteryResults )
        {
            this.LotteryTickets = LotteryTickets;
            this.LotteryResults = LotteryResults;
        }

        public async Task<List<Ticket>> ReadTicketsFromJson()
        {
            string fileName = "ticket.json";
            string path = Path.Combine( Environment.CurrentDirectory, @"Data\", fileName );

            if ( !File.Exists( path ) ) //verifies if the file exists in the path
            {
                throw new Exception( "Ticket File not found!!" );
            }

            else
            {
                using FileStream fileStream = new( path, FileMode.Open );
                using StreamReader reader = new( fileStream );
                {
                    var json = await reader.ReadToEndAsync();
                    return JsonConvert.DeserializeObject<List<Ticket>>( json ); //Deserializes the JSON to a Ticket List.
                }
                
            }
        }
        public async Task<List<Result>> ReadResultsFromJson()
        {
            string fileName = "result.json";
            string path = Path.Combine( Environment.CurrentDirectory, @"Data\", fileName );

            if ( !File.Exists( path ) ) //verifies if the file exists in the path
            {
                throw new Exception( "Result File not found!!" );
            }

            else
            {
                using FileStream fileStream = new( path, FileMode.Open );
                using StreamReader reader = new( fileStream );
                {
                    var json = await reader.ReadToEndAsync();
                    return JsonConvert.DeserializeObject<List<Result>>( json ); //Deserializes the JSON to a Result List.
                }

            }
        }

        public async void WriteTicketsToJson(List<Ticket> tickets)
        {
            string fileName = "ticket.json";
            string path = Path.Combine( Environment.CurrentDirectory, @"Data\", fileName );

            if ( !File.Exists( path ) ) //verifies if the file exists in the path
            {
                throw new Exception( "Ticket File not found!!" );
            }

            else
            {
                using StreamWriter file = File.CreateText( path );
                JsonSerializer serializer = new();
                serializer.Serialize( file, tickets ); //serializes the Ticket List into JSON file.

            }
        }

        public async void WriteResultsToJson( Result results )
        {
            string fileName = "result.json";
            string path = Path.Combine( Environment.CurrentDirectory, @"Data\", fileName );

            if ( !File.Exists( path ) ) //verifies if the file exists in the path
            {
                throw new Exception( "Result File not found!!" );
            }

            else
            {
                using StreamWriter file = File.CreateText( path );
                JsonSerializer serializer = new ();
                serializer.Serialize( file, results ); //serializes the Result List into JSON file.

            }
        }

    }
}
