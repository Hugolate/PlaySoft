<template>
    <div class="home">
        <BackGround></BackGround>
        <CabeceraPlaysoft></CabeceraPlaysoft>
        <SearchBar></SearchBar>
        <SearchCard :PlayListsList="PlayListsList"></SearchCard>
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
            PlayListsList: [],
            languages: [
                { title: "español", value: "es" },
                { title: "inglés", value: "en" },
            ],
        };
    }, 
    mounted: function () {
        let vue = this;
        this.$store.dispatch('getPlaylistsAction')
        var PlayLists = JSON.parse(this.$store.state.PlayListsJSON);
        vue.PlayListsList = PlayLists
        
        
    },
}
</script>

<style></style>
  