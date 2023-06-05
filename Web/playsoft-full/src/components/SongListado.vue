<template>
    <v-app id="inspire">
        <v-main class="pa-0">
            <BackGround></BackGround>
            <div v-if="isloading">a</div>
            <div v-else-if="songList !== undefined || songList.length > 0">
                <div class="main-opt">
                    <p class="pl-name">{{ songList[0].playlist.playListName }}</p>
                    <div style="display: flex;">
                        <p class="description">
                            {{ songList[0].playlist.playlistDescription }}
                        </p>

                        <!-- <svg height="72" viewBox="0 0 48 48" width="72" xmlns="http://www.w3.org/2000/svg" fill="gray">
                        <path d="M0 0h48v48H0z" fill="none" />
                        <path
                            d="M24 4C12.95 4 4 12.95 4 24s8.95 20 20 20 20-8.95 20-20S35.05 4 24 4zm-4 29V15l12 9-12 9z" />
                    </svg> -->
                    </div>
                </div>
                <v-container class="fill-height canciones" fluid
                    style="justify-content: center; height: 0; margin-top: 400px;">

                    <div style="padding-top: 10px;" class="grid grid-header">
                        <div id="Song.songName" class="arrowDiv" v-on:click="toggleArrow($event)">
                            Title
                            <svg class="arrow" xmlns="http://www.w3.org/2000/svg" fill="white" width="30"
                                viewBox="0 0 20 20">
                                <path d="M7 10l5 5 5-5z"></path>
                            </svg>
                        </div>
                        <div id="Song.Album.albumName" class="arrowDiv" v-on:click="toggleArrow($event)">
                            Album
                            <svg class="arrow" xmlns="http://www.w3.org/2000/svg" fill="white" width="30"
                                viewBox="0 0 20 20">
                                <path d="M7 10l5 5 5-5z"></path>
                            </svg>
                        </div>
                        <div id="artistName" style="display: flex;" class="arrowDiv" v-on:click="toggleArrow($event)">
                            Artists
                            <svg class="arrow" xmlns="http://www.w3.org/2000/svg" fill="white" width="30"
                                viewBox="0 0 20 20">
                                <path d="M7 10l5 5 5-5z"></path>
                            </svg>
                        </div>
                        <div id="Song.durationMs" class="arrowDiv" v-on:click="toggleArrow($event)">
                            Duration
                            <svg class="arrow" xmlns="http://www.w3.org/2000/svg" fill="white" width="30"
                                viewBox="0 0 20 20">
                                <path d="M7 10l5 5 5-5z"></path>
                            </svg>
                        </div>
                    </div>
                    <div style="padding-top: 10px;" class="songs grid" v-for="(song, index) in songList" :key="song.songID">
                        <div class="head">
                            <div style="margin-right: 40px; cursor: pointer;"
                                @click="getSpotifyId(song.song.spotifySongID), getSongId(index), showPlayer = true">

                                <svg height="40" fill="purple" id="Layer_1" style="enable-background:new 0 0 512 512;"
                                    version="1.1" viewBox="0 0 512 512" width="40" xml:space="preserve"
                                    xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
                                    <path
                                        d="M405.2,232.9L126.8,67.2c-3.4-2-6.9-3.2-10.9-3.2c-10.9,0-19.8,9-19.8,20H96v344h0.1c0,11,8.9,20,19.8,20  c4.1,0,7.5-1.4,11.2-3.4l278.1-165.5c6.6-5.5,10.8-13.8,10.8-23.1C416,246.7,411.8,238.5,405.2,232.9z" />
                                </svg>
                            </div>
                            <img :src="song.song.album.image"
                                style="width: 40px;height: 40px;" alt="">
                            <p style="max-width: 20px;" class="songName">{{ song.song.songName }} </p>
                        </div>
                        <div>
                            <p>{{ song.song.album.albumName }}</p>
                        </div>
                        <div style="display: flex; gap: 5px;">
                            <p class="artists" v-for="artistSongs in song.song.artistSongs"
                                :key="artistSongs.spotifyArtistID">
                                {{ artistSongs.artistName }} </p>
                        </div>
                        <div>
                            <p>{{ millisToMinutesAndSeconds(song.song.durationMs) }}</p>
                        </div>
                    </div>
                </v-container>
            </div>
            <div v-else>
                <h1 class="no-song">You don't have songs in this playlist.</h1>
            </div>
            <div class="iframeContainer" v-if="showPlayer">
                <iframe
                    style="border-radius: 0px; left: 0; position: fixed;z-index: 1;bottom: 0px;width: 100%;height: 80px; "
                    :src="'https://open.spotify.com/embed/track/' + spotifyId + '?utm_source=generator'" width="100%"
                    height="352" frameBorder="0" allowfullscreen=""
                    allow="autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture" loading="lazy">
                </iframe>
                <button style="border-radius: 0px;position: fixed; z-index: 2;bottom: 0px; bottom: 3%; left: 55%;"
                    title="Next song" @click=" nextSong()">
                    <svg width="24" height="24" xmlns="http://www.w3.org/2000/svg" fill-rule="evenodd" clip-rule="evenodd">
                        <path d="M21.883 12l-7.527 6.235.644.765 9-7.521-9-7.479-.645.764 7.529 6.236h-21.884v1h21.883z" />
                    </svg>
                </button>
                <button style="border-radius: 0px;position: fixed; z-index: 2;bottom: 0px; bottom: 3%; left: 45%;"
                    title="Previous song"><svg width="24" height="24" xmlns="http://www.w3.org/2000/svg" fill-rule="evenodd"
                        clip-rule="evenodd" @click=" prevSong()">
                        <path d="M2.117 12l7.527 6.235-.644.765-9-7.521 9-7.479.645.764-7.529 6.236h21.884v1h-21.883z" />
                    </svg>
                </button>
            </div>
        </v-main>
    </v-app>
</template>

<script>

import BackGround from '../components/BackGround.vue'


export default {
    name: 'SongsPage',
    data() {
        return {
            button: require('../assets/images/next-button.png'),
            isloading: true,
            showPlayer: false,
            spotifyId: '',
            songId: 0
        };
    },
    computed: {
        songList() {

            return this.$store.state.Songs;
        },
    },
    components: {
        BackGround
    },
    async mounted() {
        try {
            this.$store.dispatch('getSongs', { undefined, orderKey: undefined });
        } catch (error) {
            console.error('Error fetching song list:', error);
        } finally {
            this.isloading = false;
            console.log(this.isloading)
        }
    },
    methods: {
        getSpotifyId(spotifyId) {
            this.spotifyId = spotifyId
        },
        getSongId(songId) {
            this.songId = songId
        },
        nextSong() {
            this.songId += 1;
            this.spotifyId = this.$store.state.Songs[this.songId].song.spotifySongID
        },
        prevSong() {
            this.songId -= 1;
            this.spotifyId = this.$store.state.Songs[this.songId].song.spotifySongID
        },
        toggleArrow(event) {

            const filters = document.getElementsByClassName("arrowDiv")
            const clickedDivId = event.target.id;
            const divElement = document.getElementById(clickedDivId);
            const svgElement = divElement.querySelector('svg');

            for (let i = 0; i < filters.length; i++) {
                let svg = filters[i].getElementsByTagName("svg")[0];
                if (svg != svgElement && !svg.classList.contains("arrow")) {
                    svg.classList = "";
                    svg.classList.toggle("arrow");
                }
            }

            if (svgElement.classList.contains("arrow")) {

                svgElement.classList.toggle("arrow")
                svgElement.classList.toggle("DESC")
            } else if (svgElement.classList.contains("DESC")) {

                svgElement.classList.toggle("DESC")
                svgElement.classList.toggle("ASC")
            } else {

                svgElement.classList.remove("ASC")
                svgElement.classList.toggle("arrow")

            }
            let order = '';

            if (svgElement.classList.contains("ASC")) {
                order = "DESC";
            } else if (svgElement.classList.contains("DESC")) {
                order = "ASC"
            } else order = null;

            this.$store.dispatch('getSongs', { order, orderKey: clickedDivId });

        },
        millisToMinutesAndSeconds(millis) {

            if (millis > 0) {

                var minutes = Math.floor(millis / 60000);
                var seconds = ((millis % 60000) / 1000).toFixed(0);
                return (
                    seconds == 60 ?
                        (minutes + 1) + ":00" :
                        minutes + ":" + (seconds < 10 ? "0" : "") + seconds
                );
            } else {
                return "00:00"
            }
        },
    }
}

</script>

<style>
.ASC {
    transform: rotate(180deg);
}

.DESC {
    transform: rotate(0deg);
}

.arrow {
    display: none;
}

.grid-header {
    color: white;
    text-shadow: 1px 1px 5px #e69cf8;
    font-size: larger;

}

.no-song {
    margin-top: 200px;
    position: relative;
    z-index: 3;
    color: white;
}

.main-opt {

    z-index: 1;
    top: 180px;
    right: 180px;
    position: absolute;
    justify-content: center;
    align-items: center;
    display: flex;
    flex-direction: column;
    gap: 10px;
}

.head {
    display: flex;
    gap: 10px;
}

.grid {
    display: grid;
    grid-template-columns: repeat(4, 1fr);
    width: 80%;
    z-index: 1;
}


.pl-name {
    font-size: xx-large;
    color: white;
    text-shadow: 1px 1px 5px #e69cf8;

}

.description {
    font-size: medium;
    color: white;
    text-shadow: 1px 1px 5px #e69cf8;
    max-width: 400px;
    word-wrap: break-word;
    overflow-wrap: break-word;
    text-align: center;
}

.songs {
    border-top: 1px solid rgb(119, 111, 111);
    align-items: center;
    color: white;
    z-index: 1;
    padding: 0px;
    color: white;
    letter-spacing: .2rem;
}


div {
    -webkit-touch-callout: none;
    -webkit-user-select: none;
    -khtml-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
}

@keyframes wavy {
    0% {
        top: 0px;
    }

    50% {
        top: -15px;
    }

    100% {
        top: 0px;
    }
}

.searchbar {
    z-index: 1;
    width: 25%;
    background: white;
    border-radius: 5px;
}

.addSong {
    z-index: 2;
    position: relative;
    background: blue;
    border-radius: 10px;
    color: white
}

.addSong:hover {
    width: 5rem;
    height: 2rem;
}

.canciones {
    display: flex;
    gap: 7px
}

v-content {
    display: flex;
    justify-content: center;
    align-items: center;
    min-height: 350vh;
    background-color: black;
    padding: none !important;
}



.text {
    z-index: 2;
    color: white;
    text-align: center;
}

.fondo1 {
    position: absolute;
    width: 100vw;
    height: 350vh;
    display: flex;
    justify-content: center;
    align-items: center;
    gap: 2px;
    flex-wrap: wrap;
    overflow: hidden;
    z-index: 0;
    background: gray;
}

section::before {
    content: '';
    position: absolute;
    width: 100%;
    height: 100%;
    background: linear-gradient(black, purple, black);
    animation: animate 15s linear infinite;
}

@keyframes animate {
    0% {
        transform: translateY(-100%);
    }

    100% {
        transform: translateY(100%);
    }
}

section span {
    position: relative;
    display: block;
    width: calc(6.25vw - 2px);
    height: calc(6.25vw - 2px);
    background-color: rgb(15, 15, 15);
    z-index: 2;
    transition: 1.5s;
}

#cancion:hover {

    height: 100px;
    display: inline-flex;
    align-items: center;
}

h2 {
    display: inline-flex;
}

section span:hover {
    background: rgb(128, 0, 128);
    transition: 0s;
}

@media(max-width: 900px) {
    section span {
        width: calc(10vw- 2px);
        height: calc(10vw - 2px);
    }
}

@media(max-width: 600px) {
    section span {
        width: calc(20vw- 2px);
        height: calc(20vw - 2px);
    }
}
</style>
