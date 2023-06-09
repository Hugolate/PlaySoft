<template>
    <div>
        <CabeceraPlaysoft></CabeceraPlaysoft>
        <PlayerComponent ></PlayerComponent>
        <SongListado></SongListado> SongListado>

        <SearchBar style="position: absolute; top: 20%; left: 0%;"></SearchBar>
    </div>
</template> 

<script>
import CabeceraPlaysoft from '@/components/CabeceraPlaysoft.vue';
import SongListado from '@/components/SongListado.vue';
import SearchBar from '@/components/SearchBar.vue';
import PlayerComponent from '../components/PlayerComponent.vue';

export default {
    name: 'HomeView',
    components: {
        CabeceraPlaysoft,
        SongListado,
        SearchBar,
        PlayerComponent
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