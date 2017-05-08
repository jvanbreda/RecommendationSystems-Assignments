using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Item {
    class Vector {
        public ArticleRating[] ArticleRatings { get; private set; }

        public Vector(params ArticleRating[] articleRatings) {
            ArticleRatings = articleRatings;
        }

        public float Dot(Vector other) {
            float dotProduct = 0;
            for (int i = 0; i < ArticleRatings.Length; i++) {
                if(ArticleRatings[i].Rating != null && other.ArticleRatings[i].Rating != null)
                    dotProduct += (float) ArticleRatings[i].Rating * (float) other.ArticleRatings[i].Rating;
            }

            return dotProduct;
        }

        public float Length() {
            float length = 0;
            for (int i = 0; i < ArticleRatings.Length; i++) {
                if(ArticleRatings[i].Rating != null)
                    length += (float) Math.Pow( (float) ArticleRatings[i].Rating, 2);
            }

            return  (float) Math.Sqrt(length);
        }

        public override string ToString() {
            string resultString = "";
            for (int i = 0; i < ArticleRatings.Length; i++) {
                if (ArticleRatings[i].Rating != null)
                    resultString += ArticleRatings[i].Rating + "\t";
                else
                    resultString += "-\t";
            }

            return resultString;
        }

        public float PearsonCoefficient(Vector other) {
            return 0;
        }
    }
}
