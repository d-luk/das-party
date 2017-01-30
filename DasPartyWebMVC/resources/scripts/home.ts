module SpotifyLogin {
    var localToken: string = localStorage.getItem("token");

    function login(callback: (token: string) => any, forced?: boolean) {

        if (!forced && localToken) {
            callback(localToken);
            return;
        } else if (forced) {
            // Reset token
            localToken = null;
            localStorage.removeItem("token");
        }

        const clientId = "26e3d7571b7947fd9080aa94c2c0621d";
        const redirectUri = "http://das.party/auth.aspx";

        function getLoginURL(scopes) {
            return `https://accounts.spotify.com/authorize` +
                `?client_id=${clientId}&redirect_uri=${encodeURIComponent(redirectUri)}&scope=${
                encodeURIComponent(scopes.join(" "))}&response_type=token`;
        }

        const url = getLoginURL([
            "user-read-email"
        ]);
        const width = 450,
            height = 730,
            left = (screen.width / 2) - (width / 2),
            top = (screen.height / 2) - (height / 2);

        window.addEventListener("message",
            event => {
                const hash = JSON.parse(event.data);
                if (hash.type === "access_token") {
                    localStorage.setItem("token", hash.access_token);
                    callback(hash.access_token);
                }
            }, 
            false);

        window.open(url,
            "Spotify",
            `menubar=no,location=no,resizable=no,scrollbars=no,status=no,` +
            ` width=${width}, height=${height}, top=${top}, left=${left}`
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

    function startParty(user: SpotifyAPI.ILoginResponse): void {
        $("#account-info")
            .html("Hello" + (user.display_name ? `, ${user.display_name}`
                : ($.isNumeric(user.id) ? " there" : `, ${user.id}`))
            + "! Let's party");
        $("#login-container").hide();
        $("#playlist-container").show();
    }

    function tryLogin(forced?: boolean) {
        login(accessToken => {
                getUserData(accessToken)
                    .then((response: SpotifyAPI.ILoginResponse) => {
                        console.log(response);
                        startParty(response);
                    });
            },
            forced);
    }

    if (localToken) tryLogin();

    $("#btn-login")
        .click(() => {
            if (location.hostname === "localhost" || location.hostname === "127.0.0.1") {
                startParty({
                    display_name: "Test",
                    email: "test@test.com",
                    external_urls: {
                        spotify: "https://open.spotify.com/user/test"
                    },
                    followers: {
                        href: null,
                        total: 10
                    },
                    href: "https://api.spotify.com/v1/users/test",
                    id: "testaccount",
                    images: [
                        {
                            height: null,
                            url: "https://scontent.xx.fbcdn.net/v/t1.0-1/p200x200/11542099_796414300457857_4421964208460940101_n.jpg" +
                                "?oh=9c7d2af153cb59848b9f3e50e159c8d2&oe=58C83D80",
                            width: null
                        }
                    ],
                    type: "user",
                    uri: "spotify:user:test"
                });
            } else {
                // Token is expired, so force login to refresh token
                tryLogin(typeof localToken !== "undefined" && localToken !== null);
            }

        });
}