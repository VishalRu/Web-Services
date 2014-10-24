<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TryIt._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        TryItPage</h2>
        <asp:Label ID="Label1" runat="server" 
        Text="search videos on the web  for some query"></asp:Label><br />
        <asp:Label ID="Label2" runat="server" 
        Text="URL : http://localhost:49526/Service1.svc?singleWsdl"></asp:Label><br />
        <asp:Label ID="Label3" runat="server" Text="Method Name: VidLookUp, return type: Custom VideoResults Paramaeters:  string query"></asp:Label>
   
    
    <br />
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label><br />

         <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> 
    <asp:Button ID="Button2" runat="server" Text="Button" onclick="Button2_Click" /><br />
        

    
    <br />
    <asp:Label ID="Label5" runat="server" Text=" "></asp:Label>
    <asp:HyperLink ID="HyperLink1" runat="server">[HyperLink1]</asp:HyperLink><br />
     <asp:Label ID="Label6" runat="server" Text=" "></asp:Label>
    <asp:HyperLink ID="HyperLink2" runat="server">[HyperLink2]</asp:HyperLink><br />
     <asp:Label ID="Label7" runat="server" Text=" "></asp:Label>
    <asp:HyperLink ID="HyperLink3" runat="server">[HyperLink3]</asp:HyperLink><br />
     <asp:Label ID="Label8" runat="server" Text=" "></asp:Label>
    <asp:HyperLink ID="HyperLink4" runat="server">[HyperLink4]</asp:HyperLink><br />
     <asp:Label ID="Label9" runat="server" Text=" "></asp:Label>
    <asp:HyperLink ID="HyperLink5" runat="server">[HyperLink5]</asp:HyperLink><br />
     <br />

        

    
    <p>
       
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
</asp:Content>
