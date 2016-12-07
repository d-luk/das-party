<%@ Page CodeBehind="default.aspx.cs" Inherits="DasPartyWeb.Default" Language="C#" AutoEventWireup="True" Title="Homepage" MasterPageFile="_Layout.master" %>

<asp:Content runat="server" ID="Styles" ContentPlaceHolderID="Styles">
    <link rel="stylesheet" href="/resources/styles/home.css">
</asp:Content>

<asp:Content runat="server" ID="Scripts" ContentPlaceHolderID="Scripts">
    <script src="/resources/scripts/home.js"></script>

    <script src="/resources/scripts/vendor/jquery.signalR-2.2.1.min.js"></script>
    <script src="signalr/hubs"></script>
    <script src="/resources/scripts/connection.js"></script>
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
            <div id="template-track" class="track-container" data-id="">
                <div class="track-image-container">
                    <img class="track-image" src="/resources/images/default-cover.png" alt="Album cover"/>
                </div>

                <div class="track-info">
                    <div class="track-name"></div>

                    <div>
                        <span class="track-artist"></span> 
                        | <span class="track-votes">0</span> votes</div>
                </div>

                <div class="track-buttons">
                    <button class="btn upvote-btn">
                        <img src="/resources/images/thumb-up.png" alt="Thumbs up"/>
                    </button>
                    <button class="btn downvote-btn">
                        <img src="/resources/images/thumb-down.png" alt="Thumbs down"/>
                    </button>
                </div>
            </div>

            <asp:Repeater ID="playlist" runat="server">
                <ItemTemplate>

                    <div class="track-container" data-id="<%# Eval("ID") %>">
                        <div class="track-image-container">
                            <img class="track-image" src="<%# Eval("ImageURL") ?? "/resources/images/default-cover.png" %>" alt="Album cover"/>
                        </div>

                        <div class="track-info">
                            <div class="track-name"><%# Eval("Name") %></div>

                            <div>
                                <span class="track-artist"><%# Eval("Artist") %></span> 
                                | <span class="track-votes"><%# Eval("Votes") %></span> votes</div>
                        </div>

                        <div class="track-buttons">
                            <button class="btn upvote-btn">
                                <img src="/resources/images/thumb-up.png" alt="Thumbs up"/>
                            </button>
                            <button class="btn downvote-btn">
                                <img src="/resources/images/thumb-down.png" alt="Thumbs down"/>
                            </button>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>
            
        </div>
        
        <section id="tracksearch-section">
                <h2>Search tracks</h2>
                <input id="tracksearch-input" type="text" placeholder="Find your track..."/>
                
                <div id="trackresult-template" class="hidden">
                    <div class="track-container" data-id="">
                        <div class="track-image-container">
                            <img class="track-image" src="/resources/images/default-cover.png" alt="Album cover"/>
                        </div>

                        <div>
                            <div class="track-name"></div>
                            <div><span class="track-artist"></span></div>
                        </div>

                        <div class="track-buttons">
                            <button class="btn add-track-btn">+</button>
                        </div>
                    </div>
                </div>

                <div id="tracksearch-results"></div>
            </section>
    </div>

</asp:Content>