<%@ Page Title="Edit Image" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="TextEditor.aspx.cs" Inherits="GlitchText._Default" validateRequest="false" %>
    
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css"">
    .wide {
    width: 100%;
    height: 100%;
    box-sizing: border-box;
    -moz-box-sizing: border-box;
    -webkit-box-sizing: border-box;
}

        #divLoading
        {
            color: #AA0000;
            font-size: 250%;
            position: absolute;
            left: 650px;
            top: 20px;
            visibility: hidden;
        }

    </style>
    <script language="javascript" type="text/javascript">
    function doResize() {
        var txt1 = document.getElementById('<%=databox.ClientID %>');
        txt1.style.height = (document.documentElement.clientHeight - 120) + 'px';

//        alert("resized to " + txt1.style.height.toString());
    }

    function showLoading() {
        var loadingdiv = document.getElementById('divLoading');
//        window.alert(loadingdiv);
        loadingdiv.style.visibility = 'visible';
    }

    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<asp:ScriptManager ID="scriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <h2>Edit Image</h2>

        <asp:UpdatePanel ID="UpdatePanel1" 
                    UpdateMode="Conditional"
                    runat="server">
            <ContentTemplate>
                <div id="divLoading">Loading...</div>

                <div id="clickOne" style="float:left; cursor: pointer;" onclick="switchToNormal();">
                <asp:RadioButton ID="radioNormal" OnCheckedChanged="ViewType_Click" runat="server" GroupName="viewType" Checked="true" AutoPostBack="true" /> Raw Data View</div>
        
                <div style="float: left;">&nbsp;&nbsp;&nbsp;</div>
                <div id="clickTwo" style="float:left; cursor: pointer;" onclick="switchToWillie();">
                <asp:RadioButton ID="radioWillie" OnCheckedChanged="ViewType_Click" runat="server" GroupName="viewType" AutoPostBack="true" /> Adobe EULA Mode</div>

                <div style="float: left;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                &nbsp;&nbsp;
                <!--input type="button" value="Upload New Image" onclick="javascript:window.location='./';" /--><a href="./">Upload New Image</a>
                <!-- top button -->
                <div style="clear: both;">
                    <asp:TextBox ID="databox" runat="server" CssClass="wide" TextMode="multiline" onresize="doResize();" ></asp:TextBox><br /><!--onresize="doResize();" onload="doResize(); -->

                    <div style="width: 100%; text-align: center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Draw Image"  OnClick="DrawPicture_Click" OnClientClick="showLoading();" />

                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSubmit" />
                <asp:AsyncPostBackTrigger ControlID="radioWillie" />
                <asp:AsyncPostBackTrigger ControlID="radioNormal" />
            </Triggers>
        </asp:UpdatePanel>
        
    </div>
</asp:Content>

