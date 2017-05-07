using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Item {
    class DataParser {

        public static Dictionary<int, Dictionary<int, float>> ParseData() {
            Dictionary<int, Dictionary<int, float>> ratingData = new Dictionary<int, Dictionary<int, float>>();
            using (var fs = File.OpenRead("../../userItem.data")) {
                using (var streamReader = new StreamReader(fs)) {
                    while (!streamReader.EndOfStream) {
                        string line = streamReader.ReadLine();
                        string[] values = line.Split(',');
                        if (!ratingData.ContainsKey(int.Parse(values[0]))) {
                            Dictionary<int, float> articleRate = new Dictionary<int, float>();
                            articleRate.Add(int.Parse(values[1]), float.Parse(values[2]));
                            ratingData.Add(int.Parse(values[0]), articleRate);
                        }
                        else {
                            ratingData[int.Parse(values[0])].Add(int.Parse(values[1]), float.Parse(values[2]));
                        }
                    }
                }
            }
            return ratingData;
        }

        public static Dictionary<int, Vector> DataToVectors(Dictionary<int, Dictionary<int, float>> ratingData) {
            Dictionary<int, Vector> vectorDictionary = new Dictionary<int, Vector>();
            for (int i = 1; i <= ratingData.Count; i++) {
                List<float> ratings = new List<float>();
                for (int j = 0; j < Program.ARTICLES.Length; j++) {
                    if (!ratingData[i].ContainsKey(Program.ARTICLES[j])) {
                        ratings.Add(0);
                    }
                    else {
                        ratings.Add(ratingData[i][Program.ARTICLES[j]]);
                    }
                }
                vectorDictionary.Add(i, new Vector(ratings.ToArray()));
            }

            return vectorDictionary;
        } 
    }
}
