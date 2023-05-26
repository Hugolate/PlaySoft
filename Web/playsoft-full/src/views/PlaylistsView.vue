<template>
  <div class="home">
    <BackGround></BackGround>
    <CabeceraPlaysoft></CabeceraPlaysoft>
    <SearchBar class="hola"></SearchBar>
    <CardsPlaylist></CardsPlaylist>

  </div>
</template>

<script>
import CabeceraPlaysoft from '@/components/CabeceraPlaysoft.vue';
import CardsPlaylist from '@/components/CardsPlaylist.vue'
import SearchBar from '@/components/SearchBar.vue';
import BackGround from '@/components/BackGround.vue';


export default {
  name: 'HomeView',
  components: {
    CabeceraPlaysoft, CardsPlaylist, SearchBar, BackGround
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
.hola {}
</style>

