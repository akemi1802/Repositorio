<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Shared/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Views.Web.Profile.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="div-left">
    <asp:Label ID="lblTitle" runat="server" Text="My Profile" CssClass="titleblack" />
    
    <asp:Panel ID="pnlTweet" runat="server" ScrollBars="Vertical" Height="300px" Width="500px">
    
    <asp:DataList ID="dtlTweet" runat="server">
        <ItemTemplate>
            <p><asp:Label ID="lblTweet" runat="server" Text='<%#String.Format("{0}<br>Posted on {1}<br>{2}", Eval("ITEM1"), Eval("ITEM2"), Eval("ITEM3"))%>'/>
            </p>
        </ItemTemplate>
    </asp:DataList>
    </asp:Panel>
    </div>
    <div class="div-right">
        <asp:Button ID="btnFollow" runat="server" Text="Follow User" 
            onclick="btnFollow_Click" />
        
    </div>
</asp:Content>
