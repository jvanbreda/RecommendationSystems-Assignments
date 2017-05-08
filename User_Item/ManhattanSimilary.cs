﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Item {
    class ManhattanSimilary: DistanceBasedSimilarity {
        public override float CalculateSimilarity(Vector v1, Vector v2) {
            float distance = ManHattanDistance(v1, v2);
            return DistanceToSimilarity(distance);
        }

        public float ManHattanDistance(Vector v1, Vector v2) {
            float distance = 0;
            for (int i = 0; i < v1.ArticleRatings.Length; i++) {
                if (v1.ArticleRatings[i].Rating != null && v2.ArticleRatings[i].Rating != null)
                    distance += Math.Abs((float) v1.ArticleRatings[i].Rating - (float) v2.ArticleRatings[i].Rating);
            }

            return distance;
        }
    }
}
