using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Item {
    abstract class DistanceBasedSimilarity: ISimilarityCalculator {
        public abstract float CalculateSimilarity(Vector v1, Vector v2);

        protected float DistanceToSimilarity(float distance) {
            return 1 / (1 + distance);
        }

    }
}
