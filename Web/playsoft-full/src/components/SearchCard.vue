<template>
    <div class="cont">
        <div class="all-cards">
            <div class="crd">
                <v-card class="mx-auto" max-width="400" min-width="400" border-radius="15"
                    style="background-color: rgb(34, 31, 34);" v-for="(track, index) in this.$store.state.searchTracks"
                    :key="track.id" outlined>
                    <v-list-item three-line>
                        <v-list-item-content style=" margin-right: 20px; align-self:normal">
                            <v-list-item-title class="text-h5 mb-1 txt" style="text-align: start; cursor: pointer;"
                                @click="getSpotifyId(track.id); showPlayer = true">
                                {{ track.name }}
                            </v-list-item-title>
                            <v-list-item-subtitle style="text-align: start; color: rgb(173, 173, 173);">{{ track.album.name
                            }}</v-list-item-subtitle>
                        </v-list-item-content>
                        <div>
                            <img :src="track.album.images[0].url" style="width: 80px; margin-top: 10px;" alt="">
                            <div class="txt">{{ track.artists[0].name }}</div>
                        </div>
                    </v-list-item>
                    <div class="save-btn">
                        <button @click="showModal = true; getTrack(index)">Add to...</button>
                    </div>
                </v-card>
            </div>
            <div class="crd">
                <v-card class="mx-auto crd" max-width="400" min-width="400" border-radius="15"
                    style="background-color: rgb(34, 31, 34);"
                    v-for="(playlist, index) in this.$store.state.searchPlaylists" :key="playlist.playlistID" outlined>
                    <v-list-item three-line>
                        <v-list-item-content style=" margin-right: 20px;color: gray; align-self:normal">
                            <v-list-item-title @click="redirect(playlist.playlistID)" class="text-h5 mb-1 txt"
                                style="text-align: start; cursor: pointer;" showPlayer="true">
                                {{ playlist.playListName }}

                            </v-list-item-title>
                            {{ playlist.playlistDescription }}
                        </v-list-item-content>
                    </v-list-item>
                    <div class="save-btn">
                        <button @click="addToLibrary(index)">Add to library </button>
                    </div>
                </v-card>
            </div>
        </div>
        <ModalPlaylists v-if="showModal" @close-modal="showModal = false" :PlayListsList="PlayListsList"
            :track="$store.state.searchTracks[trackId]" :index="index" />
        <iframe v-if="showPlayer" style="border-radius: 0px;
    left: 0;
    position: fixed;
    z-index: 7;
    bottom: 0px;
    width: 100%;
    height: 80px; " :src="'https://open.spotify.com/embed/track/' + spotifyId + '?utm_source=generator'" width="100%"
            height="352" frameBorder="0" allowfullscreen=""
            allow="autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture" loading="lazy">
        </iframe>
    </div>
</template>
<script>

import ModalPlaylists from '../components/ModalPlaylists.vue';

export default {
    components: { ModalPlaylists },
    props: ["PlayListsList"],
    data: function () {
        return {
            showModal: false,
            showPlayer: false,
            trackId: 0,
            playlistId: 0,
            spotifyId: ''
        }
    },

    methods: {
        getTrack(trackId) {
            console.log(trackId)
            this.trackId = trackId
        },
        addToLibrary(index) {
            var playlist = this.$store.state.searchPlaylists[index];
            this.$store.dispatch('addToLibrary', playlist)
        },
        getSpotifyId(spotifyId) {
            this.spotifyId = spotifyId
        },
        redirect(id) {
            console.log(id)
            this.$store.dispatch('getPlaylistID', id)
            this.$router.push({ path: '/songs' })
        },
    }
}

</script>

<style>
.all-cards {
    display: flex;
    flex-direction: row;
    gap: 200px;
}

.save-btn {
    background-color: rgba(128, 0, 128, 0.461);
    border-radius: 15px;
    padding: 5px;
    cursor: pointer;
}

.save-btn:hover {
    background-color: rgb(128, 0, 128);
}

.cont {
    display: flex;
    flex-direction: column;
    /* margin-top: 200px; */
    margin-left: 40px;
    gap: 15px;
    align-items: center;
}

.fondo2 {
    position: absolute;
    width: 100vw;
    height: 100vh;
    display: flex;
    justify-content: center;
    align-items: center;
    gap: 2px;
    flex-wrap: wrap;
    overflow: hidden;
    z-index: 0;
    background: gray;
}

.txt {
    color: rgb(219, 219, 219);
}

.dropbtn {
    background-color: #b734db;
    color: white;
    padding: 16px;
    font-size: 16px;
    border: none;
    cursor: pointer;
    border-radius: 20px;
}

.dropbtn:hover,
.dropbtn:focus {
    background-color: #3b0454;
}

.dropdown {
    position: relative;
    display: inline-block;
}

.dropdown-content {
    display: none;
    position: absolute;
    background-color: #f1f1f1;
    min-width: 160px;
    overflow: auto;
    box-shadow: 0px 8px 16px 0px rgba(0, 0, 0, 0.2);
    z-index: 1;
}

.dropdown-content a {
    color: black;
    padding: 12px 16px;
    text-decoration: none;
    display: block;
}

.dropdown a:hover {
    background-color: #ddd;
}

.show {
    display: block;
}

.crd {
    display: flex;
    flex-direction: column;
    gap: 20px;
}
</style>

