<template>
    <div>
        <div class="player">
            <div>
                <img class="albumImg" :src="$store.state.currentImage" alt="">
            </div>

            <img style="width: 32px;" :src="$store.state.previousSong" @click="previousSong()" alt="previous">
            <img id="play" style="width: 36px;" @click="togglePlay()" :src="$store.state.playBtn" alt="play">
            <img style="width: 32px;" :src="$store.state.nextSong" @click="nextSong()" alt="next">

        </div>
    </div>
</template>

<script>


export default {
    name: 'PlayerComponent',
    data() {
        return {
            player: null,
            timer: null,
            start: true,
            pause: false
        };
    },
    mounted() {
        if (!document.querySelector('script[src="https://sdk.scdn.co/spotify-player.js"]')) {
            const sdk = document.createElement("script");
            sdk.setAttribute(
                "src",
                "https://sdk.scdn.co/spotify-player.js"
            );

            document.head.appendChild(sdk);
            setInterval(() => {
                this.$store.dispatch('getCurrentTrack');
            }, 2000);


        }



        window.onSpotifyWebPlaybackSDKReady = async () => {
            const token = this.$store.state.spotifyToken;
            this.player = await new window.Spotify.Player({
                name: 'Playsoft Web',
                getOAuthToken: cb => { cb(token); },
                volume: 0.5,
                autoPlay: false

            });

            this.$store.state.player = this.player;

            this.player.addListener('ready', ({ device_id }) => {
                this.$store.state.device_id = device_id;
                console.log('Ready with Device ID', device_id);
            });
            this.player.addListener('autoplay_failed', () => {
                console.log('Autoplay is not allowed by the browser autoplay rules');
            });
            // Not Ready
            this.player.addListener('not_ready', ({ device_id }) => {
                console.log('Device ID has gone offline', device_id);
            });

            this.player.connect().then(console.log("CONNECTED"))

            this.player.on('playback_error', ({ message }) => {
                console.error('Failed to perform playback', message);
            });
            this.player.on('playback_error', ({ message }) => {
                console.error('Failed to perform playback', message);
            });
            this.$store.state.player.pause()
        }

    },
    methods: {
        togglePlay() {
            const btn = document.getElementById("play")
            console.log(btn)

      
            this.$store.state.player.togglePlay().then(() => {
                console.log('Toggled playback!');
                if (btn.src == "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADIAAAAyCAYAAAAeP4ixAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAWElEQVR4nO3SoQ3AQAwEwe+/6YRsAQH3QTOSoYHlPQcA/vV8nFv7Mw6Jj6xJK9Jak1aktSatSGtNWpHWmrQirTVpRVpr0oq01qQVaa1JK9Jak1akBQDnkhe+iKV3X20cDgAAAABJRU5ErkJggg==") {

                    btn.src = this.$store.state.playBtn

                } else {

                    btn.src = this.$store.state.pauseBtn
                }
            });
        },

        nextSong() {
            this.$store.state.player.nextTrack().then(() => {
                console.log('Skipped to next track!');
                document.getElementById("play").src = this.$store.state.pauseBtn
            });
        },
        previousSong() {
            this.$store.state.player.previousTrack().then(() => {
                console.log('Set to previous track!');
                document.getElementById("play").src = this.$store.state.pauseBtn
            });
        },
    }

};
</script>

  
<style>
.player {
    display: flex;
    flex-direction: row;
    justify-content: center;
    gap: 25px;
    align-items: center;
    height: 100px;
    margin-top: 20px;
    padding-top: 47px;
    color: white;
    background-color: rgb(43, 2, 37);
}

.albumImg {
    width: 48px;

}
</style>
  