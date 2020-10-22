using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Traveller_Application
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BelieveIPM" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BelieveIPM.svc or BelieveIPM.svc.cs at the Solution Explorer and start debugging.
    public class BelieveIPM : IBelieveIPM
    {
        TravelDataDataContext data = new TravelDataDataContext();
        public bool AddBelieve(Believe believe)
        {
            try
            {
                data.Believes.InsertOnSubmit(believe);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBelieve(int id)
        {
            try
            {
                Believe be = (from Believe in data.Believes
                                     where Believe.ID_LoaiTin == id
                                     select Believe).Single();

                data.Believes.DeleteOnSubmit(be);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Believe> GetBelieves()
        {
            try
            {
                return (from Believe in data.Believes select Believe).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateBelieve(Believe believe)
        {
            try
            {
                var b = (from Believe in data.Believes
                         where Believe.ID_Tin == believe.ID_Tin
                         select Believe).Single();
                b.ID_Tin = believe.ID_Tin;
                b.TieuDe = believe.TieuDe;
                b.NgayDang = believe.NgayDang;
                b.URL_Hinh = believe.URL_Hinh;
                b.Ngay = believe.Ngay;
                b.NoiDung = believe.NoiDung;
                b.ID_LoaiTin = believe.ID_LoaiTin;
                b.SoLanXem = believe.SoLanXem;
                b.TinNoiBat = believe.TinNoiBat;

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
