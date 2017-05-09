using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Item {
    class UserItemRunner {

        private ISimilarityCalculator similarityCalculator;
        public UserItemRunner(ISimilarityCalculator similarityCalculator) {
            this.similarityCalculator = similarityCalculator;
        }

        public float CalculateSimilarity(Vector v1, Vector v2) {
            return similarityCalculator.CalculateSimilarity(v1, v2);
        }
    }
}
