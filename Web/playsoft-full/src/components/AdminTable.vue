<template>
    <div class="main-page">
        <div class="btn-cont">
            <button id="Artist" @click="getAll($event)">Artist</button>
            <button id="Song" @click="getAll($event)">Song</button>
            <button id="Album" @click="getAll($event)">Album</button>
        </div>
        <div>
            <div class="parent" v-if="list[0].songID">
                <div>SongID</div>
                <div>Song Name</div>
                <div>Song Uri</div>
                <div>Duration Ms</div>
            </div>
            <div class="parent" v-else-if="list[0].albumID">
                <div>AlbumId</div>
                <div>Album Name</div>
                <div>Release Date</div>
            </div>
            <div class="parent" v-else-if="list[0].artistID">
                <div>ArtistID</div>
                <div>Artist Name</div>
            </div>

            <div v-for="(item, index) in list" :key="index">
                <div v-on:click.right.prevent="deleteItem(item.songID, index)" class="parent hv" v-if="item.songID"
                    :id="index">
                    <div>{{ item.songID }}</div>
                    <div>{{ item.songName }}</div>
                    <div>{{ getUri(item.uri) }}..</div>
                    <div>{{ item.durationMs }}ms</div>
                </div>
                <div :id="index" v-on:click.right.prevent="deleteItem(item.albumID, index)" class="parent hv"
                    v-else-if="item.albumID">
                    <div>{{ item.albumID }}</div>
                    <div>{{ item.albumName }}</div>
                    <div>{{ item.releaseDate }}</div>
                </div>
                <div :id="index" v-on:click.right.prevent="deleteItem(item.artistID, index)" class="parent hv"
                    v-else-if="item.artistID">
                    <div>{{ item.artistID }}</div>
                    <div>{{ item.artistName }}</div>

                </div>
            </div>

        </div>
        <div id="pages-div" class="pages">
            <div @click="previousPage()">Back</div>
            <input type="number" v-model="page" :max="this.$store.state.totalPages" @input="getAll(null)">
            <div @click="nextPage()">Next</div>
        </div>
    </div>
</template>
  
<script>

export default {
    name: "adminPage",
    data: function () {
        return {
            model: "",
            page: 1,
            index1: 0,
            adminList: [],

        }
    },
    computed: {
        list() {
            return this.$store.state.adminList;
        },
    },
    mounted() {
        this.model = "song"
        this.$store.dispatch('getAll', { model: 'song', pageNumber: 1 });
    },
    methods: {
        getUri(uri){
            return uri.substring(15,24)
        },
        getAll(event) {

            if (event != null) {
                this.page = 1;
                this.model = event.target.id;
            }
            this.$store.dispatch('getCount', { model: this.model });
            console.log("pages:", this.$store.state.totalPages)
            if (this.page > this.$store.state.totalPages) {
                this.page = this.$store.state.totalPages
            }
            if (this.page < 1) {
                this.page = 1
            }

            this.$store.dispatch('getAll', { model: this.model, pageNumber: this.page });
        },
        deleteItem(id, index) {

            this.adminList = this.list;
            this.adminList.splice(index, 1);
            this.$store.dispatch('deleteRow', { model: this.model, id: id });

        },
        
        previousPage() {
            console.log("previous")
            if (this.page > 1) {
                this.page--;
                this.getAll(null)
            }
        },

        nextPage() {
            console.log("next")
            if (this.page < this.$store.state.totalPages) {
                console.log(this.$store.state.totalPages);
                this.page++;
                this.getAll(null)
            }
        },
    },
}
</script>
  
<style scoped>

body{
    background: #ccc5c5;
}
button {
    border: black solid 1px;
    background-color: rgb(194, 194, 194);
    padding: 2px 5px 1px 5px;
}



.main-page {
    margin-top: 170px;
}

.parent {
    margin: 0px 200px 0px 200px;
    display: grid;
    grid-template-columns: repeat(4, 0.5fr);
    grid-template-rows: (20, 150px);
    transition: background-color 1.2s ease-in-out;
}

.parent div {
    border: black 1px solid;

}

.pages {
    margin-top: 40px;
    display: flex;
    align-items: center;
    justify-content: center;
    gap: 12px;
}

.hv div:hover {
    background-color: rgb(253, 65, 65);
}

.btn-cont {
    display: flex;
    gap: 20px;
    margin-left: 20px;
    margin-bottom: 50px;
}

input[type=number]::-webkit-inner-spin-button,
input[type=number]::-webkit-outer-spin-button {
    -webkit-appearance: none;
    margin: 0;
}

input[type=number] {
    -moz-appearance: textfield;
    text-align: center;
    width: 40px;
    border: black 1px solid;
}
</style>