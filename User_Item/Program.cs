using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Item {
    class Program {

        public static readonly int[] ARTICLES = { 101, 102, 103, 104, 105, 106 };

        private static Dictionary<int, Vector> vectors;
        static void Main(string[] args) {
            vectors = DataParser.DataToVectors(DataParser.ParseData());
            PrettyPrint();

            UserItemRunner runner = new UserItemRunner(new PearsonCoefficient());
            Console.WriteLine();
            Console.WriteLine("Similarity: {0}", runner.Run(vectors[1], vectors[2]));
            

            Console.Read();
        }

        public static void PrettyPrint() {
            for (int i = 1; i <= vectors.Count; i++) {
                Console.WriteLine("{0} {1}", i, vectors[i].ToString());
            }
        }
    }
}
