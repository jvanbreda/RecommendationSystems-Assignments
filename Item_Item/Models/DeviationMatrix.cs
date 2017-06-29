using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_Item.Models {
    class DeviationMatrix {
        public static DeviationModel[,] GetMatrix(Dictionary<int, Vector> userRatings) {
            int m = userRatings.First().Value.ArticleRatings.Length;

            DeviationModel[,] table = new DeviationModel[m, m];
            for (int i = 0; i < m; i++) {
                for (int j = 0; j < m; j++) {
                    if (i == j)
                        table[i, j] = new DeviationModel(0, 0);
                    else if (table[j, i] != null) {
                        DeviationModel d = table[j, i];
                        table[i, j] = new DeviationModel(-d.Deviation, d.NumberOfRatingsForBoth);
                    }
                    else
                        table[i, j] = Calculator.ComputeDeviation(userRatings, DataParser.ids[i], DataParser.ids[j]);

                    Console.WriteLine("{0},{1}", i, j);
                }
            }
            return table;
        }

    }
}
