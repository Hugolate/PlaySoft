<template>
  <div class="home">
    <CabeceraPlaysoft></CabeceraPlaysoft>
    <SearchBar></SearchBar>
    <HomePageNotLogin></HomePageNotLogin>
  </div>
</template>

<script>
import CabeceraPlaysoft from '@/components/CabeceraPlaysoft.vue';
import HomePageNotLogin from '@/components/HomePageNotLogin.vue';
import SearchBar from '@/components/SearchBar.vue';

export default {
  name: 'HomeView',
  components: {
    CabeceraPlaysoft,
    HomePageNotLogin,
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
