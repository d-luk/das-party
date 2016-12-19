declare module SpotifyAPI {
    interface ILoginResponse {
        display_name: string,
        email: string,
        external_urls: {
            spotify: string;
        },
        followers: {
            href: string;
            total: number;
        },
        href: string,
        id: string,
        images: {
            height: number;
            url: string;
            width: number;
        }[],
        type: string,
        uri: string,
    }
}

interface SignalR {
    playlistHub: {
        client: {
            applyChanges: (changes: Track[]) => void
        },
        server: {
            join: (playlistID: string) => JQueryDeferred<boolean>,
            vote: (userID: string, playlistID: string, trackID: string, isDownvote: boolean) => JQueryDeferred<boolean>,
            search: (input: string) => JQueryDeferred<Track[]>,
            addTrack: (userID: string, playlistID: string, trackID: string) => JQueryDeferred<boolean>,
            getVotes: (userID: string, playlistID: string) => JQueryDeferred<Vote[]>
        }
    }
}

interface Track {
    ID: string,
    Name: string,
    Artist: string,
    ImageURL: string,
    Votes: number
}

interface Vote {
    ID: string,
    UserID: string,
    PlaylistTrackID: string,
    TrackID: string,
    IsDownvote: boolean,
}