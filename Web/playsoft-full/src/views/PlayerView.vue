<template>
    <div class="home">
        <CabeceraPlaysoft></CabeceraPlaysoft>
        <PlayerComponent></PlayerComponent>
        <BackGround></BackGround>

    </div>
</template>
  
<script>
import PlayerComponent from '../components/PlayerComponent.vue';
import CabeceraPlaysoft from '../components/CabeceraPlaysoft.vue'
import BackGround from '@/components/BackGround.vue';

export default {
    name: 'HomeView',
    components: {
        PlayerComponent, CabeceraPlaysoft, BackGround
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

<style>
</style>
  