<template>
  <v-app-bar app>
    <router-link to="/">
      <div>
        <img :src="$store.state.logo" class="logo">
      </div>
    </router-link>

    <div class="d-flex align-center">
      <h1 class="title"> PLAYSOFT </h1>
    </div>

    <v-spacer></v-spacer>
    <router-link to="/">
      <span class="mr-2 homeIcon">Home</span>
    </router-link>
    <router-link to="/login" v-if="!this.$store.state.logged">
      <span class="mr-2 loginIcon">Login</span>
    </router-link>
    <!-- <router-link to="/" v-else-if="this.$store.state.logged">
      <div @click="cerrarSesion()">
        <span class="mr-2" >LogOut</span>
      </div>
    </router-link> -->
    <div v-else-if="this.$store.state.logged">
      <span class="mr-2"><img :src="$store.state.logo" alt="" width="50px" @click="displayMenu()"
          style="cursor: pointer;"></span>
    </div>
    <div class="sub-menu-wrap" id="subMenu">
      <div class="sub-menu">
        <div class="user-info">
          <img :src="$store.state.logo">
          <h3>Welcome, {{ this.$store.state.loginEmail.split("@")[0] }}!</h3>
        </div>
        <hr>

        <!-- <a class="sub-menu-link" style="cursor: pointer;">
          <img :src="$store.state.settingPicture" alt="">
          <p>Settings</p>
          <span>></span>
        </a> -->

        <a class="sub-menu-link" style="cursor: pointer;" @click="cerrarSesion()">
          <img :src="$store.state.logoutPicture" alt="">
          <p>Log Out</p>
          <span>></span>
        </a>

      </div>
    </div>

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
      this.$store.state.logged = false;
      localStorage.clear()
      setTimeout(() => {
        this.$router.push('/').catch(() => { });
        location.reload();
      }, 500);

    },
    displayMenu() {
      let subMenu = document.getElementById("subMenu")
      subMenu.classList.toggle("open-menu")
    }
  }
}
</script>

<style>
.sub-menu-wrap {
  position: absolute;
  top: 100%;
  right: 1%;
  width: 320px;
  max-height: 0px;
  overflow: hidden;
  transition: max-height 0.5s;
}

.sub-menu-wrap.open-menu {
  max-height: 400px;
}

.sub-menu {
  background-color: #fff;
  padding: 20px;
  margin: 10px;
  border-radius: 3%;
}

.user-info {
  display: flex;
  align-items: center;
}

.sub-menu hr {
  border: 0;
  height: 1px;
  width: 100%;
  background: #ccc;
  margin: 15px 0 10px;
}

.sub-menu-link {
  display: flex;
  align-items: center;
  text-decoration: none;
  color: #525252;
  margin: 12px 0;
}

.sub-menu-link p {
  width: 100%;
}

.sub-menu-link span {
  font-size: 22px;
  transition: transform 0.5s;
}

.sub-menu-link:hover span {
  transform: translateX(5px);
}

.sub-menu-link:hover p {
  font-weight: 600;
}

.sub-menu-link img {
  width: 40px;
  background: #e5e5e5;
  border-radius: 50%;
  padding: 8px;
  margin-right: 15px;
}

.user-info h3 {
  font-weight: 500;
}

.user-info img {
  width: 60px;
  border-radius: 50%;
  margin-right: 15px;
}

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

@media(max-width: 400px) {
  .homeIcon {
    display: none;
  }

  header {
    display: flex;
    justify-content: center;
  }
}
</style>