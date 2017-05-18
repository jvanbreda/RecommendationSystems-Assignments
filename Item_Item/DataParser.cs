using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_Item {
    class DataParser {

        public static List<int> ids = new List<int>();

        public static Dictionary<int, Dictionary<int, float>> ParseData(string filePath) {
            Dictionary<int, Dictionary<int, float>> ratingData = new Dictionary<int, Dictionary<int, float>>();
            using (var fs = File.OpenRead(filePath)) {
                using (var streamReader = new StreamReader(fs)) {
                    while (!streamReader.EndOfStream) {
                        string line = streamReader.ReadLine();
                        string[] values = line.Split(new[] { ',', ' ', '\t' });
                        if (!ratingData.ContainsKey(int.Parse(values[0]))) {
                            Dictionary<int, float> articleRate = new Dictionary<int, float>();
                            articleRate.Add(int.Parse(values[1]), float.Parse(values[2]));
                            ratingData.Add(int.Parse(values[0]), articleRate);
                        }
                        else {
                            ratingData[int.Parse(values[0])].Add(int.Parse(values[1]), float.Parse(values[2]));
                        }

                        if (!ids.Contains(int.Parse(values[1])))
                            ids.Add(int.Parse(values[1]));
                    }
                }
            }

            ids = ids.OrderBy(x => x).ToList();

            return ratingData;
        }

        public static Dictionary<int, Vector> DataToVectors(Dictionary<int, Dictionary<int, float>> ratingData) {
            Dictionary<int, Vector> vectorDictionary = new Dictionary<int, Vector>();
            for (int i = 1; i <= ratingData.Count; i++) {
                List<ArticleRating> ratings = new List<ArticleRating>();
                for (int j = 0; j < ids.Count; j++) {
                    if (!ratingData[i].ContainsKey(ids[j])) {
                        ratings.Add(new ArticleRating(ids[j], null));
                    }
                    else {
                        ratings.Add(new ArticleRating(ids[j], ratingData[i][ids[j]]));
                    }
                }
                vectorDictionary.Add(i, new Vector(ratings.OrderBy(x => x.ArticleId).ToArray()));
            }

            return vectorDictionary;
        } 
    }
}
