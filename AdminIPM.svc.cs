using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Traveller_Application
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminIPM" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdminIPM.svc or AdminIPM.svc.cs at the Solution Explorer and start debugging.
    public class AdminIPM : IAdminIPM
    {
        TravelDataDataContext data = new TravelDataDataContext();

        public bool AddAdministration(Administration administration)
        {
            try
            {
                data.Administrations.InsertOnSubmit(administration);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
            //throw new NotImplementedException();
        }

        public bool DeleteAdministration(int id)
        {
            try
            {
                Administration adm = (from Administration in data.Administrations
                                where Administration.ID_QuanTri == id
                                select Administration).Single();

                data.Administrations.DeleteOnSubmit(adm);
                return true;
            }
            catch
            {
                return false;
            }
            //throw new NotImplementedException();
        }

        public List<Administration> GetAdministrations()
        {
            try
            {
                return (from Administration in data.Administrations select Administration).ToList();

            }
            catch
            {
                return null;
            }
            
        }

        public bool UpdateAdministration(Administration administration)
        {          
                try
                {
                    var adm = (from Administration in data.Administrations
                               where Administration.ID_QuanTri == administration.ID_QuanTri
                               select Administration).Single();
                    adm.ID_QuanTri = administration.ID_QuanTri;
                    adm.UsreName = administration.UsreName;
                    adm.Pass_Word = administration.Pass_Word;                   
                    data.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
           
        }
    }
}
