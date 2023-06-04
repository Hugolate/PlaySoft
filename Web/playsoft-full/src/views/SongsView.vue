<template>
    <div>
        <CabeceraPlaysoft></CabeceraPlaysoft>
        <SongListado></SongListado>
        <SearchBar style="position: absolute; top: 20%; left: 0%;"></SearchBar>
    </div>
</template> 

<script>
import CabeceraPlaysoft from '@/components/CabeceraPlaysoft.vue';
import SongListado from '@/components/SongListado.vue';
import SearchBar from '@/components/SearchBar.vue';

export default {
    name: 'HomeView',
    components: {
        CabeceraPlaysoft, SongListado, SearchBar
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