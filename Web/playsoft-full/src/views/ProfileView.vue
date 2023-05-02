<template>
    <div class="container">
        <div class="box"></div>
    </div>
</template>

<script>
import anime from 'animejs/lib/anime.es.js';

export default {
    name: 'app',
    mounted() {
        const options = {
            targets: ".box",
            translateX: 250,
            rotate: '1turn',
            backgroundColor: '#FFF',
            duration: 800
        }
        anime(options);
    }
}

</script>

<style>
body {
    background: #112;
}

.container {}

.box {
    height: 200px;
    width: 200px;
    background: linear-gradient(to bottom, purple, blue);
}
</style>