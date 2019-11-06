using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BookDO
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public int SeriesID_FK { get; set;}
    }
}
