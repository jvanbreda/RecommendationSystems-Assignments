using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Item.Models {
    class Record {
        public Vector V { get; private set; }
        public float Similarity { get; private set; }

        public Record(Vector v, float similarity) {
            V = v;
            Similarity = similarity;
        }
    }
}
