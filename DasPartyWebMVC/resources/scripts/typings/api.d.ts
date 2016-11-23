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