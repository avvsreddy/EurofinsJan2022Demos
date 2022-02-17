using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommandarCoreEngine
{
    public interface IRecommender
    {
        double GetCorellation(List<int> baseData, List<int> otherData);
    }
}
