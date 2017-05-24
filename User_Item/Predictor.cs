using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Item.Models;

namespace User_Item {
    class Predictor {

        private ISimilarityCalculator SimilarityCalculator;

        public Predictor(ISimilarityCalculator similarityCalcluator) {
            SimilarityCalculator = similarityCalcluator;
        }

        public List<ArticleRating> PredictRatings(int targetUser, int k, float threshold, Dictionary<int, Vector> dataSet, int[] articles) {
            List<Record> nearestNeighbors = Algorithms.NearestNeighbors(targetUser, dataSet, k, threshold, SimilarityCalculator);
            
            List<ArticleRating> predictions = new List<ArticleRating>();

            for (int i = 0; i < articles.Length; i++) {
                float weightedRating = 0;
                float totalSimilarity = 0;
                for (int j = 0; j < nearestNeighbors.Count; j++) {
                    if (nearestNeighbors[j].V.ArticleRatings[DataParser.ids.IndexOf(articles[i])].Rating != null) {
                        weightedRating += nearestNeighbors[j].Similarity * (float)nearestNeighbors[j].V.ArticleRatings[DataParser.ids.IndexOf(articles[i])].Rating;
                        totalSimilarity += nearestNeighbors[j].Similarity;
                    }
                }

                float predictedRating = weightedRating / totalSimilarity;

                ArticleRating ar = new ArticleRating(articles[i], predictedRating);
                predictions.Add(ar);
            }

            return predictions;
        }

        public List<ArticleRating> GetTopNpredictions(int n, List<ArticleRating> allPredictions) {
            allPredictions = allPredictions.OrderByDescending(x => x.Rating).ToList();
            return allPredictions.Take(n).ToList();
        }
    }
}
