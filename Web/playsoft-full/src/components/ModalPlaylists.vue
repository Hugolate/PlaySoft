<template>
  <div class="modal-overlay" @click="$emit('close-modal')">
    <div class="modal" @click.stop>
      <img class="check" alt="" />
      <h6>Choose a playlist</h6>
      <h4 @click="add(track, playlist.playlistID)" id="animated" v-for="playlist in PlayListsList"
        :key="playlist.playlistID">
        {{ playlist.playListName }}</h4>
      <button>Go Home</button>
    </div>
    <div class="close" @click="$emit('close-modal')">
    </div>
  </div>
</template>
  
<script>
export default {
  name: 'ModalPlaylists',
  props: ["PlayListsList", "track", "index"],
  data() {
    return {
      plId: 0
    };
  },
  methods: {
    add(track, playlistID) {
      this.getTrack(playlistID);
      console.log(track.name)
      let vue = this;
      //vue.$store.state.playlistID = nombrepl
      alert(playlistID)
      vue.$store.state.songID = vue.track.id
      vue.$store.state.playlistID = playlistID
      this.$store.dispatch('postSong', vue.track)
      //this.$router.push({ path: '/songs' })

    },
    getTrack(plId) {
      this.plId = plId
    }
  }
}
</script>
  
<style scoped>
.modal-overlay {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  display: flex;
  justify-content: center;
  background-color: #00000022;
}

h4 {
  color: black;
  cursor: pointer;
  margin: 10px;
}

h4:hover {
  color: black;
  cursor: pointer;
  font-size: 1.2rem;

}

.modal {
  text-align: center;
  background-color: white;
  height: 500px;
  width: 500px;
  margin-top: 10%;
  padding: 60px 0;
  border-radius: 20px;
}

.close {
  margin: 10% 0 0 16px;
  cursor: pointer;
}

.close-img {
  width: 25px;
}

.check {
  width: 150px;
}

h6 {
  font-weight: 500;
  font-size: 28px;
  margin: 20px 0;
}

p {
  /* font-weight: 500; */
  font-size: 16px;
  margin: 20px 0;
}

button {
  background-color: rgb(128, 0, 128);
  width: 150px;
  height: 40px;
  color: white;
  font-size: 14px;
  border-radius: 16px;
  margin-top: 50px;
}

.modal-fade-enter,
.modal-fade-leave-to {
  opacity: 0;
}

.modal-fade-enter-active,
.modal-fade-leave-active {
  transition: opacity 0.5s ease;
}
</style>