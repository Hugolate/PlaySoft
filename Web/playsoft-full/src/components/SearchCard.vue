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

            <div class="dropdown">
                <button @click="animaciones()" class="dropbtn">Add to..</button>
                <div id="myDropdown" class="dropdown-content">
                    <a href="#home">Home</a>
                    <a href="#about">About</a>
                    <a href="#contact">Contact</a>
                </div>
            </div>
        </v-card>
    </div>
</template>
<script>
import { anim } from '../assets/scripts/DropDown'
export default {
    /* watch: {
         '$store.state.searchTracks': function () {
             console.log(this.$store.state.searchTracks)
         }
     }*/
    name: 'app',
    methods: {
        animaciones() {
            anim()
        }
    }
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

.dropbtn {
    background-color: #b734db;
    color: white;
    padding: 16px;
    font-size: 16px;
    border: none;
    cursor: pointer;
    border-radius: 20px;
}

.dropbtn:hover,
.dropbtn:focus {
    background-color: #3b0454;
}

.dropdown {
    position: relative;
    display: inline-block;
}

.dropdown-content {
    display: none;
    position: absolute;
    background-color: #f1f1f1;
    min-width: 160px;
    overflow: auto;
    box-shadow: 0px 8px 16px 0px rgba(0, 0, 0, 0.2);
    z-index: 1;
}

.dropdown-content a {
    color: black;
    padding: 12px 16px;
    text-decoration: none;
    display: block;
}

.dropdown a:hover {
    background-color: #ddd;
}

.show {
    display: block;
}
</style>