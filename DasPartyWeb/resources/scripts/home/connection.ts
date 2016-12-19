///<reference path="../typings/signalr.d.ts"/>
///<reference path="../typings/jquery.d.ts"/>
///<reference path="../typings/api.d.ts"/>
///<reference path="login.ts"/>

module Connection {
    // Declare a proxy to reference the hub.
    const hub = $.connection.playlistHub;

    // Create a function that the hub can call to broadcast messages.
    const $playlist = $("#playlist-container"),
        $trackTemplate = $("#template-track");

    hub.client.applyChanges = function (changes: Track[]) {
        console.log(changes);

        $playlist.children(":not(:first-child)").remove();

        changes.forEach(function (track) {
            const $newTrack = $trackTemplate.clone().attr("id", "");

            $newTrack.attr("data-id", track.ID);
            $newTrack.find(".track-name").html(track.Name);
            $newTrack.find(".track-artist").html(track.Artist);
            $newTrack.find(".track-votes").html(track.Votes.toString());

            if (track.ImageURL) {
                $newTrack.find(".track-image").attr("src", track.ImageURL);
            }

            $newTrack.appendTo($playlist);
        });
    };

    const playlistID = "09fef8d7-3958-4b05-8c71-a05a7ae4abf8";

    // Start the connection.
    $.connection.hub.start().done(function () {
        hub.server.join(playlistID).done(function (success: boolean) {
            if (success) initListeners();
            else console.log("Error: Playlist join failed, cannot vote");
        });
    });

    function initListeners() {
        // Upvoting
        $playlist.on("click", ".upvote-btn", function () {
            const trackID = $(this).closest(".track-container").data("id");
            let success = hub.server.vote(SpotifyLogin.loggedInUser.id, playlistID, trackID, false);
            if (!success) console.log("Upvote failed");
            else {
                $(this).prop("disabled", true);
                $(this).siblings(".btn").prop("disabled", false);
            }
        });

        // Downvoting
        $playlist.on("click", ".downvote-btn", function () {
            const trackID = $(this).closest(".track-container").data("id");
            let success = hub.server.vote(SpotifyLogin.loggedInUser.id, playlistID, trackID, true);
            if (!success) console.log("Downvote failed");
            else {
                $(this).prop("disabled", true);
                $(this).siblings(".btn").prop("disabled", false);
            }
        });

        // Track search
        let inputTimeout;
        const $searchResults = $("#tracksearch-results");
        $("#tracksearch-input").on("input", function () {
            const $this = $(this);

            clearTimeout(inputTimeout);
            inputTimeout = setTimeout(function () {
                const input = $.trim($this.val());
                if (input) {
                    hub.server.search(input).done(function (trackResults) {
                        $searchResults.empty();
                        trackResults.forEach(function (trackResult) {
                            const $newResult = $("#trackresult-template").find("> .track-container").clone();
                            $newResult.attr("id", "");
                            $newResult.attr("data-id", trackResult.ID);

                            if (trackResult.ImageURL) {
                                $newResult.find(".track-image").attr("src", trackResult.ImageURL);
                            }

                            $newResult.find(".track-name").html(trackResult.Name);
                            $newResult.find(".track-artist").html(trackResult.Artist);

                            $searchResults.append($newResult);
                        });
                    });
                }
            }, 500);
        });

        // Adding track
        $searchResults.on("click", ".add-track-btn", function () {
            const $trackContainer = $(this).closest(".track-container");
            const trackID = $trackContainer.data("id");

            hub.server.addTrack(SpotifyLogin.loggedInUser.id, playlistID, trackID).done(function (success) {
                if (success) $trackContainer.remove();
            });
        });
    }
}