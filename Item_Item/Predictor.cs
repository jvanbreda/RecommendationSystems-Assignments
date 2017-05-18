using Item_Item.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_Item {
    class Predictor {

        public static List<ArticleRating> PredictRatings(Dictionary<int, Vector> userRatings, DeviationModel[,] table, int targetUser, int[] idsToPredict) {
            List<ArticleRating> predictions = new List<ArticleRating>();

            for (int i = 0; i < idsToPredict.Length; i++) {
                float numerator = 0;
                float denominator = 0;
                for (int j = 0; j < userRatings[targetUser].ArticleRatings.Length; j++) {
                    ArticleRating articleRating = userRatings[targetUser].ArticleRatings.FirstOrDefault(x => x.ArticleId == DataParser.ids[j]);
                    if (articleRating.Rating != null) {
                        DeviationModel model = table[DataParser.ids.IndexOf(idsToPredict[i]), DataParser.ids.IndexOf(articleRating.ArticleId)];
                        numerator += ((float)articleRating.Rating + model.Deviation) * model.NumberOfRatingsForBoth;
                        denominator += model.NumberOfRatingsForBoth;
                    }
                }
                predictions.Add(new ArticleRating(idsToPredict[i], numerator / denominator));
            }

            return predictions;
        }
    }
}
