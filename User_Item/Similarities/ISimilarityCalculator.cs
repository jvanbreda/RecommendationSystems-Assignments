using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Item {
    interface ISimilarityCalculator {

        float CalculateSimilarity(Vector v1, Vector v2);
    }
}
