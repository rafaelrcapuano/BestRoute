using System.Collections.Generic;
using System.Linq;

namespace BestRoute.Domain
{
    public class TravelModel
    {
        public TravelModel()
        {
            Routes = new List<RouteModel>();
        }

        public IList<RouteModel> Routes { get; set; }

        public double TotalDistance
        {
            get
            {
                return Routes.Sum(s => s.Distance);
            }
        }
    }
}