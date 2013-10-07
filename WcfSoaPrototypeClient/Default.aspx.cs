using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WcfSoaPrototypeClient.ServiceReference1;

namespace WcfSoaPrototypeClient
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();
            Response.Write(client.GetData(4));
        }
    }
}