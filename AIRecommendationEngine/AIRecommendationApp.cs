using AIDataLoader;
using AIRatingsAggrigator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine
{
    public class AIRecommendationApp
    {
        public List<Book> Recommend(Preference preference, int limit)
        {
            List<Book> recommendedBooksList = new List<Book>();
            // get the data from data loader
            // get the aggrigated data from aggrigator
            // get the coffiecient factor from perason engine
            // get the recommended books and return
            return recommendedBooksList;
        }
    }
}
