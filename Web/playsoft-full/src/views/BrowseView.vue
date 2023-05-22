<template>
    <div class="home">
        <BackGround></BackGround>
        <CabeceraPlaysoft></CabeceraPlaysoft>
        <SearchBar></SearchBar>
        <SearchCard></SearchCard>
    </div>
</template>
  
<script>
import CabeceraPlaysoft from '@/components/CabeceraPlaysoft.vue';
import SearchBar from '@/components/SearchBar.vue';
import SearchCard from '@/components/SearchCard.vue';
import BackGround from '@/components/BackGround.vue';

export default {
    name: 'HomeView',
    components: {
        CabeceraPlaysoft,
        SearchBar,
        SearchCard,
        BackGround
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
  