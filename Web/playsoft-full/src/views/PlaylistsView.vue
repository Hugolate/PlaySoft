<template>
  <div class="home">
    <BackGround></BackGround>
    <CabeceraPlaysoft></CabeceraPlaysoft>
    <SearchBar></SearchBar>
    <CardsPlaylist :PlayListsList="PlayListsList"></CardsPlaylist>

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
      PlayListsList: [],
      languages: [
        { title: "español", value: "es" },
        { title: "inglés", value: "en" },
      ],
    };
  },
  mounted: function () {
    let vue = this;
    if (!vue.$store.state.logged) {
      localStorage.clear()
      this.$router.push({ path: '/' }).catch(() => { });
    } else {
      this.$store.dispatch('getPlaylistsAction')
      setTimeout(() => {
        var PlayLists = JSON.parse(this.$store.state.PlayListsJSON);
        vue.PlayListsList = PlayLists
      }, 500);
    }

  },
}
</script>

<style></style>

