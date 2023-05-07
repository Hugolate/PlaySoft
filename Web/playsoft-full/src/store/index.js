import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios';
import createPersistedState from 'vuex-persistedstate'
import router from '@/router';


Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    logo: require('../assets/images/Logo.png'),
    profilePicture: require('../assets/images/profile-icon.png'),
    infoPicture: require('../assets/images/info.png'),
    stylePicture: require('../assets/images/style.png'),
    settingPicture: require('../assets/images/settings.png'),
    logoutPicture: require('../assets/images/logout.png'),
    comprobarUsuario: false,
    registerUsername: "",
    registerEmail: "",
    registerPassword: "",
    repeatPassword: "",
    loginEmail: "",
    loginPassword: "",
    alertMessage: "",
    registerError: false,
    loginError: false,
    step: 1,
    PlayLists: [],
    ventana: false,
    playListName: "",
    playlistDescription: "",
    privacity: true,
    ukid: "",
    error: false,
    messages: [],
    drafts: [],
    sent: [],
    dialogCompose: false,
    activeMessage: {},
    composeMessage: {},
    valid: true,
    songName: "",
    errorSong: false,
    messagesSong: [],
    draftsSong: [],
    alertMessageSong: "",
    sentSong: [],
    dialogComposeSong: false,
    activeMessageSong: {},
    composeMessageSong: {},
    validSong: true,
    usuario: "",
    Songs: [],
    SongsLines: [],
    PlayListsID: 0,
    addSong: null,
    logged: false

  },
  getters: {
    getUsuario(state) {
      return state.usuario;
    }
  },
  mutations: {
    setPlaylists(state, playlists) {
      state.PlayListsJSON = playlists
    },
    setUser(state, user) {
      state.usuario = user;
    },
    setSongs(state, Songs) {
      state.Songs = Songs;
    },
    setClickPlID(state, Id) {
      state.PlayListsID = Id
    },
    setSongsLines(state, songs) {
      state.SongsLines.push(JSON.parse(songs))
    },
    setAddSong(state, song) {
      state.addSong = song;
    },
    setLogged(state) {
      state.logged = true
    },
    clearForm(state) {
      state.playListName = ""
      state.playlistDescription = ""
    }
  },
  actions: {
    getPlaylistsAction({ commit, state }) {
      let IdUser = state.usuario
      axios.get(`https://playsoft-api.azurewebsites.net/User/${IdUser}`)
        .then(function (response) {
          state.PlayListsJSON = JSON.stringify(response.data.playlists);
          commit('setPlaylists', state.PlayListsJSON)
        })
        .catch(e => {
          state.loginError = true;
          state.alertMessage = "No playlists";
          console.log(e);
        });
    },

    doLogin({ commit, state }) {
      axios.post("https://playsoft-api.azurewebsites.net/Auth/login", {
        email: state.loginEmail,
        password: state.loginPassword,
      })
        .then(function (response) {
          console.log(response);
          commit("setUser", response.data.ukid)
          commit("setLogged")
          router.push({ path: '/playlists' })
          return true;
        })
        .catch(e => {
          state.loginError = true;
          state.alertMessage = "This account doesn't exist";
          console.log(e);
          return false
        })
      return false;
    },

    getSongs({ commit, state }) {
      state.Songs = []
      state.SongsLines = []
      axios.get(`https://playsoft-api.azurewebsites.net/Playlist/${state.PlayListsID}?orderKey=songName&order=asc`)
        .then(function (response) {
          commit('setSongs', JSON.stringify(response.data))
          var songs = []
          songs = JSON.parse(state.Songs);
          for (let index = 0; index < songs.length; index++) {
            var SongsLines = []
            axios.get(`https://playsoft-api.azurewebsites.net/Song/${songs[index].song.songID}`)
              .then(function (respuesta) {
                SongsLines = JSON.stringify(respuesta.data)
                commit('setSongsLines', SongsLines)
              })
          }
        })
    },
    getPlaylistID({ commit }, id) {
      commit('setClickPlID', id)
    },

    checkSong({ commit }, name) {
      axios.get(`https://playsoft-api.azurewebsites.net/Search/${name}`)
        .then(function (respuesta) {
          if (respuesta.data.songs.length > 0) {
            let song = respuesta.data.songs[0]
            console.log(song)
            console.log('la cancion es: ' + song.songName)
            commit('setAddSong', song)
          } else {
            alert('Esta cancion no existe')
            this.alertMessage = "This song doesn't exist";
          }
        })
        .catch(e => {
          this.alertMessage = "This song doesn't exist";
          this.error = true;
          console.log(e);
        });
    },
    postSong({ state }) {
      axios.post('https://playsoft-api.azurewebsites.net/Song', {
        playlistID: state.PlayListsID,
        songID: state.addSong.songID,
      })
        .then(function (response) {
          response.data
          location.reload();
        })
        .catch(e => {
          this.alertMessage = "Playlist already have this song"
          this.error = true;
          console.log(e);
        });
    },
    addPlaylist({ commit, dispatch, state }) {
      if (state.playListName != "") {
        var user = state.usuario.toString()
        axios.post("https://playsoft-api.azurewebsites.net/Playlist", {
          playListName: state.playListName,
          userUKID: user,
          playlistDescription: state.playlistDescription,
          privacity: state.privacity,

        })
          .then(function (response) {
            response.data
            dispatch('getPlaylistsAction')
            setTimeout(function () {
              commit('clearForm');
              location.reload();
            }, 1000);

          })
          .catch(e => {
            state.loginError = true;
            state.alertMessage = "Error create playlist";
            console.log(e);
          });
      } else {
        this.$store.state.error = true
      }

    },
    doRegister({ state }) {
      axios
        .post("https://playsoft-api.azurewebsites.net/Auth/register", {
          email: state.registerEmail,
          username: state.registerUsername,
          password: state.registerPassword,
        })
        .then(function (response) {
          console.log(response);
          location.reload();

        })
        .catch(e => {
          this.alertMessage = "Email already in use";
          this.registerError = true;
          console.log(e);
        });
    }
  },
  plugins: [createPersistedState()]
})
