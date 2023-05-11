<template>
    <v-app id="inspire">
        <v-main class="pa-0">
            <BackGround></BackGround>
            <v-container class="fill-height secciones" fluid style="justify-content: center;">
                <h1 class="text">Welcome to PlaySoft</h1>
                <h2 class="text">The music service of the future</h2>
            </v-container>
            <v-divider :thickness="20" class="border-opacity-100" color="white" style="position: sticky;"></v-divider>
            <v-container class="fill-height" fluid style="justify-content: center;">
                <h1 class="text" style="margin-top: 9rem;" v-motion-slide-visible-once-top :enter="{
                    scale: 2,
                }">Hear all the music that you want</h1>
                <v-container class="fill-height" fluid style="justify-content: space-around;">
                    <h2 class="text" v-motion-slide-visible-once-left :enter="{
                        scale: 2,
                    }">A new proyect from <em>NullSoft</em></h2>
                    <!-- <h2 class="text" v-motion-slide-visible-once-right>By Hugo Lahoz and Ricardo Ros</h2> -->
                    <img :src="$store.state.logo" width="300" style="z-index: 1;" v-motion-slide-visible-once-right>
                </v-container>
            </v-container>
            <v-container class="fill-height" fluid style="justify-content: space-around;">
                <v-card class="elevation-12" v-motion-roll-visible-once-bottom>
                    <v-card-text class="mt-12">
                        <h1 style="color: #6c176d">Register to start hearing now</h1>
                        <router-link to="/about">
                            <h2 style="padding-top: 5REM;">Go to login</h2>
                        </router-link>
                    </v-card-text>
                </v-card>
            </v-container>
        </v-main>
    </v-app>
</template>

<script>
import BackGround from '../components/BackGround.vue'

export default {
    name: 'HomePageNotLogin',
    data() {
        return {

        };
    },
    mounted: function () {
        if (this.$store.state.logged) {
            this.$router.push({ path: '/playlists' })
        } else if (!this.$store.state.logged) {
            this.$router.push({ path: '/' })
        }
    },
    components: { BackGround }
}
</script>

<style>
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