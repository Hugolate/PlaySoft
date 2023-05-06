<template>
    <div class="container">
        <CabeceraPlaysoft></CabeceraPlaysoft>
        <section id="fondo" class="fondo1">
            <span v-for="(obj, index) in 900" :key="index">
            </span>
        </section>
        <div class="containers">
            <div class="menu"></div>
            <div class="vertical-menu"></div>
        </div>
    </div>
</template>

<script>
import anime from 'animejs/lib/anime.es.js';
import CabeceraPlaysoft from '@/components/CabeceraPlaysoft.vue';

export default {

    name: 'app',
    components: {
        CabeceraPlaysoft
    },
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
.menu {
    background-color: #ccc;
    height: 200px;
    width: 100%;
    z-index: 1;
}

.vertical-menu {
    background-color: #fff;
    height: 100px;
    width: 80%;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
}

.container {
    display: flex;
    justify-content: center;
}

.box {
    height: 200px;
    width: 200px;
    background: linear-gradient(to bottom, purple, blue);
}

.prueba {}

.prueba path {
    stroke-dasharray: 1000;
    stroke-dashoffset: 0;
}

.fondo1 {
    position: absolute;
    width: 100vw;
    height: 200vh;
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