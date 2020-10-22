using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Traveller_Application
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdminIPM" in both code and config file together.
    [ServiceContract]
    public interface IAdminIPM
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/v1/GetAdminIPMList")]

        List<Administration> GetAdministrations();


        //thêm
        [OperationContract]
        [WebInvoke(Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "api/v1/CreateAdministration")]

        bool AddAdministration(Administration administration);

        // sửa
        [OperationContract]
        [WebInvoke(Method = "PUT",
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "api/v1/EditAdministration")]

        bool UpdateAdministration(Administration administration);

        // xóa
        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "api/v1/DeleteAdministration")]

        bool DeleteAdministration(int id);
    }
}
