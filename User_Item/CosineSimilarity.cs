using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Item {
    class CosineSimilarity: ISimilarityCalculator {
        public float CalculateSimilarity(Vector v1, Vector v2) {
            return v1.Dot(v2) / (v1.Length() * v2.Length());
        }
    }
}
