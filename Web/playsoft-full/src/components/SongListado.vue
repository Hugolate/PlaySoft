<template>
    <v-app id="inspire">
        <v-main class="pa-0">
            <section id="fondo" class="fondo1">
                <span v-for="(obj, index) in 900" :key="index">
                </span>
            </section>
            <AddSongForm></AddSongForm>
            <v-container class="fill-height secciones canciones" fluid style="justify-content: center;">
                <p id="animated" class="playlists wavy songs" v-for="song in this.$store.state.SongsLines"
                    :key="song.songID">{{
                        song.songName }}
                </p>
            </v-container>
        </v-main>
    </v-app>
</template>

<script>
import AddSongForm from './AddSongForm.vue';

export default {
    name: 'SongsPage',
    data() {
        return {
        };
    },
    components: {
        AddSongForm
    },
    mounted: async function () {
        this.$store.dispatch('getSongs')
    }
}
</script>

<style>
.songs {
    font-size: xx-large;
    color: white;
    z-index: 10;
    padding: 0px;
    color: white;
    text-shadow: 1px 1px 5px #e69cf8;
    letter-spacing: .3rem;
    cursor: pointer;
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
    align-items: stretch !important;
    align-content: center;
}

v-content {
    display: flex;
    justify-content: center;
    align-items: center;
    min-height: 350vh;
    background-color: black;
    padding: none !important;
}

.secciones {
    flex-direction: column;
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
    cursor: pointer;
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