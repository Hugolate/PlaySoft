<template>
    <div class="home">
        <CabeceraPlaysoft></CabeceraPlaysoft>
        <CardsPlaylist></CardsPlaylist>
    </div>
</template>

<script>
import CabeceraPlaysoft from '@/components/CabeceraPlaysoft.vue';
import CardsPlaylist from '@/components/CardsPlaylist.vue'

export default {
  name: 'HomeView',
  components: {
    CabeceraPlaysoft, CardsPlaylist
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

