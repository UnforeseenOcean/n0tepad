using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GlitchText
{
    public partial class TextTranslate : System.Web.UI.Page
    {
        string dotPath = HttpContext.Current.Server.MapPath(@"dot_yawn.gif");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ResetText();
                DrawImage();
            }
        }

        protected void ResetData_Click(Object sender, EventArgs e)
        {
            ResetText();
            DrawImage();
        }

        protected void DrawPicture_Click(Object sender, EventArgs e)
        {
            DrawImage();
        }

        private void DrawImage()
        {
            Session["currPicture"] = databox.Text;
            resultImage.ImageUrl = "~/ImageOutput.aspx";
        }

        private void ResetText()
        {
            Converter converter = new Converter();
            databox.Text = converter.EncodeWithStringUnicode(dotPath);
        }
    }
}