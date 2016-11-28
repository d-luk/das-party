$(function () {
    // Declare a proxy to reference the hub. 
    var hub = $.connection.playlistHub;

    // Create a function that the hub can call to broadcast messages.
    var $playlist = $('#playlist-container'),
        $trackTemplate = $("#template-track");
    hub.client.applyChanges = function (changes) {
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
    
    // Start the connection.
    $.connection.hub.start().done(function () {

        var joined = hub.server.join("09fef8d7-3958-4b05-8c71-a05a7ae4abf8");

        // TODO: Voting
        $(".upvote-btn").click(function () {
//            hub.server.vote("userID/token", "playlistTrackID", "isDownvote");
        });
    });
});