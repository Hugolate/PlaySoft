<template>
  <v-app-bar app>

    <img :src="logo" class="logo">


    <div class="d-flex align-center">
      <h1 class="title"> PLAYSOFT </h1>
    </div>

    <v-spacer></v-spacer>

    <v-btn href="Menuawd.vue" target="_blank" text >
      <span class="mr-2" :class="item" >Menu</span>
    </v-btn>
    <v-btn href="" target="_blank" text>
      <span class="mr-2">Login</span>
    </v-btn>
    <v-btn href="" target="_blank" text>
      <span class="mr-2">Register</span>
    </v-btn>
  </v-app-bar>
</template>

<script>
export default {
  name: 'CabeceraPlaysoft',
  data: function () {
    return {
      logo: require('../assets/images/Logo.png'),
      menu: ('../Menu.vue')
    }
  }
}
</script>

<style>
h1 {
  color: rgb(118, 9, 113);
}

.logo {
  width: 3rem;
}

span{
  color: rgb(118, 9, 113);
}
</style>