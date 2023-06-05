<template>
    <div class="main-page">
        <div class="btn-cont">
            <button id="Artist" @click="getAll($event)">Artist</button>
            <button id="Song" @click="getAll($event)">Song</button>
            <button id="Album" @click="getAll($event)">Album</button>
        </div>
        <div>
            <div class="parent" v-if="adminList[0].songID">
                <div>SongID</div>
                <div>Song Name</div>
                <div>Song Uri</div>
                <div>Duration Ms</div>
            </div>
            <div class="parent" v-else-if="adminList[0].albumID">
                <div>AlbumId</div>
                <div>Album Name</div>
                <div>Release Date</div>
            </div>
            <div class="parent" v-else-if="adminList[0].artistID">
                <div>ArtistID</div>
                <div>Artist Name</div>
            </div>

            <div v-for="(item, index) in adminList" :key="index">
                <div v-on:click.right.prevent="deleteItem(item.songID)" class="parent hv" v-if="item.songID">
                    <div>{{ item.songID }}</div>
                    <div>{{ item.songName }}</div>
                    <div>{{ item.uri }}</div>
                    <div>{{ item.durationMs }}ms</div>
                </div>
                <div v-on:click.right.prevent="deleteItem(item.albumID)" class="parent hv" v-else-if="item.albumID">
                    <div>{{ item.albumID }}</div>
                    <div>{{ item.albumName }}</div>
                    <div>{{ item.releaseDate }}</div>
                </div>
                <div v-on:click.right.prevent="deleteItem(item.artistID)" class="parent hv" v-else-if="item.artistID">
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
    data() {
        return {
            model: "",
            page: 1
        }
    },
    computed: {
        adminList() {
            return this.$store.state.adminList;
        },
    },
    mounted() {
        this.model = "song"
        this.$store.dispatch('getAll', { model: 'song', pageNumber: 1 });
    },
    methods: {
        getAll(event) {
            this.$store.dispatch('getCount', { model: this.model });
            if (this.page > this.$store.state.totalPages) {
                this.page = this.$store.state.totalPages
            }
            if (event != null) {
                this.page = 1;
                this.model = event.target.id;
            }
            console.log(this.model)
            this.$store.dispatch('getAll', { model: this.model, pageNumber: this.page });
        },
        deleteItem(id) {
            this.$store.dispatch('deleteRow', { model: this.model, id: id });
            this.getAll(null)
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
  
<style>
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

.hv:hover {
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