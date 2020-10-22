using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Traveller_Application
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITuorIPM" in both code and config file together.
    [ServiceContract]
    public interface ITuorIPM
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/v1/GetTour")]

        List<Tour> GetTours();

        [OperationContract]
        [WebInvoke(Method = "POST",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Bare,
          UriTemplate = "api/v1/CreateTour")]

        bool AddTour(Tour tour);

        // sửa
        [OperationContract]
        [WebInvoke(Method = "PUT",
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "api/v1/EditTour")]

        bool UpdateTour(Tour tour);

        // xóa
        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/v1/DeleteTour")]

        bool DeleteTour(int id);
    }
}
