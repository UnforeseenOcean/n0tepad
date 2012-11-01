<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="SampleImages.aspx.cs" Inherits="GlitchText.SampleImages" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h3>Some sample images</h3>

    <br />
    <a href="./">back to n0tepad</a>
    <br /><br /><br /><br />

    <table border="0">
    <tr>
        <td>
            Before
        </td>
        <td>
            After
        </td>
    </tr>
    <tr>
        <td><!-- a href="sample_images/collage.jpg"--><img src="sample_images/collage_small.jpg" width="400" height="389" /><!--/a--></td>
        <td><!-- a href="sample_images/collage_after.jpg"--><img src="sample_images/collage_after_small.jpg" width="400" height="389" /><!--/a--></td>
    </tr>
    <tr>
        <td><!-- a href="sample_images/BR00.jpg"--><img src="sample_images/BR00_small.jpg" width="400" height="300" /><!--/a--></td>
        <td><!-- a href="sample_images/brImageOutput08.jpg"--><img src="sample_images/brImageOutput08_small.jpg" width="400" height="300" /><!--/a--></td>
    </tr>
    <tr>
        <td><!-- a href="sample_images/fire_small.jpg"--><img src="sample_images/fire_smaller.jpg" width="400" height="266" /><!--/a--></td>
        <td><!-- a href="sample_images/fire_after_full.jpg"--><img src="sample_images/fire_after_full_small.jpg" width="400" height="266" /><!--/a--></td>
    </tr>
    </table>
</asp:Content>
