<template>
    <div class="home">
        <CabeceraPlaysoft></CabeceraPlaysoft>
        <CardsPlaylist></CardsPlaylist>
        <SearchBar></SearchBar>
    </div>
</template>

<script>
import CabeceraPlaysoft from '@/components/CabeceraPlaysoft.vue';
import CardsPlaylist from '@/components/CardsPlaylist.vue'
import SearchBar from '@/components/SearchBar.vue';

export default {
  name: 'HomeView',
  components: {
    CabeceraPlaysoft, CardsPlaylist, SearchBar
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

