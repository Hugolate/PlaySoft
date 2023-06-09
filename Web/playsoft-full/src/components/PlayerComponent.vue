<template>
    <div>
        <div class="player">
            <div @click="previousSong()">Previous</div>
            <div  @click="togglePlay()">Play/Pause</div>
            <div @click="previousSong()">Next</div>
        </div>
    </div>
</template>

<script>


export default {
    name: 'PlayerComponent',
    data() {
        return {
            player: null
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
        }
        window.onSpotifyWebPlaybackSDKReady = () => {
            const token = this.$store.state.spotifyToken;
            this.player = new window.Spotify.Player({
                name: 'Playsoft Web',
                getOAuthToken: cb => { cb(token); },
                volume: 0.5

            });
            console.log(this.player)
            this.player.addListener('ready', ({ device_id }) => {
                this.$store.state.device_id = device_id;
                console.log('Ready with Device ID', device_id);
            });

            // Not Ready
            this.player.addListener('not_ready', ({ device_id }) => {
                console.log('Device ID has gone offline', device_id);
            });

            this.player.connect().then(console.log("CONECTADO"));
        }
    },
    methods: {
        togglePlay() {
            this.player.previousTrack();
        },
        nextSong() {
            this.player.togglePlay();
        },
        previousSong() {
            this.player.nextTrack();
        },
    }

};
</script>

  
<style>
.player{
    display: flex;
    flex-direction: row;
    justify-content: center;
    gap: 25px;
    height: 100px;
    margin-top: 20px;
    padding-top: 60px;
    color: white;
    background-color: rgb(43, 2, 37);
}
</style>
  