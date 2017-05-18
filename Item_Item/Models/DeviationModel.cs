using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_Item.Models {
    class DeviationModel {

        public float Deviation { get; set; }
        public int NumberOfRatingsForBoth { get; set; }

        public DeviationModel(float deviation, int numberOfRatingsForBoth) {
            Deviation = deviation;
            NumberOfRatingsForBoth = numberOfRatingsForBoth;
        }

        public static DeviationModel[,] GetDeviationTable(Dictionary<int, Vector> userRatings) {
            int m = userRatings.First().Value.ArticleRatings.Length;
            int n = userRatings.First().Value.ArticleRatings.Length;

            DeviationModel[,] table = new DeviationModel[m,n];
            for (int i = 0; i < m; i++) {
                for (int j = 0; j < n; j++) {
                    if (i == j)
                        table[i, j] = new DeviationModel(0, 0);
                    else
                        table[i, j] = Calculator.ComputeDeviation(userRatings, DataParser.ids[i], DataParser.ids[j]);                    
                }
            }

            return table;
        }
    }
}
