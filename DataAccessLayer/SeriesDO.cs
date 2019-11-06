using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SeriesDO
    {
        public int SeriesID { get; set; }
        public string SeriesTitle { get; set; }
        public int AuthorID_FK { get; set; }
    }
}
