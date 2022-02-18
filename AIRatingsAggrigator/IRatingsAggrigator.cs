using AIDataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRatingsAggrigator
{
    public interface IRatingsAggrigator
    {
        Dictionary<int, List<int>> Aggrigate(BookDetails bookDetails, Preference preference);
    }
}
