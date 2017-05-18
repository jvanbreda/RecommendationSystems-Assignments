using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Item {
    class Program {

        public static readonly string TEST_DATA = "../../testData.data";
        public static readonly string USER_DATA = "../../userItem.data";
        public static readonly string MOVIELENS_DATA = "../../u.data";

        private static Predictor predictor;

        static void Main(string[] args) {
            predictor = new Predictor(new PearsonCoefficient());

            int k = 3;
            float threshold = 0.35f;

            //Dictionary<int, Vector> vectors = DataParser.DataToVectors(DataParser.ParseData(TEST_DATA));
            //PrettyPrint(vectors);
            //Console.WriteLine();

            //Console.WriteLine("Euclidean: {0}", new EuclideanSimilarity().CalculateSimilarity(vectors[1], vectors[2]));
            //Console.WriteLine("Manhattan: {0}", new ManhattanSimilary().CalculateSimilarity(vectors[1], vectors[2]));
            //Console.WriteLine("Pearson: {0}", new PearsonCoefficient().CalculateSimilarity(vectors[1], vectors[2]));
            //Console.WriteLine("Cosine: {0}", new CosineSimilarity().CalculateSimilarity(vectors[1], vectors[2]));

            //Console.Read();

            //Dictionary<int, Vector> vectors = DataParser.DataToVectors(DataParser.ParseData(USER_DATA));
            //PrettyPrint(vectors);
            //Console.WriteLine();

            //int targetUser = 7;
            //int[] idsToPredict = new int[] { 101, 103 };

            //List<ArticleRating> results = predictor.PredictRatings(targetUser, k, threshold, vectors, idsToPredict);
            //PrettyPrint(targetUser, results);

            //Console.WriteLine();

            //int targetUser = 4;
            //int[] idsToPredict = new int[] { 101 };

            //List<ArticleRating> results = predictor.PredictRatings(targetUser, k, threshold, vectors, idsToPredict);
            //PrettyPrint(targetUser, results);

            Dictionary<int, Vector> vectors = DataParser.DataToVectors(DataParser.ParseData(MOVIELENS_DATA));
            int targetUser = 186;
            int n = 8;

            List<ArticleRating> topNratings = predictor.GetTopNpredictions(n, predictor.PredictRatings(targetUser, k, threshold, vectors, DataParser.ids.ToArray()));
            PrettyPrint(targetUser, topNratings);

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
