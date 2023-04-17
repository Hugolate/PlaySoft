<template>
  <div class="home">
    <CabeceraPlaysoft></CabeceraPlaysoft>
    <HomePageNotLogin></HomePageNotLogin>
  </div>
</template>

<script>
import CabeceraPlaysoft from '@/components/CabeceraPlaysoft.vue';
import HomePageNotLogin from '@/components/HomePageNotLogin.vue';

export default {
  name: 'HomeView',
  components: {
    CabeceraPlaysoft, HomePageNotLogin
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
