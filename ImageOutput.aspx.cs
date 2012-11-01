// #define _DOTRACE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GlitchText
{
    public partial class ImageOutput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
/*            Response.Expires = -1;
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.CacheControl = "no-cache";
            Response.Cache.SetNoStore();
            */
            if (!Page.IsPostBack)
            {
#if _DOTRACE
                System.Diagnostics.Trace.Write(DateTime.Now.ToString() + ": ");
                System.Diagnostics.Trace.WriteLine("entering ImageOutput.aspx Page_Load");
                System.Diagnostics.Trace.Flush();
#endif
                Converter converter = new Converter();
                ImageFormat outputFormat = null;

                switch (Request.QueryString["ex"])
                {
                    case "jpeg":
                        Response.ContentType = "image/jpeg";
                        outputFormat = ImageFormat.Jpeg;
                        break;
                    case "gif":
                        Response.ContentType = "image/gif";
                        outputFormat = ImageFormat.Gif;
                        break;
                    case "png":
                        Response.ContentType = "image/png";
                        outputFormat = ImageFormat.Png;
                        break;
                }

                try
                {
                    converter.DecodeFromStringUnicode(Session["currPicture"].ToString()).Save(Response.OutputStream, outputFormat);
#if _DOTRACE
                    System.Diagnostics.Trace.Write(DateTime.Now.ToString() + ": ");
                    System.Diagnostics.Trace.WriteLine("completed ImageOutput.aspx Page_Load");
                    System.Diagnostics.Trace.Flush();
#endif
                }
                catch (ArgumentException ex)
                {
                    Response.Redirect("FailImage.GIF");
                }
                catch (System.Runtime.InteropServices.ExternalException ex)
                {
                    Response.Redirect("FailImage.GIF");
                }
            }
        }
    }
}