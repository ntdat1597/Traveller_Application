using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Traveller_Application
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITourBookingIPM" in both code and config file together.
    [ServiceContract]
    public interface ITourBookingIPM
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/v1/GetTourBooking")]

        List<TourBooking> GetTourBookings();


        [OperationContract]
        [WebInvoke(Method = "POST",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "api/v1/CreateTourBooking")]

        bool AddTourBooking(TourBooking booking);

        // sửa
        [OperationContract]
        [WebInvoke(Method = "PUT",
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "api/v1/EditTourBooking")]

        bool UpdateTourBooking(TourBooking booking);

        // xóa
        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/v1/DeleteTourBooking")]

        bool DeleteTourBooking(int id);
    }
}
