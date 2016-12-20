///<reference path="../typings/signalr.d.ts"/>
///<reference path="../typings/jquery.d.ts"/>
///<reference path="../typings/api.d.ts"/>
///<reference path="login.ts"/>
var Connection;
(function (Connection) {
    var hub = $.connection.playlistHub, playlistID = "09fef8d7-3958-4b05-8c71-a05a7ae4abf8", $playlist = $("#playlist-container"), $trackTemplate = $("#template-track");
    var _votes = [];
    function init() {
        hub.client.applyChanges = function (changes) {
            console.log(changes);
            // Clear playlist and replace by new tracks 
            $playlist.children(":not(:first-child)").remove();
            changes.forEach(function (track) {
                var $newTrack = $trackTemplate.clone().attr("id", "");
                $newTrack.attr("data-id", track.ID);
                $newTrack.find(".track-name").html(track.Name);
                $newTrack.find(".track-artist").html(track.Artist);
                $newTrack.find(".track-votes").html(track.Votes.toString());
                if (track.ImageURL) {
                    $newTrack.find(".track-image").attr("src", track.ImageURL);
                }
                $newTrack.appendTo($playlist);
            });
            updatePersonalVotes();
        };
        // Start the connection.
        $.connection.hub.start().done(function () {
            hub.server.join(playlistID).done(function (success) {
                if (success) {
                    SpotifyLogin.onLogin(function () {
                        initListeners();
                        initVotes();
                    });
                }
                else
                    console.log("Error: Playlist join failed, cannot vote");
            });
        });
    }
    Connection.init = init;
    function processVote($btn, isDownvote) {
        var trackID = $btn.closest(".track-container").data("id");
        hub.server.vote(SpotifyLogin.loggedInUser.id, playlistID, trackID, isDownvote)
            .done(function (success) {
            if (success) {
                addVote({ trackID: trackID, isDownvote: isDownvote });
                $btn.prop("disabled", true);
                $btn.siblings(".btn").prop("disabled", false);
            }
            else
                console.log("Voting failed");
        });
    }
    function initListeners() {
        // Upvoting
        $playlist.on("click", ".upvote-btn", function () {
            processVote($(this), false);
        });
        // Downvoting
        $playlist.on("click", ".downvote-btn", function () {
            processVote($(this), true);
        });
        // Track search
        var inputTimeout;
        var $searchResults = $("#tracksearch-results");
        $("#tracksearch-input").on("input", function () {
            var $this = $(this);
            clearTimeout(inputTimeout);
            inputTimeout = setTimeout(function () {
                var input = $.trim($this.val());
                if (input) {
                    hub.server.search(input).done(function (trackResults) {
                        $searchResults.empty();
                        trackResults.forEach(function (trackResult) {
                            var $newResult = $("#trackresult-template").find("> .track-container").clone();
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
            var $trackContainer = $(this).closest(".track-container");
            var trackID = $trackContainer.data("id");
            hub.server.addTrack(SpotifyLogin.loggedInUser.id, playlistID, trackID).done(function (success) {
                if (success)
                    $trackContainer.remove();
            });
        });
    }
    function addVote(vote) {
        var voteIndex = -1;
        $.each(_votes, function (i, v) {
            if (v.trackID === vote.trackID) {
                voteIndex = i;
                return false;
            }
        });
        if (voteIndex >= 0) {
            // Already voted
            _votes[voteIndex] = vote;
        }
        else {
            // Add vote to list
            _votes.push(vote);
        }
    }
    function initVotes() {
        hub.server.getVotes(SpotifyLogin.loggedInUser.id, playlistID).done(function (votes) {
            votes.forEach(function (v) {
                _votes.push({
                    trackID: v.TrackID,
                    isDownvote: v.IsDownvote
                });
            });
            updatePersonalVotes();
        });
    }
    function updatePersonalVotes() {
        // Disable buttons based on votes
        var $tracks = $playlist.find("> .track-container");
        $.each($tracks, function (_, t) {
            var $track = $(t), id = $track.data("id");
            // Check if voted on this track
            var voteIndex = -1;
            $.each(_votes, function (i, vote) {
                if (vote.trackID === id) {
                    voteIndex = i;
                    return false;
                }
            });
            // Disable corresponding button
            if (voteIndex >= 0) {
                $track.find("." + (_votes[voteIndex].isDownvote ? "downvote" : "upvote") + "-btn")
                    .prop("disabled", true);
            }
        });
    }
})(Connection || (Connection = {}));
Connection.init();
