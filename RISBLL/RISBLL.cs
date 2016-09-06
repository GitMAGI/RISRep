using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial class RISBLL : IBLL.IRISBLL
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IDAL.IRISDAL dal;

        public RISBLL(IDAL.IRISDAL IDAL)
        {
            this.dal = IDAL;
        }

    }
}
