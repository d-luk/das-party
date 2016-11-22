<%@ Page CodeBehind="default.aspx.cs" Inherits="DasPartyWeb.Default" Language="C#" AutoEventWireup="True" Title="Homepage" MasterPageFile="_Layout.master" %>

<asp:Content runat="server" ID="Styles" ContentPlaceHolderID="Styles">
    <link rel="stylesheet" href="/resources/styles/home.css">
</asp:Content>

<asp:Content runat="server" ID="Scripts" ContentPlaceHolderID="Scripts">
    <script src="/resources/scripts/home.js"></script>
</asp:Content>

<asp:Content runat="server" ID="Content" ContentPlaceHolderID="Content">

    <div id="login-container">
        <h1>Log in to get the party started</h1>
        <button class="btn btn-primary" id="btn-login">Let's party ></button>
        <div id="result"></div>
    </div>

    <div id="playlist-container">
        <div id="account-info"></div>

        <h1>Playlist</h1>
        <asp:Literal ID="playlist" runat="server"></asp:Literal>
    </div>

</asp:Content>