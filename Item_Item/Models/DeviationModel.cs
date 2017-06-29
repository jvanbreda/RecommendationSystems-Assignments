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
    }
}
