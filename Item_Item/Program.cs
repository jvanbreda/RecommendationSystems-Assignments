using Item_Item.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_Item {
    class Program {

        public static readonly string USER_DATA = "../../userItem.data";
        public static readonly string MOVIELENS_DATA = "../../u.data";

        static void Main(string[] args) {
            int targetUser = 7;
            int[] idsToPredict = new int[] { 101, 103, 106 };

            Dictionary<int, Vector> userRatings = DataParser.DataToVectors(DataParser.ParseData(USER_DATA));
            PrettyPrint(userRatings);
            Console.WriteLine();

            DeviationModel[,] deviations = DeviationModel.GetDeviationTable(userRatings);

            List<ArticleRating> predictedRatings = Predictor.PredictRatings(userRatings, deviations, targetUser, idsToPredict);

            PrettyPrint(targetUser, predictedRatings);

            Console.Read();
        }

        public static void PrettyPrint(Dictionary<int, Vector> vectors) {
            string headerString = "\t";
            for (int i = 0; i < DataParser.ids.Count; i++) {
                headerString += DataParser.ids[i] + "\t";
            }
            Console.WriteLine(headerString);

            for (int i = 1; i <= vectors.Count; i++) {
                Console.WriteLine("{0}\t{1}", i, vectors[i].ToString());
            }
        }

        private static void PrettyPrint(int targetUser, List<ArticleRating> result) {
            Console.WriteLine("User {0} predicted ratings:", targetUser);
            for (int i = 0; i < result.Count; i++) {
                Console.WriteLine("{0} - {1}", result[i].ArticleId, result[i].Rating);
            }
        }
    }
}
