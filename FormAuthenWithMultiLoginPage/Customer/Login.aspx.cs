using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormAuthenWithMultiLoginPage.Customer
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userData = "Customer";
            string userName = "guest";

            // initialize FormsAuthentication
            FormsAuthentication.Initialize();

            // create a new ticket used for authentication
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);

            // encrypt the cookie using the machine key for secure transport
            string encTicket = FormsAuthentication.Encrypt(authTicket);

            // create and add the cookies to the list for outgoing response
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

            Response.Cookies.Add(faCookie);

            Response.Redirect("/Customer/Default.aspx");
        }
    }
}