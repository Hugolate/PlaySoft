<template>
    <div class="home">
        <CabeceraPlaysoft></CabeceraPlaysoft>
        <SearchBar></SearchBar>
    </div>
</template>
  
<script>
import CabeceraPlaysoft from '@/components/CabeceraPlaysoft.vue';
import SearchBar from '@/components/SearchBar.vue';

export default {
    name: 'HomeView',
    components: {
        CabeceraPlaysoft,
        SearchBar
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
  