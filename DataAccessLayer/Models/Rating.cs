using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    class Rating
    {
        
        public int RatingId { get; set; }
        public int SupplierId { get; set; }
        public DateTime RatedOn { get; set; }
        public int RateByUserId { get; set; }
        public int CategoryId { get; set; }
        public int RatingValue { get; set; }
    }
}
