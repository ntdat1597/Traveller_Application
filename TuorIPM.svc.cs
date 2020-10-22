using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Traveller_Application
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TuorIPM" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TuorIPM.svc or TuorIPM.svc.cs at the Solution Explorer and start debugging.
    public class TuorIPM : ITuorIPM
    {
        TravelDataDataContext data = new TravelDataDataContext();
        public bool AddTour(Tour tour)
        {
            try
            {
                data.Tours.InsertOnSubmit(tour);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteTour(int id)
        {
            try
            {
                Tour tour = (from Tour in data.Tours
                                      where Tour.MaTour == id
                                      select Tour).Single();

                data.Tours.DeleteOnSubmit(tour);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Tour> GetTours()
        {
            try
            {
                return (from Tour in data.Tours select Tour).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateTour(Tour tour)
        {
            try
            {
                var t = (from Tour in data.Tours
                           where Tour.MaTour == tour.MaTour
                           select Tour).Single();
                t.MaTour = tour.MaTour;
                t.TenTour = tour.TenTour;
                t.DonViTinh = tour.DonViTinh;
                t.NgayKhoiHanh = tour.NgayKhoiHanh;
                t.NgayKetThuc = tour.NgayKetThuc;
                t.SoNgay = tour.SoNgay;
                t.SoDem = tour.SoDem;
                t.NoiDung = tour.NoiDung;
                t.HinhAnh = tour.HinhAnh;
                t.KhuyenMai = tour.KhuyenMai;
                t.TourHot = tour.TourHot;
                t.MaTinh = tour.MaTinh;
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
