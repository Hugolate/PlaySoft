<template>
    <v-app id="inspire">
        <v-main class="pa-0">
            <section id="fondo" class="fondo1">
                <span v-for="(obj, index) in 900" :key="index">
                </span>
            </section>
            <v-container class="fill-height secciones" fluid style="justify-content: center;">
                <div class="menu">
                    <div>
                        <img :src="$store.state.profilePicture" class="logo">
                    </div>
                    <div>
                        <img :src="$store.state.stylePicture" class="logo">
                    </div>
                    <div>
                        <img :src="$store.state.infoPicture" class="logo">
                    </div>

                </div>
                <div class="vertical-menu"></div>
            </v-container>
        </v-main>
    </v-app>
</template>

<script>
import anime from 'animejs/lib/anime.es.js';
export default {

    name: 'app',
    mounted() {
        const options = {
            targets: '.box',
            left: '240px',
            backgroundColor: '#FFF',
            borderRadius: ['0%', '50%'],
            easing: 'easeInOutQuad',
            translateX: 400
        }
        anime(options);
        const options2 = {
            targets: '.prueba path',
            strokeDashoffset: [anime.setDashoffset, 0],
            easing: 'easeInOutQuad',
            duration: 5000,
            direction: 'alrenate',
            loop: true
        }
        anime(options2);
    }
}
</script>

<style>
v-content {
    display: flex;
    justify-content: center;
    align-items: center;
    min-height: 100vh;
    background-color: black;
    padding: none !important;
}

.menu {
    background-color: #760971;
    height: 43vh;
    width: 81px;
    top: 50%;
    right: 64%;
    position: absolute;
    transform: translate(-50%, -50%);
    z-index: 1;
    display: flex;
    align-items: center;
    justify-content: space-evenly;
    flex-direction: column;
}

.vertical-menu {
    background-color: #fff;
    height: 43vh;
    width: 60vw;
    position: absolute;
    top: 50%;
    left: 54%;
    transform: translate(-50%, -50%);
}

@media(min-width: 1000px) {
    .vertical-menu {
        width: 50vw;
    }
}

@media(min-width: 1600px) {
    .vertical-menu {
        width: 45vw;
    }
}

.secciones {
    flex-direction: row;
}

.fondo1 {
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