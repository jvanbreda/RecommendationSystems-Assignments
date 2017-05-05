using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Item {
    class Program {
        static void Main(string[] args) {
            Dictionary<int, Dictionary<int, float>> ratingData = DataParser.ParseData();
            Console.WriteLine();
        }
    }
}
