<template>
  <div class="home">
    <BackGround></BackGround>
    <CabeceraPlaysoft></CabeceraPlaysoft>
    <HomePageNotLogin></HomePageNotLogin>
    <SearchCard></SearchCard>
  </div>
</template>

<script>
import CabeceraPlaysoft from '@/components/CabeceraPlaysoft.vue';
import HomePageNotLogin from '@/components/HomePageNotLogin.vue';
import BackGround from '@/components/BackGround.vue';


export default {
  name: 'HomeView',
  components: {
    CabeceraPlaysoft,
    HomePageNotLogin,
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
