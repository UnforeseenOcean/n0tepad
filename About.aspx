<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="GlitchText.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h3>
        About
    </h3>
    <p>
        Notepad technology deployed to the Web.
        <br /><br />
        This program performs one of the fundamental glitch techniques: the direct manipulation
        of image data using a text editor. Created to encourage DIY experimentation in glitch.
        If you like how this works, try it with whatever hex or (binary / unicode capable) text 
        editor.
        <br /><br />
        Released under <a href="http://www.gnu.org/licenses/gpl-3.0.html">GNU GPL 3.0</a>. Project is <a href="https://github.com/rottytooth/n0tepad">on github here</a>.
        <br /><br />
        <a href="/Tutorials">Tutorials for other glitch techniques here.</a>
    </p>
    <br /><br />
    <p>
        Created by <a href="http://notendo.com">Jeff Donaldson</a> and <a href="http://danieltemkin.com">Daniel Temkin</a>
    </p>
    <p>
        See <a href="SampleImages.aspx">Sample Images</a>
    </p>
</asp:Content>
