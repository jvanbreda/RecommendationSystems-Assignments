using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Item {
    class Vector {
        private float[] ratings;

        public Vector(params float[] ratings) {
            this.ratings = ratings;
        }

        private float Dot(Vector other) {
            float dotProduct = 0;
            for (int i = 0; i < ratings.Length; i++) {
                dotProduct += ratings[i] * other.ratings[i];
            }

            return dotProduct;
        }

        public override string ToString() {
            string resultString = "";
            for (int i = 0; i < ratings.Length; i++) {
                resultString += ratings[i] + "\t";
            }

            return resultString;
        }

        public float EuclideanDistance(Vector other) {
            float distance = 0;
            for (int i = 0; i < ratings.Length; i++) {
                distance += (float) Math.Pow(ratings[i] - other.ratings[i], 2);
            }

            return (float) Math.Sqrt(distance);
        }

        public float ManHattanDistance(Vector other) {
            float distance = 0;
            for (int i = 0; i < ratings.Length; i++) {
                distance += Math.Abs(ratings[i] - other.ratings[i]);
            }

            return distance;
        }

        public float PearsonCoefficient(Vector other) {
            return 0;
        }

        public float Cosine(Vector other) {
            float dotProduct = 0;
            float lengthThis = 0;
            float lengthOther = 0;
        }

        public static float DistanceToSimilarity(float distance) {
            return 1 / (1 + distance);
        }
    }
}
