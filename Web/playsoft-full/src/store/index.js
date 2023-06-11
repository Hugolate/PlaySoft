import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios';
import createPersistedState from 'vuex-persistedstate'
import router from '@/router';
import Swal from 'sweetalert2'


Vue.use(Vuex)

export default new Vuex.Store({


    state: {
        logo: require('../assets/images/Logo.png'),
        settings: require('../assets/images/setting.png'),
        buttonIcon: require('../assets/images/next-button.png'),
        logoutPicture: require('../assets/images/logout.png'),
        adminIcon: require('../assets/images/adminIcon.png'),
        nextSong: require('../assets/images/nextSong.png'),
        previousSong: require('../assets/images/previousSong.png'),
        playBtn: require('../assets/images/play.png'),
        pauseBtn: require('../assets/images/pauseBtn.png'),
        comprobarUsuario: false,
        registerUsername: "",
        registerEmail: "",
        registerPassword: "",
        repeatPassword: "",
        loginEmail: "",
        loginPassword: "",
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
        searchPlaylists: [],
        adminList: [],
        totalPages: 0,
        spotifyToken: "",
        device_id: "",
        player: "",
        currentPlayingID: null,
        currentImage: ""
    },
    getters: {
        getUsuario(state) {
            return state.usuario;
        }
    },
    mutations: {
        setSpotifyToken(state, token) {
            state.spotifyToken = token
        },
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
            for (let i = 0; i < 10; i++)
                state.searchTracks.pop()
        },
        setSearchPlaylists(state, playlists) {
            state.searchPlaylists = playlists;
        },
        setToken(state, token) {
            state.token = token;
            axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;
        },
        setAdminList(state, list) {
            state.adminList = list
        },

        setCount(state, count) {
            state.totalPages = Math.ceil(count / 10)
        },

    },
    actions: {

        getPlaylistsAction({ commit, state }) {
            let IdUser = state.usuario
            axios.get(`https://tfgplaysoft.azurewebsites.net/User/${IdUser}`)
                .then(function(response) {
                    state.PlayListsJSON = JSON.stringify(response.data.libraries);
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
                .then(function(response) {
                    commit("setUser", response.data.ukid)
                    commit("setToken", response.data.jwt);
                    commit("setLogged")
                    router.push({ path: '/playlists' }).catch(() => {});
                    return true;
                })
                .catch(e => {

                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: "This account doesn't exist",
                    })
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
                .then(function(response) {
                    console.log(response.data)
                    commit('setSongs', response.data)
                }).catch(() => { });

        },



        getPlaylistID({ commit }, id) {
            commit('setClickPlID', id)
        },

        checkSong({ commit }, name) {
            axios.get(`https://tfgplaysoft.azurewebsites.net/Search/${name}`)
                .then(function(respuesta) {
                    if (respuesta.data.songs.length > 0) {
                        let song = respuesta.data.songs[0]
                        console.log('la cancion es: ' + song.songName)
                        commit('setAddSong', song)
                    } else {

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

            axios.post('https://tfgplaysoft.azurewebsites.net/Song/create-with-artist-album', {
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

                    axios.post(`https://tfgplaysoft.azurewebsites.net/Playlist/${state.playlistID}/songs`, {
                        playlistID: state.playlistID,
                        songID: response.data
                    })
                        .then(function () {

                            location.reload();
                        })
                        .catch(e => {
                            state.alertMessage = "Playlist already have this song"
                            state.error = true;
                            console.log(e);
                        });
                })
                .catch(e => {
                    console.log(e);
                });

        },

        addPlaylist({ commit, dispatch, state }) {
            if (state.playListName != "") {
                var user = state.usuario.toString()
                axios.post("https://tfgplaysoft.azurewebsites.net/Playlist", {
                    playListName: state.playListName,
                    userUKID: user,
                    playlistDescription: state.playlistDescription,
                    privacity: state.privacity,

                })
                    .then(function (response) {
                        response.data
                        dispatch('getPlaylistsAction')
                        setTimeout(function() {
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
                .post("https://tfgplaysoft.azurewebsites.net/Auth/register", {
                    email: state.registerEmail,
                    username: state.registerUsername,
                    password: state.registerPassword,
                })
                .then(function() {
                    Swal.fire({
                        position: 'top-end',
                        icon: 'success',
                        title: 'Register successfully',
                        showConfirmButton: false,
                        timer: 1500
                    })
                    setTimeout(() => {
                        location.reload();
                    }, 1500);


                })
                .catch(e => {
                    this.alertMessage = "Email already in use";
                    Swal.fire({
                        icon: 'error',
                        title: 'Email',
                        text: "Email already in use",
                    })
                    console.log(e);
                });
        },

        deleteRow({ state }, payload) {
            state.adminList;
            const model = payload.model;
            const id = payload.id;
            axios
                .delete(`https://tfgplaysoft.azurewebsites.net/${model}/${id}`)
                .catch(e => {
                    console.log(e);
                });
        },

        getAll({ commit }, payload) {
            const model = payload.model;
            const pageNumber = payload.pageNumber;
            axios
                .get(`https://tfgplaysoft.azurewebsites.net/${model}?pageNumber=${pageNumber}`)
                .then(function(response) {
                    commit('setAdminList', response.data);
                })
                .catch(e => {
                    console.log(e);
                });
        },

        getCount({ commit }, { model }) {
            axios
                .get(`https://tfgplaysoft.azurewebsites.net/${model}/count`)

                .then(function(response) {

                    commit('setCount', response.data);

                })
                .catch(e => {

                    console.log(e);
                });
        },

        Search({ commit, state }) {

            axios
                .get(`https://tfgplaysoft.azurewebsites.net/Search/${state.query}`)
                .then(function(response) {
                    commit("setTracks", response.data.spotifyResponse.result.tracks.items)
                    commit("setSearchPlaylists", response.data.playlist)
                })
                .catch(e => {

                    console.log(e);
                });
        },

        addToLibrary({ state }, playlist) {
            axios
                .post('https://tfgplaysoft.azurewebsites.net/Library/playlists', {
                    userID: state.usuario,
                    playlistID: playlist.playlistID

                }).then(function(response) {
                    console.log(response)
                })
                .catch(e => {

                    console.log(e);
                });
        },
        deleteLibrary({ state }, playlistID) {
            state.adminList;
            axios
                .delete(`https://tfgplaysoft.azurewebsites.net/Library/playlists/${playlistID}`)
                .catch(e => {

                    console.log(e);
                });
        },
        deleteSong({ state }, songID) {
            let plid = state.PlayListsID
            axios
                .delete(`https://tfgplaysoft.azurewebsites.net/Playlist/${plid}/songs`, {
                    data: {
                        playlistID: plid,
                        songID: songID
                    }
                }).then(function (response) {
                    console.log(response)
                })
                .catch(e => {
                    console.log(e);
                });
        },

        editPlaylist({ commit, state }) {
            axios.put(`https://tfgplaysoft.azurewebsites.net/Playlist/${state.PlayListsID}`, {
                playListName: state.playListName,
                playlistDescription: state.playlistDescription,
                privacity: state.privacity,
            }).then(() => {
                location.reload()
            })

                .catch(e => {
                    console.log(e)
                })
            commit('clearForm');
        },
        getSpotifyToken() {
            const clientId = 'ab06cb9da71b4009bd3623e37baf825d';
            const redirectUri = 'http://localhost:8080/songs';
            const scope = 'user-read-private user-read-email user-read-playback-state user-modify-playback-state  user-read-currently-playing app-remote-control streaming';

            const authorizeUrl = new URL('https://accounts.spotify.com/authorize');
            authorizeUrl.searchParams.append('response_type', 'token');
            authorizeUrl.searchParams.append('client_id', clientId);
            authorizeUrl.searchParams.append('scope', scope);
            authorizeUrl.searchParams.append('redirect_uri', redirectUri);
            window.location.href = authorizeUrl.toString()
        },
        getPlaybackStatus({ state, dispatch }) {
            fetch("https://api.spotify.com/v1/me/player", {
                method: "GET",
                headers: {
                    Authorization: `Bearer ${state.spotifyToken}`
                }
            }).then(response => {
                console.log("PLAYBACK STATUS", response.status)
                if (response.status == 204) {
                    dispatch('transferPlayback');
                }
            })
        },
        getCurrentTrack({ state }) {
            fetch("https://api.spotify.com/v1/me/player/currently-playing", {
                headers: {
                    Authorization: `Bearer ${state.spotifyToken}`
                }
            })
                .then(response => response.json())
                .then(data => {
                    // Obtener el ID de la canción actual
                    const currentTrack = data.item;
                    const currentTrackId = currentTrack.id;

                    // Comprobar si la canción actual ha cambiado
                    if (currentTrackId !== state.currentPlayingID) {
                        // Actualizar el ID de la canción actual
                        state.currentPlayingID = currentTrackId;
                        // Obtener la URL de la imagen del álbum de la canción actual
                        state.currentImage = currentTrack.album.images[0].url;
                        console.log(state.currentImage)
                        // Mostrar la nueva imagen en la página
                    }
                })
                .catch(error => {
                    console.error("Error al obtener la información de la canción actual:", error);
                });
        },

        transferPlayback({ state }) {
            const devices = []
            devices.push(state.device_id)
            const body = {
                device_ids: devices,
                play: false
            }
            fetch("https://api.spotify.com/v1/me/player", {
                method: "PUT",
                headers: {
                    Authorization: `Bearer ${state.spotifyToken}`,
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(body)
            }).then(response => {
                console.log(response)

                fetch("https://api.spotify.com/v1/me/player/pause", {
                    method: "PUT",
                    headers: {
                        Authorization: `Bearer ${state.spotifyToken}`,
                    },

                }).then(console.log("Paused"))
            })

        },

    },
    plugins: [createPersistedState()]
})