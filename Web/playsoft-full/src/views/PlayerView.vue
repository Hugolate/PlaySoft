<template>
    <div class="home">
    <PlayerSongs></PlayerSongs>
    </div>
</template>
  
<script>
import PlayerSongs from '../components/PlayerSongs.vue';

export default {
    name: 'HomeView',
    components: {
        PlayerSongs
    },
    data() {
        return {
            languages: [
                { title: "español", value: "es" },
                { title: "inglés", value: "en" },
            ],
        };
    },
}
</script>

<style></style>
  