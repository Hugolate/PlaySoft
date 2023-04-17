<template>
  <v-app-bar app>
    <div>
      <img :src="$store.state.logo" class="logo">
    </div>

    <div class="d-flex align-center">
      <h1 class="title"> PLAYSOFT </h1>
    </div>

    <v-spacer></v-spacer>
    <router-link to="/">
      <span class="mr-2" :class="item">Home</span>
    </router-link>
    <router-link to="/login" v-if="!this.$store.state.logged">
      <span class="mr-2" :class="item">Login</span>
    </router-link>
    <router-link to="/playlists" v-else-if="this.$store.state.logged">
      <div @click="cerrarSesion()">
        <span class="mr-2" :class="item">LogOut</span>
      </div>
    </router-link>

  </v-app-bar>
</template>

<script>
export default {
  name: 'CabeceraPlaysoft',
  data: function () {
    return {
    }
  },
  mounted: function comprobarUsuario() {
    //Comprobar si hay usuario
    // alert(this.$store.state.logged)
    // if (this.$store.state.logged) {
    //   this.$router.push({ path: '/playlists' })
    // } else if (!this.$store.state.logged) {
    //   this.$router.push({ path: '/' })
    // }
  },
  methods: {
    cerrarSesion() {
      localStorage.clear()
      this.$router.push({ path: '/' })
    }
  }
}
</script>

<style>
a {
  text-decoration: none;
}

h1 {
  color: rgb(118, 9, 113);
}

.logo {
  width: 3rem;
}

span {
  color: rgb(118, 9, 113);
  padding: 1rem;
}
</style>