using Item_Item.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_Item {
    class Calculator {

        public static DeviationModel ComputeDeviation(Dictionary<int, Vector> userRatings, int item1, int item2) {
            float numerator = 0;
            int denominator = 0;
            for (int i = 1; i <= userRatings.Count; i++) {
                float? item1Rating = userRatings[i].ArticleRatings.FirstOrDefault(x => x.ArticleId == item1).Rating;
                float? item2Rating = userRatings[i].ArticleRatings.FirstOrDefault(x => x.ArticleId == item2).Rating;

                if(!(item1Rating == null || item2Rating == null)) {
                    numerator += ((float)item1Rating - (float)item2Rating);
                    denominator++;
                }
            }

            return new DeviationModel(numerator / denominator, denominator);
        }

    }
}
