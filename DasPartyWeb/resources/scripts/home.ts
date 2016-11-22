/// <reference path="../../../DasPartyHost/Scripts/typings/jquery/jquery.d.ts" />
module SpotifyLogin {
    function login(callback: (token: string) => any) {
        const clientId = "26e3d7571b7947fd9080aa94c2c0621d";
        const redirectUri = "http://das.party/auth.aspx";

        function getLoginURL(scopes) {
            return `https://accounts.spotify.com/authorize`
                + `?client_id=${clientId}&redirect_uri=${encodeURIComponent(redirectUri)}&scope=${encodeURIComponent(scopes.join(" "))}&response_type=token`;
        }

        const url = getLoginURL([
            "user-read-email"
        ]);
        const width = 450;
        const height = 730;
        const left = (screen.width / 2) - (width / 2);
        const top = (screen.height / 2) - (height / 2);

        window.addEventListener("message",
            event => {
                const hash = JSON.parse(event.data);
                if (hash.type === "access_token") {
                    callback(hash.access_token);
                }
            },
            false);

        window.open(url,
            "Spotify", `menubar=no,location=no,resizable=no,scrollbars=no,status=no,`
            + ` width=${width}, height=${height}, top=${top}, left=${left}`
        );

    }

    function getUserData(accessToken) {
        return $.ajax({
            url: "https://api.spotify.com/v1/me",
            headers: {
                'Authorization': `Bearer ${accessToken}`
            }
        });
    }

    $("#btn-login").click(() => {
        login(accessToken => {
            getUserData(accessToken)
                .then((response: SpotifyAPI.ILoginResponse) => {
                    console.log(response);                    
                    $("#account-info").html((response.display_name ? `Hello, ${response.display_name}!` : `Hello ${response.id}!`) + "Let's party"); 
                    $("#login-container").hide();
                    $("#playlist-container").show(); 
                });
        });
    });
}