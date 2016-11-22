/// <reference path="../../../DasPartyHost/Scripts/typings/jquery/jquery.d.ts" />
var SpotifyLogin;
(function (SpotifyLogin) {
    function login(callback) {
        var clientId = "26e3d7571b7947fd9080aa94c2c0621d";
        var redirectUri = "http://das.party/auth.aspx";
        function getLoginURL(scopes) {
            return "https://accounts.spotify.com/authorize"
                + ("?client_id=" + clientId + "&redirect_uri=" + encodeURIComponent(redirectUri) + "&scope=" + encodeURIComponent(scopes.join(" ")) + "&response_type=token");
        }
        var url = getLoginURL([
            "user-read-email"
        ]);
        var width = 450;
        var height = 730;
        var left = (screen.width / 2) - (width / 2);
        var top = (screen.height / 2) - (height / 2);
        window.addEventListener("message", function (event) {
            var hash = JSON.parse(event.data);
            if (hash.type === "access_token") {
                callback(hash.access_token);
            }
        }, false);
        window.open(url, "Spotify", "menubar=no,location=no,resizable=no,scrollbars=no,status=no,"
            + (" width=" + width + ", height=" + height + ", top=" + top + ", left=" + left));
    }
    function getUserData(accessToken) {
        return $.ajax({
            url: "https://api.spotify.com/v1/me",
            headers: {
                'Authorization': "Bearer " + accessToken
            }
        });
    }
    $("#btn-login").click(function () {
        login(function (accessToken) {
            getUserData(accessToken)
                .then(function (response) {
                console.log(response);
                $("#account-info").html((response.display_name ? "Hello, " + response.display_name + "!" : "Hello " + response.id + "!") + "Let's party");
                $("#login-container").hide();
                $("#playlist-container").show();
            });
        });
    });
})(SpotifyLogin || (SpotifyLogin = {}));
