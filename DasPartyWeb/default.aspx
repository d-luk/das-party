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

    <div id="playlist-wrapper">
        <div id="account-info"></div>

        <h1>Playlist</h1>
        
        <div id="playlist-container">
        <asp:Repeater ID="playlist" runat="server">
            <ItemTemplate>
                <div class="track-container" data-id="<%# Eval("ID") %>">
                    <div class="track-image-container"><img class="track-image" src="<%# Eval("ImageURL") %>" alt="Album cover"/></div>

                    <div>
                        <div class="track-name"><%# Eval("Name") %></div>
                        
                        <div><span class="tarck-artist"><%# Eval("Artist") %></span> 
                            - <span class=""><%# Eval("Votes") %> votes</span></div>
                    </div>
                    
                    <div class="track-buttons">
                        <button class="btn upvote-btn"><img src="/resources/images/thumb-up.png" alt="Thumbs up"/></button>
                        <button class="btn downvote-btn"><img src="/resources/images/thumb-down.png" alt="Thumbs down"/></button>
                    </div>
                </div>
                
            </ItemTemplate>
        </asp:Repeater>
            </div>
    </div>

</asp:Content>