using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class PlaceDao
    {
        Assignment_WebServiceEntities db = null;
        public PlaceDao()
        {
            db = new Assignment_WebServiceEntities();
        }
        public List<Image> GetPlaces()
        {
            var list = (from image in db.Images select image).ToList();
            var result = new List<Image>();
            list.ForEach(b => result.Add(new Image()
            {
                Image1 = b.Image1
            }));
            return list;
        }
    }
}
