namespace webapi.Data
{
    public class JsonCleaner
    {

        public static void JsonCleanerFiles()
        {
            string fileName1 = "ticket.json";
            string fileName2 = "result.json";
            string filePathTicket = Path.Combine( Environment.CurrentDirectory, @"Data\", fileName1 );
            string filePathResult = Path.Combine( Environment.CurrentDirectory, @"Data\", fileName2 );


            File.WriteAllText( filePathTicket, "[]" );
            File.WriteAllText( filePathResult, "[]" );
        }
    }
}
