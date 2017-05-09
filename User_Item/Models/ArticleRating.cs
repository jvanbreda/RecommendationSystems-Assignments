using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Item {
    class ArticleRating {

        public int ArticleId { get; private set; }
        public float? Rating { get; private set; }

        public ArticleRating(int articleId, float? rating) {
            ArticleId = articleId;
            Rating = rating;
        }
    }
}
