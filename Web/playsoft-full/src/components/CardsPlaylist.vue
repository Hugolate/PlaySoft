<template>
    <v-app id="inspire">
        <v-main class="pa-0" style="z-index: 0; ">
            <BackGround></BackGround>
            <CreatePlaylistForm></CreatePlaylistForm>
            <v-container style="flex-direction: column;" class="fill-height secciones pl-cont">
                <p @click="redirigir(playlist.playlist.playListName)"
                    v-on:click.right.prevent="deleteAlert(playlist.playlist); index1 = index" id="animated"
                    class="playlists wavy" v-for="(playlist, index) in PlayListsList" :key="playlist.playlist.playlistID">{{
                        playlist.playlist.playListName }}

                    <v-dialog v-model="dialog" width="500">
                        <v-card>
                            <v-card-title class="headline grey lighten-2" primary-title>
                                Delete/Remove list?
                            </v-card-title>

                            <v-card-text
                                style="display: flex; flex-direction: column;justify-content: center;align-items: center;margin-top: 15px">
                                <h2>{{ removePl.playListName }}</h2>
                                <p>{{ removePl.playlistDescription }}</p>
                            </v-card-text>
                            <v-divider></v-divider>
                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-btn color="blue-grey darken-1" @click="dialog = false" style="color: white;">
                                    Cancel
                                </v-btn>
                                <v-btn @click="deleteLibrary(PlayListsList), dialog = false;" color="red darken-1"
                                    style="color: white;">
                                    Delete
                                </v-btn>
                            </v-card-actions>
                        </v-card>
                    </v-dialog>
                </p>
            </v-container>
        </v-main>
    </v-app>
</template>

<script>
import BackGround from '../components/BackGround.vue'
import CreatePlaylistForm from './CreatePlaylistForm.vue';
export default {
    name: 'PlayList',
    props: ["productItem", "PlayListsList"],
    data: function () {
        return {
            playLists: [],
            dialog: false,
            removePl: "",
            index1: 0
        }
    },
    components: { CreatePlaylistForm, BackGround },
    mounted: function logged() {

    },
    methods: {
        redirigir(nombrepl) {

            let vue = this;
            console.log(vue.PlayListsList[0].playlist)
            for (let index = 0; index < vue.PlayListsList.length; index++) {
                if (vue.PlayListsList[index].playlist.playListName == nombrepl) {
                    console.log(vue.PlayListsList[index].playlist.playlistID)
                    this.$store.dispatch('getPlaylistID', vue.PlayListsList[index].playlist.playlistID)
                    this.$router.push({ path: '/songs' })
                }
            }
        },
        deleteAlert(playlist) {
            console.log(playlist)
            this.dialog = true;
            this.removePl = playlist;
        },

        deleteLibrary(PlayListsList) {
            this.playLists = PlayListsList;
            if (this.removePl.owner) {
                this.playLists.splice(this.index1, 1);
                this.$store.dispatch('deleteRow', { model: "playlist", id: this.removePl.playlistID });
            } else {
                this.playLists.splice(this.index1, 1);
                this.$store.dispatch('deleteLibrary', this.removePl.playlistID)
            }
        }
    }

}

</script>

<style scoped>
p {
    font-size: 1.5vw;
}

@media(max-width: 1400px) {
    p {
        font-size: 2vw;
    }
}
@media(max-width: 875px) {
    p {
        font-size: 3vw;
    }
}
@media(max-width: 414px) {
    p {
        font-size: 4vw;
    }
}


.wavy {
    animation-name: wavy;
    animation-duration: 2.3s;
    animation-timing-function: ease;
    animation-iteration-count: infinite;
    position: relative;
    top: 0;
    left: 0;
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

.pl-cont {
    padding: 0;

    justify-content: center;
}

.playlists {
    color: white;
    z-index: 10;
    padding: 0px;
    color: white;
    text-shadow: 1px 1px 5px #e69cf8;
    letter-spacing: .3rem;
    cursor: pointer;
}

.carta {
    display: flex;
    flex-direction: column;
    align-items: center;
}

.secciones {
    flex-direction: row;
}

.text {
    z-index: 2;
    color: white;
    text-align: center;
}

section {
    position: absolute;
    width: 100vw;
    height: 350vh;
    display: flex;
    justify-content: center;
    align-items: center;
    gap: 2px;
    flex-wrap: wrap;
    overflow: hidden;
    z-index: -1;
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