<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TryIt._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        TryIt
        </h2>
        <br />
        <asp:Label ID="Label1" runat="server" 
        Text="Translate any string from one language to another"></asp:Label><br />
        <asp:Label ID="Label2" runat="server" 
        Text="URL: http://localhost:49245/Service1.svc?singleWsdl"></asp:Label><br />

        <asp:Label ID="Label3" runat="server" 
        Text=" Method Name: Translated, Parameters:string query, string query, string from, string to, Return Type: String "></asp:Label>
    
    <br />

     <asp:Label ID="Label4" runat="server" 
        Text="Write any string in english and it will convert it into Chinese(Simplified) "></asp:Label>
        <br />

        <asp:TextBox ID="TextBox1" runat="server" Height="69px" Width="199px" 
        TextMode="MultiLine"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Button" 
    onclick="Button1_Click" /><asp:TextBox ID="TextBox2" runat="server" 
        Height="69px" Width="199px" TextMode="MultiLine"></asp:TextBox>
    
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
</asp:Content>
