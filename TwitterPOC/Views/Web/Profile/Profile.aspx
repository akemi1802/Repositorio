<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Shared/Site.Master" AutoEventWireup="true"
    CodeBehind="Profile.aspx.cs" Inherits="Views.Web.Profile.Profile" %>

<%@ Register Src="ucTweeet.ascx" TagName="ucTweeet" TagPrefix="uc1" %>
<%@ Register src="../Search/ucSearchTweet.ascx" tagname="ucSearchTweet" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="div-left">
    <asp:Label ID="lblTitle" runat="server" Text="My Profile" CssClass="titleblack" />
    <uc1:ucTweeet ID="ucTweeet1" runat="server" />
    
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
        <uc2:ucSearchTweet ID="ucSearchTweet1" runat="server" />
    </div>
</asp:Content>
