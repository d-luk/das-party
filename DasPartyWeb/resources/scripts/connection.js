$(function() {
    // Declare a proxy to reference the hub. 
    var hub = $.connection.playlistHub;

    // Create a function that the hub can call to broadcast messages.
    var $playlist = $("#playlist-container"),
        $trackTemplate = $("#template-track");

    hub.client.applyChanges = function(changes) {
        console.log(changes);

        $playlist.children(":not(:first-child)").remove();

        changes.forEach(function(track) {
            var $newTrack = $trackTemplate.clone().attr("id", "");

            $newTrack.attr("data-id", track.ID);
            $newTrack.find(".track-name").html(track.Name);
            $newTrack.find(".track-artist").html(track.Artist);
            $newTrack.find(".track-votes").html(track.Votes);
            $newTrack.find(".track-image").attr("src", track.ImageURL);

            $newTrack.appendTo($playlist);
        });
    };

    var playlistID = "09fef8d7-3958-4b05-8c71-a05a7ae4abf8";

    // Start the connection.
    $.connection.hub.start()
        .done(function() {
            if (hub.server.join(playlistID)) initListeners();
            else console.log("Error: Playlist join failed, cannot vote");
        });

    function initListeners() {
        $("#playlist-container")
            .on("click",
                ".upvote-btn",
                function() {
                    var trackID = $(this).closest(".track-container").data("id");
                    var success = hub.server.vote(SpotifyLogin.loggedInUser.id, playlistID, trackID, false);
                    if (!success) console.log("Upvote failed");
                });

        $("#playlist-container")
            .on("click",
                ".downvote-btn",
                function() {
                    var trackID = $(this).closest(".track-container").data("id");
                    var success = hub.server.vote(SpotifyLogin.loggedInUser.id, playlistID, trackID, true);
                    if (!success) console.log("Downvote failed");
                });
    }
});