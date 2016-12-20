///<reference path="../typings/signalr.d.ts"/>
///<reference path="../typings/jquery.d.ts"/>
///<reference path="../typings/api.d.ts"/>
///<reference path="login.ts"/>

module Connection {

    const hub = $.connection.playlistHub,
        playlistID = "09fef8d7-3958-4b05-8c71-a05a7ae4abf8",
        $playlist = $("#playlist-container"),
        $trackTemplate = $("#template-track");

    let _votes: {
        trackID: string,
        isDownvote: boolean;
    }[] = [];

    export function init(): void {
        hub.client.applyChanges = (changes: Track[]) => {
            console.log(changes);

            // Clear playlist and replace by new tracks 
            $playlist.children(":not(:first-child)").remove();
            changes.forEach(track => {
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

            updatePersonalVotes();
        };

        // Start the connection.
        $.connection.hub.start().done(() => {
            hub.server.join(playlistID).done((success: boolean) => {
                if (success) {
                    SpotifyLogin.onLogin(() => {
                        initListeners();
                        initVotes();
                    });
                } else console.log("Error: Playlist join failed, cannot vote");
            });
        });
    }

    function processVote($btn: JQuery, isDownvote: boolean): void {
        const trackID: string = $btn.closest(".track-container").data("id");
        hub.server.vote(SpotifyLogin.loggedInUser.id, playlistID, trackID, isDownvote)
            .done((success: boolean) => {
                if (success) {
                    addVote({trackID: trackID, isDownvote: isDownvote});
                    $btn.prop("disabled", true);
                    $btn.siblings(".btn").prop("disabled", false);
                } else console.log("Voting failed");
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
        let inputTimeout: number;
        const $searchResults = $("#tracksearch-results");
        $("#tracksearch-input").on("input", function () {
            const $this = $(this);

            clearTimeout(inputTimeout);
            inputTimeout = setTimeout(() => {
                const input = $.trim($this.val());
                if (input) {
                    hub.server.search(input).done(trackResults => {
                        $searchResults.empty();
                        trackResults.forEach(trackResult => {
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

            hub.server.addTrack(SpotifyLogin.loggedInUser.id, playlistID, trackID).done(success => {
                if (success) $trackContainer.remove();
            });
        });
    }

    function addVote(vote: {
        trackID: string,
        isDownvote: boolean;
    }): void {
        let voteIndex = -1;
        $.each(_votes, (i, v) => {
            if (v.trackID === vote.trackID) {
                voteIndex = i;
                return false;
            }
        });

        if (voteIndex >= 0) {
            // Already voted
            _votes[voteIndex] = vote;
        } else {
            // Add vote to list
            _votes.push(vote);
        }
    }

    function initVotes(): void {
        hub.server.getVotes(SpotifyLogin.loggedInUser.id, playlistID).done((votes: Vote[]) => {
            votes.forEach((v: Vote) => {
                _votes.push({
                    trackID: v.TrackID,
                    isDownvote: v.IsDownvote
                });
            });

            updatePersonalVotes();
        });

    }

    function updatePersonalVotes(): void {
        // Disable buttons based on votes
        const $tracks = $playlist.find("> .track-container");

        $.each($tracks, (_, t: Element) => {
            const $track = $(t),
                id: string = $track.data("id");

            // Check if voted on this track
            let voteIndex = -1;
            $.each(_votes, (i, vote) => {
                if (vote.trackID === id) {
                    voteIndex = i;
                    return false;
                }
            });

            // Disable corresponding button
            if (voteIndex >= 0) {
                $track.find(`.${_votes[voteIndex].isDownvote ? "downvote" : "upvote"}-btn`)
                    .prop("disabled", true);
            }
        });
    }
}

Connection.init();