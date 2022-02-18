using AIDataLoader;
using AIRatingsAggrigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationClientApp
{
    public  class Program
    {
        static void Main(string[] args)
        {
            AIRecommendationEngine.AIRecommendationApp app = new AIRecommendationEngine.AIRecommendationApp();
            Preference preference = new Preference { ISBN = 1234567, Age = 25, State = "LA" };
            List<Book> recommendedBooks = app.Recommend(preference, 10);

            foreach (Book book in recommendedBooks)
            {
                Console.WriteLine(book.BookTitle);
            }

        }
    }
}
