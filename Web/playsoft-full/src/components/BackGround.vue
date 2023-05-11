<template>
  <section id="fondo" class="fondo1">
        <template v-for="(obj, index) in 900">
            <span :key="index" @click="animaciones(index)" class="background-span">
            </span>
        </template>
    </section>
</template>

<script>
import { anim } from '../assets/scripts/BackgroundAnim'
export default {
  name: "NoSE",
  methods: {
        animaciones(index) {
            anim(index)
        }
    },
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
    animation: animate 5s linear infinite;
}

#fondo {
    display: grid;
    grid-template-columns: repeat(18, 1fr);
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
    background: rgb(128, 0, 128) !important;
    transition: 0s !important;
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

.contenedor_span {
    position: absolute;
    left: 0;
    top: 0;
    display: grid;
    width: 100%;
    height: 100%;
    background: rgb(2, 0, 36);
    background: linear-gradient(90deg, rgba(2, 0, 36, 1) 0%, rgba(73, 30, 89, 1) 47%, rgba(61, 0, 74, 1) 100%);
    background-size: 200% 200%;
}

.span {
    place-self: center;
    display: block;
    width: 98%;
    height: 99%;
    background-color: rgb(22, 7, 41);
    z-index: 3;
}
</style>