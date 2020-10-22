using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Traveller_Application
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBelieveIPM" in both code and config file together.
    [ServiceContract]
    public interface IBelieveIPM
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/v1/GetBelieve")]

        List<Believe> GetBelieves();

        [OperationContract]
        [WebInvoke(Method = "POST",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "api/v1/CreateBelieve")]

        bool AddBelieve(Believe believe);

        // sửa
        [OperationContract]
        [WebInvoke(Method = "PUT",
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "api/v1/EditTourBooking")]

        bool UpdateBelieve(Believe believe);

        // xóa
        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/v1/DeleteBelieve")]

        bool DeleteBelieve(int id);
    }
}
