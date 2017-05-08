using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Item {
    class PearsonCoefficient: ISimilarityCalculator {
        public float CalculateSimilarity(Vector v1, Vector v2) {
            float a = 0;
            float b1 = 0;
            float b2 = 0;
            float c = 0;
            float d = 0;

            float n = 0;

            for (int i = 0; i < v1.ArticleRatings.Length; i++) {
                if (v1.ArticleRatings[i].Rating != null && v2.ArticleRatings[i].Rating != null) {
                    a += (float) v1.ArticleRatings[i].Rating * (float) v2.ArticleRatings[i].Rating;
                    b1 += (float)v1.ArticleRatings[i].Rating;
                    b2 += (float)v2.ArticleRatings[i].Rating;
                    c += (float)Math.Pow((float)v1.ArticleRatings[i].Rating, 2);
                    d += (float)Math.Pow((float)v2.ArticleRatings[i].Rating, 2);
                    n++;
                }
            }

            return (a - (b1 * b2) / n) / ( (float) Math.Sqrt(c - (Math.Pow(b1, 2)) / n) * (float) Math.Sqrt(d - Math.Pow(b2, 2) / n));
        }
    }
}
