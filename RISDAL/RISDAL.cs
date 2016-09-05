using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class RISDAL : IDAL.IRISDAL
    {
        public static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string HLTDesktopConnectionString = ConfigurationManager.ConnectionStrings["HltDesktop"].ConnectionString;      
        public ccDemo_devRISEntities hltCC = new ccDemo_devRISEntities();
        
    }
}
