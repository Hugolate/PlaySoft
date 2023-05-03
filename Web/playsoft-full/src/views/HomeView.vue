<template>
  <div class="home">
    <CabeceraPlaysoft></CabeceraPlaysoft>
    <HomePageNotLogin></HomePageNotLogin>
    <SearchCard></SearchCard>
  </div>
</template>

<script>
import CabeceraPlaysoft from '@/components/CabeceraPlaysoft.vue';
import HomePageNotLogin from '@/components/HomePageNotLogin.vue';
import SearchCard from '@/components/SearchCard.vue';
export default {
  name: 'HomeView',
  components: {
    CabeceraPlaysoft, HomePageNotLogin, SearchCard
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
