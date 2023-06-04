import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios';
import createPersistedState from 'vuex-persistedstate'
import router from '@/router';


Vue.use(Vuex)

export default new Vuex.Store({
    state: {
        logo: require('../assets/images/Logo.png'),
        buttonIcon: require('../assets/images/next-button.png'),
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
        logged: false,
        query: "",
        token: "",
        searchTracks: [],
        adminList: [],
        totalPages: 0,
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
            state.Songs = Songs
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
        },
        updateQuery(state, query) {
            state.query = query
        },
        setTracks(state, tracks) {
            state.searchTracks = tracks;
        },
        setToken(state, token) {
            state.token = token;
            axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;
        },
        setAdminList(state, list) {
            state.adminList = list
        },
        setCount(state, count) {
            state.totalPages = count / 10
        },
    },
    actions: {
        getPlaylistsAction({ commit, state }) {
            console.log(state.usuario)
            let IdUser = state.usuario
            axios.get(`https://tfgplaysoft.azurewebsites.net/User/${IdUser}`)
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
            axios.post("https://tfgplaysoft.azurewebsites.net/Auth/login", {
                email: state.loginEmail,
                password: state.loginPassword,
            })
                .then(function (response) {
                    commit("setUser", response.data.ukid)
                    commit("setToken", response.data.jwt);
                    commit("setLogged")
                    router.push({ path: '/playlists' }).catch(() => { });
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

        getSongs({ commit, state }, { order, orderKey }) {

            let url = (`https://tfgplaysoft.azurewebsites.net/Playlist/${state.PlayListsID}`);
            if (order != undefined && order != null && orderKey != undefined && orderKey != null) {
                url += `?orderKey=${orderKey}&order=${order}`
            }
            state.Songs = []
            axios.get(url)
                .then(function (response) {
                    console.log(response.data, "AA")
                    commit('setSongs', response.data)
                })

        },



        getPlaylistID({ commit }, id) {
            commit('setClickPlID', id)
        },

        checkSong({ commit }, name) {
            axios.get(`https://tfgplaysoft.azurewebsites.net/Search/${name}`)
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
        postSong({ state }, track) {
            
            
            let artistInDTO = []
            for (let index = 0; index < track.artists.length; index++) {
                let artistInDTOline = {
                    'spotifyArtistID': track.artists[index].id,
                    'artistName': track.artists[index].name
                }
                artistInDTO.push(artistInDTOline)
            }


            if (track.album.releaseDate.length < 10) {
                track.album.releaseDate = '2020-01-01'
            }

            axios.post('https://tfgplaysoft.azurewebsites.net/Song/create-with-artist-album',
                {
                    songInDTO: {
                        songID: 0,
                        spotifySongID: track.id,
                        songName: track.name,
                        durationMs: track.durationMs,
                        albumID: 0,
                        uri: track.uri,
                    },
                    albumInDTO: {
                        spotifyAlbumID: track.album.id,
                        albumName: track.album.name,
                        releaseDate: track.album.releaseDate,
                        image: track.album.images[0].url,
                        totalTracks: track.album.totalTracks,
                    },
                    artistInDTO

                })
                .then(function (response) {
                    alert('repsuesta: ' + response.data)
                    alert('PLID: ' + state.playlistID)
                    axios.post(`https://tfgplaysoft.azurewebsites.net/Playlist/${state.playlistID}/songs`, {
                        playlistID: state.playlistID,
                        songID: response.data
                    })
                        .then(function (response) {
                            alert(response);
                            location.reload();
                        })
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
                axios.post("https://tfgplaysoft.azurewebsites.net/Playlist", {
<<<<<<< HEAD
                        playListName: state.playListName,
                        ownerID: user,
                        playlistDescription: state.playlistDescription,
                        privacity: state.privacity,
=======
                    playListName: state.playListName,
                    userUKID: user,
                    playlistDescription: state.playlistDescription,
                    privacity: state.privacity,
>>>>>>> 416651f3c9058717a9dad413feedfd26352da2ac

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

                axios.post("https://api.spotify.com/v1/users/ytmm70rumumd5y3afug6uot9k/playlists", {
                    name: state.playListName,
                    description: state.playlistDescription,
                    public: state.privacity
                },
                    {
                        headers: {
                            'Authorization': 'BQCDHyBoju0dsA-wqSYM5JHRnUDxkhfo7d6tGw3MDS4VZQUwsGBvG-M8nLQkpAToUg5YR0gee0c7Pq9YTu-cWm_HthtnTjXI5vveuGHHHWzqImE6xcoWAZkfJzW7oTXxnMKkqE17MzXYe2imlXEIvc_kts90YdN1LRJkw61r3C2Sjb9H2BFogHAJrQKBu6VlykmAlmeWXxiB-DeO9IaiXYM8op_Q'
                        }
                    })
            } else {
                this.$store.state.error = true
            }

        },
        doRegister({ state }) {
            axios
                .post("https://tfgplaysoft.azurewebsites.net/Auth/register", {
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
        },

        deleteRow(context, payload) {
            const model = payload.model;
            const id = payload.id;

            let modelID = "";
            if (model == "song") {
                modelID = "songID";
            } else if (model == "artist") {
                modelID = "artistID";
            } else if (model == "album") {
                modelID == "albumID"
            }
            console.log(model, id, modelID)
            axios
                .delete(`https://tfgplaysoft.azurewebsites.net/${model}?${modelID}=${id}`)
                .catch(e => {
                    console.log(e);
                });
        },

        getAll({ commit }, payload) {
            const model = payload.model;
            const pageNumber = payload.pageNumber;
            axios
                .get(`https://tfgplaysoft.azurewebsites.net/${model}?pageNumber=${pageNumber}`)
                .then(function (response) {
                    commit('setAdminList', response.data);
                })
                .catch(e => {
                    console.log(e);
                });
        },

        getCount({ commit }, { model }) {
            axios
                .get(`https://tfgplaysoft.azurewebsites.net/${model}/count`)
                .then(function (response) {

                    commit('setCount', response.data);

                })
                .catch(e => {

                    console.log(e);
                });
        },

        Search({ commit, state }) {

            axios
                .get(`https://tfgplaysoft.azurewebsites.net/Search/${state.query}`)
                .then(function (response) {
                    //console.log(response.data.tracks.items);
                    commit("setTracks", response.data.tracks.items)

                })
                .catch(e => {

                    console.log(e);
                });
        }
    },
    plugins: [createPersistedState()]
})