using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Traveller_Application
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomerIPM" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomerIPM.svc or CustomerIPM.svc.cs at the Solution Explorer and start debugging.
    public class CustomerIPM : ICustomerIPM
    {
        TravelDataDataContext data = new TravelDataDataContext();

        public bool AddCustomer(Customer customer)
        {
            try
            {
                data.Customers.InsertOnSubmit(customer);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }



        public bool DeleteCustomer(int id)
        {
            try
            {
                Customer cus = (from Customer in data.Customers
                                where Customer.MaKH == id
                                select Customer).Single();

                data.Customers.DeleteOnSubmit(cus);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Customer> GetCustomers()
        {
            try
            {
                return (from Customer in data.Customers select Customer).ToList();
            }
            catch
            {
                return null;
            }


            //throw new NotImplementedException();
        }

        public bool UpdateCustomer(Customer customer)
        {

            try
            {
                var cus = (from Customer in data.Customers
                           where Customer.MaKH == customer.MaKH
                           select Customer).Single();
                cus.MaKH = customer.MaKH;
                cus.TenKH = customer.TenKH;
                cus.TenDangNhap = customer.TenDangNhap;
                cus.NgaySinh = customer.NgaySinh;
                cus.GioiTinh = customer.GioiTinh;
                cus.DiaChi = customer.DiaChi;
                cus.DienThoai = customer.DienThoai;
                cus.Email = customer.Email;
                cus.TourBookings = customer.TourBookings;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
            //throw new NotImplementedException();
        }
    }

}

