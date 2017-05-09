using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Item {
    class Program {

        public static readonly string USER_DATA = "../../userItem.data";
        public static readonly string MOVIELENS_DATA = "../../u.data";

        private static Predictor predictor;


        static void Main(string[] args) {
            predictor = new Predictor(new PearsonCoefficient());

            Dictionary<int, Vector> vectors = DataParser.DataToVectors(DataParser.ParseData(USER_DATA));
            PrettyPrint(vectors);
            Console.WriteLine();

            int k = 3;
            float threshold = 0.35f;

            int targetUser = 7;
            int[] articlesToPredict = new int[] { 101, 103, 106 };

            List<ArticleRating> results = predictor.PredictRatings(targetUser, k, threshold, vectors, articlesToPredict);
            PrettyPrint(targetUser, results);

            Console.WriteLine();

            targetUser = 4;
            articlesToPredict = new int[] { 101 };

            results = predictor.PredictRatings(targetUser, k, threshold, vectors, articlesToPredict);
            PrettyPrint(targetUser, results);

            //Dictionary<int, Vector> vectors = DataParser.DataToVectors(DataParser.ParseData(MOVIELENS_DATA));
            //PrettyPrint(vectors);

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
