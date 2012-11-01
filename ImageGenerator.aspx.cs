using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GlitchText
{
    /// <summary>
    /// This is the holder for the image. I didn't name it "imageHolder" b/c that'd look dumb in the URL
    /// </summary>
    public partial class ImageGenerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = -1;
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.CacheControl = "no-cache";
            Response.Cache.SetNoStore();

        }
    }
}