<template>
  <div class="about">
    <CabeceraPlaysoft></CabeceraPlaysoft>
    <LoginCard></LoginCard>
  </div>
</template>

<script>
import LoginCard from '../components/LoginCard.vue'
import CabeceraPlaysoft from '../components/CabeceraPlaysoft.vue'

export default {
  name: 'AboutPage',
  components: {
    CabeceraPlaysoft, LoginCard
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
