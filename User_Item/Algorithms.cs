using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Item.Models;

namespace User_Item {
    class Algorithms {

        private static UserItemRunner runner;

        public static List<Record> NearestNeighbors(int targetUser, Dictionary<int, Vector> dataSet, int k, float threshold, ISimilarityCalculator similarityCalculator) {
            runner = new UserItemRunner(similarityCalculator);
            List<Record> nearestNeighbors = new List<Record>();
            int n = 0;
            for (int i = 1; i <= dataSet.Count; i++) {
                if(i != targetUser) {
                    Record r = new Record(dataSet[i], runner.CalculateSimilarity(dataSet[i], dataSet[targetUser]));
                    if(r.Similarity > threshold) {
                        if(n < k) {
                            nearestNeighbors.Add(r);
                            n++;
                        }
                        else {
                            nearestNeighbors.Remove(nearestNeighbors.OrderBy(x => x.Similarity).First());
                            nearestNeighbors.Add(r);
                            threshold = nearestNeighbors.Min(x => x.Similarity);
                        }
                    }
                }
            }

            return nearestNeighbors;
        }
    }
}
