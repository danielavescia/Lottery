using webapi.Models.Domain;

namespace webapi.Services
{
    public class Utils
    {
        public static int  GenerateRandomNumber()
        {
            Random random = new ();
            int number;
           

            number = random.Next( 1, 51 ); // range 1-50
 
            return number;
        }

        public static bool NumberIsRepeated( List<int> numbersDrawn, int numberDrawan )   // ARRUMAR P/ PESQUISA BINÁRIA. SORTING ARRAY E DEPOIS PESQUISANDO POR RECURSÃO
        {
            if ( numbersDrawn ==null )
            {
                return false;
            }

            foreach ( int number in numbersDrawn )
            {
                if ( numberDrawan == number )
                {
                    return true;
                }
            }

            return false;
        }

        public static int GenerateAnotherNumber( List <int> numbersDrawn )
        {
            bool isRepeated;
            int numberDrawan;

            do
            {
                numberDrawan = GenerateRandomNumber();
                isRepeated = NumberIsRepeated( numbersDrawn, numberDrawan );

            } while ( isRepeated );

            return numberDrawan;
        }

        public static bool NumberIsSame( int [] numbersSelected, int []numbersDrawan )   //Verifies if the array has the same numbers
        {

            foreach ( int numberSelected in numbersSelected ) 
            {
                foreach ( int numberDrawan in numbersDrawan ) 
                {
                    if ( numberSelected == numberDrawan ) 
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
