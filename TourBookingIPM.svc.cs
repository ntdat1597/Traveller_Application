using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Traveller_Application
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TourBookingIPM" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TourBookingIPM.svc or TourBookingIPM.svc.cs at the Solution Explorer and start debugging.
    public class TourBookingIPM : ITourBookingIPM
    {

        TravelDataDataContext data = new TravelDataDataContext();
        public bool AddTourBooking(TourBooking booking)
        {
            try
            {
                data.TourBookings.InsertOnSubmit(booking);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteTourBooking(int id)
        {
            try
            {
                TourBooking tourB = (from TourBooking in data.TourBookings
                                     where TourBooking.MaDatTour == id
                                     select TourBooking).Single();

                data.TourBookings.DeleteOnSubmit(tourB);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TourBooking> GetTourBookings()
        {
            try
            {
                return (from TourBooking in data.TourBookings select TourBooking).ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateTourBooking(TourBooking booking)
        {
            try
            {
                var t = (from TourBooking in data.TourBookings
                         where TourBooking.MaDatTour == booking.MaDatTour
                         select TourBooking).Single();
                t.MaDatTour = booking.MaDatTour;
                t.MaKH = booking.MaKH;
                t.MaTour = booking.MaTour;
                t.DonGia = booking.DonGia;
                t.SoLuong = booking.SoLuong;
                t.ThanhTien = booking.ThanhTien;
                t.DatThanhToan = booking.DatThanhToan;
                t.Tour = booking.Tour;
                t.Customer = booking.Customer;

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
    

