<template>
  <div class="contenedor_span" @click="animaciones()">
  </div>
</template>

<script>
import { anim } from '../assets/scripts/BackgroundAnim'
export default {
  name: "NoSE",
  methods: {
    animaciones() {
      anim()
    }
  },
  mounted: {
    animaciones() {
      anim()
    }
  }
}
</script>

<style>
body {
    background-color: #0f021d;
    display: grid;
    place-items: center;
    height: 100vh;
    font-family: 'Quicksand', sans-serif;
    overflow: hidden;
    margin: 0;
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