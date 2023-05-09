<template>
        <div class="cont">

            <v-card class="mx-auto" max-width="344" style="background-color: rgb(34, 31, 34);"
                v-for="(track) in this.$store.state.searchTracks" :key="track.id" outlined>
                <v-list-item three-line>
                    <v-list-item-content style=" margin-right: 20px; align-self:normal">
                        <v-list-item-title class="text-h5 mb-1 txt" style="text-align: start;">
                            {{ track.name }}
                        </v-list-item-title>
                        <v-list-item-subtitle style="text-align: start; color: rgb(173, 173, 173);">{{ track.album.name
                        }}</v-list-item-subtitle>
                    </v-list-item-content>
                    <div>

                        <img :src="track.album.images[0].url" style="width: 80px; margin-top: 10px;" alt="">
                        <div class="txt">{{ track.artists[0].name }}</div>
                    </div>
                </v-list-item>

                <v-card-actions
                    style="border: 1px solid purple; border-radius: 60px; width: 40px; background-color: purple; margin: 0px 0px 10px 10px; cursor: pointer">
                    <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="white">
                        <title>plus</title>
                        <path d="M19,13H13V19H11V13H5V11H11V5H13V11H19V13Z" />
                    </svg>
                </v-card-actions>
            </v-card>
        </div>

</template>
<script>

export default {
    /* watch: {
         '$store.state.searchTracks': function () {
             console.log(this.$store.state.searchTracks)
         }
     }*/
}

</script>

<style>
.cont {
    display: flex;
    flex-direction: column;
    margin-top: 200px;
    margin-left: 40px;
    gap: 15px;

}

.fondo2 {
    position: absolute;
    width: 100vw;
    height: 100vh;
    display: flex;
    justify-content: center;
    align-items: center;
    gap: 2px;
    flex-wrap: wrap;
    overflow: hidden;
    z-index: 0;
    background: gray;
}

.txt {
    color: rgb(219, 219, 219);
}
</style>