<template>
    <v-app id="inspire">
        <v-main class="pa-0">
            <BackGround></BackGround>
            <CreatePlaylistForm class="form-edit"></CreatePlaylistForm>
            <div v-if="isloading"></div>
            <div v-else-if="songList.length > 0 || arrow">
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
                        <div id="Song.Album.albumName" class="arrowDiv deleteAlbum" v-on:click="toggleArrow($event)">
                            Album
                            <svg class="arrow" xmlns="http://www.w3.org/2000/svg" fill="white" width="30"
                                viewBox="0 0 20 20">
                                <path d="M7 10l5 5 5-5z"></path>
                            </svg>
                        </div>
                        <div id="artistName" style="display: flex;" class="arrowDiv deleteArtists"
                            v-on:click="toggleArrow($event)">
                            Artists
                            <svg class="arrow" xmlns="http://www.w3.org/2000/svg" fill="white" width="30"
                                viewBox="0 0 20 20">
                                <path d="M7 10l5 5 5-5z"></path>
                            </svg>
                        </div>
                        <div id="Song.durationMs" class="arrowDiv deleteDuration" v-on:click="toggleArrow($event)">
                            Duration
                            <svg class="arrow" xmlns="http://www.w3.org/2000/svg" fill="white" width="30"
                                viewBox="0 0 20 20">
                                <path d="M7 10l5 5 5-5z"></path>
                            </svg>
                        </div>
                    </div>
                    <div style="padding-top: 10px;" v-on:click.right.prevent="deleteAlert(song); index1 = index"
                        class="songs grid" v-for="(song, index) in songList" :key="song.songID"> <v-dialog v-model="dialog"
                            width="500">
                            <v-card>
                                <v-card-title class="headline grey lighten-2" primary-title>
                                    Delete/Remove list?
                                </v-card-title>

                                <v-card-text
                                    style="display: flex; flex-direction: column;justify-content: center;align-items: center;margin-top: 15px">
                                    <h2>{{ removeSng.playListName }}</h2>
                                    <p>{{ removeSng.playlistDescription }}</p>
                                </v-card-text>
                                <v-divider></v-divider>
                                <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn color="blue-grey darken-1" @click="dialog = false" style="color: white;">
                                        Cancel
                                    </v-btn>
                                    <v-btn @click="deleteSongs(songList), dialog = false;" color="red darken-1"
                                        style="color: white;">
                                        Delete
                                    </v-btn>
                                </v-card-actions>
                            </v-card>
                        </v-dialog>
                        <div class="head">
                            <div style="margin-right: 40px; cursor: pointer;"
                                @click="getSpotifyId(song.song.spotifySongID), getSongId(index), play(index), showPlayer = true">

                                <svg height="40" fill="purple" id="Layer_1" style="enable-background:new 0 0 512 512;"
                                    version="1.1" viewBox="0 0 512 512" width="40" xml:space="preserve"
                                    xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
                                    <path
                                        d="M405.2,232.9L126.8,67.2c-3.4-2-6.9-3.2-10.9-3.2c-10.9,0-19.8,9-19.8,20H96v344h0.1c0,11,8.9,20,19.8,20  c4.1,0,7.5-1.4,11.2-3.4l278.1-165.5c6.6-5.5,10.8-13.8,10.8-23.1C416,246.7,411.8,238.5,405.2,232.9z" />
                                </svg>
                            </div>
                            <img :src="song.song.album.image" style="width: 40px;height: 40px;" alt="">
                            <p style="max-width: 20px;" class="songName" id="nameID">{{ song.song.songName }} </p>
                        </div>
                        <div id="albumID">
                            <p>{{ song.song.album.albumName }}</p>
                        </div>
                        <div style="display: flex; gap: 5px;">
                            <p id="artistID" class="artists" v-for="artistSongs in song.song.artistSongs"
                                :key="artistSongs.spotifyArtistID">
                                {{ artistSongs.artistName }} </p>
                        </div>
                        <div id="durationID">
                            <p>{{ millisToMinutesAndSeconds(song.song.durationMs) }}</p>
                        </div>
                    </div>
                </v-container>
            </div>
            <div v-else>
                <h1 class="no-song">This playlist don't have any song.</h1>
            </div>

        </v-main>
    </v-app>
</template>

<script>


import BackGround from '../components/BackGround.vue'
import CreatePlaylistForm from './CreatePlaylistForm.vue';


export default {
    name: 'SongsPage',
    data() {
        return {
            button: require('../assets/images/next-button.png'),
            isloading: true,
            arrow: false,
            showPlayer: false,
            spotifyId: '',
            songId: 0,
            index1: 0,
            removeSng: "",
            songs: []

        };
    },
    computed: {
        songList() {
            return this.$store.state.Songs;
        },
    },
    components: {
        BackGround,
        CreatePlaylistForm
    },
    async mounted() {

        setTimeout(() => {
            this.$store.dispatch('getPlaybackStatus');
        }, 1000);
        // var query = window.location.hash.substring(1);
        // var params = new URLSearchParams(query);
        // var accessToken = params.get("accessToken");


        var url = window.location.href;
        var queryString = url.split('?')[1];
        if (queryString != null && queryString != undefined) {
            var accessToken = queryString.substring(12)
            
            // Buscar el índice del primer carácter '&' para obtener la posición del siguiente parámetro
            var ampersandIndex = accessToken.indexOf('%');

            // Obtener la subcadena desde el inicio hasta el índice del primer carácter '&'
            accessToken = accessToken.substring(0, ampersandIndex);
        }
        if (accessToken != null && accessToken != undefined) {
            this.$store.state.spotifyToken = accessToken;
            this.$store.dispatch('setSpotifyToken', accessToken)
        } else {
            accessToken = ""
        }

        if (this.$store.state.spotifyToken == "") {

            this.$store.dispatch('getSpotifyToken')
        }


        try {
            this.$store.dispatch('getSongs', { undefined, orderKey: undefined });
        } catch (error) {
            console.error('Error fetching song list:', error);
        } finally {
            this.isloading = false;
        }
    },
    methods: {
        deleteAlert(song) {
            this.dialog = true;
            this.removeSng = song;
        },
        deleteSongs(Songs) {
            this.songs = Songs;
            if (this.removeSng.owner) {
                this.songs.splice(this.index1, 1);
                this.$store.dispatch('deleteRow', { model: "playlist", id: this.removePl.playlistID });
            } else {
                this.songs.splice(this.index1, 1);
                this.$store.dispatch('deleteSong', this.removeSng.song.songID)
            }
        },
        async play(index) {

            this.$store.dispatch('getPlaybackStatus');

            let token = this.$store.state.spotifyToken


            let list = this.$store.state.Songs;

            const queue = []
            for (let i = index; i < list.length; i++) {
                queue.push(`spotify:track:${list[i].song.spotifySongID}`);

            }
            for (let i = 0; i < index; i++) {
                queue.push(`spotify:track:${list[i].song.spotifySongID}`);

            }

            const body = {
                uris: queue,
                "position_ms": 0,
                device_id: this.$store.state.device_id
            }


            fetch("https://api.spotify.com/v1/me/player/play", {
                method: "PUT",
                headers: {
                    Authorization: `Bearer ${token}`
                },
                body: JSON.stringify(body)

            }).then(() => {


                document.getElementById("play").src = this.$store.state.pauseBtn
            })
                .catch(e => console.log(e))



        },


        getSpotifyId(spotifyId) {
            this.spotifyId = spotifyId
        },
        getSongId(songId) {
            this.songId = songId
        },

        toggleArrow(event) {
            this.arrow = true;
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

@media(max-width: 1025px) {
    .grid {
        grid-template-columns: repeat(3, 1fr);
    }

    .deleteDuration {
        display: none;
    }

    #durationID {
        display: none;
    }
}

@media(max-width: 825px) {
    .grid {
        grid-template-columns: repeat(2, 1fr);
    }

    #artistID {
        display: none;
    }

    .deleteArtists {
        display: none !important;
    }
}

@media(max-width: 560px) {
    .grid {
        grid-template-columns: repeat(1, 1fr);
    }

    .deleteAlbum {
        display: none !important;

    }

    #albumID {
        display: none !important;
    }
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
