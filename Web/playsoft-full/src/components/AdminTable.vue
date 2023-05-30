<template>
    <div class="main-page">
        <div class="btn-cont">
            <button id="Artist" @click="getAll($event)">Artist</button>
            <button id="Song" @click="getAll($event)">Song</button>
            <button id="Album" @click="getAll($event)">Album</button>
        </div>
        <div>
            <div class="parent" v-if="$store.state.adminList[0].songID">
                <div>SongID</div>
                <div>Song Name</div>
                <div>Song Uri</div>
                <div>Duration Ms</div>
            </div>
            <div class="parent" v-else-if="$store.state.adminList[0].albumID">
                <div>AlbumId</div>
                <div>Album Name</div>
                <div>Release Date</div>
            </div>
            <div class="parent" v-else-if="$store.state.adminList[0].artistID">
                <div>ArtistID</div>
                <div>Artist Name</div>
            </div>

            <div v-for="(item, index) in this.$store.state.adminList" :key="index">
                <div class="parent" v-if="item.songID">
                    <div>{{ item.songID }}</div>
                    <div>{{ item.songName }}</div>
                    <div>{{ item.uri }}</div>
                    <div>{{ item.durationMs }}ms</div>
                </div>
                <div class="parent" v-else-if="item.albumID">
                    <div>{{ item.albumID }}</div>
                    <div>{{ item.albumName }}</div>
                    <div>{{ item.releaseDate }}</div>
                </div>
                <div class="parent" v-else-if="item.artistID">
                    <div>{{ item.artistID }}</div>
                    <div>{{ item.artistName }}</div>

                </div>
            </div>

        </div>
        <div id="pages-div" class="pages">
            <div @click="previousPage()">Back</div>
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
    mounted() {
        this.$store.dispatch('getAll', { model: 'song', pageNumber: 1 });
    },
    methods: {
        getAll(event) {
            document.getElementById("pages-div").style.display = "block";
            if (event != null) {
                this.model = event.target.id;
                this.$store.dispatch('getCount', { model: this.model });
            }
            this.$store.dispatch('getAll', { model: this.model, pageNumber: this.page });
        },
        previousPage() {
            console.log("previous")
            if (this.page > 1) {
                this.page++;
                this.getAll(null)
            }
        },
        nextPage() {
            console.log("next")
            if (this.pageNumber < this.totalPages) {
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

.container div {
    border: black solid 1px;

}

.main-page {
    margin-top: 170px;
}

.parent {
    margin: 0px 200px 0px 200px;
    display: grid;
    grid-template-columns: repeat(4, 0.5fr);
    grid-template-rows: (20, 150px);

}

.parent div {
    border: black 1px solid;


}

.pages {
    margin-top: 40px;
    display: none;
}

.btn-cont {
    display: flex;
    gap: 20px;
    margin-left: 20px;
    margin-bottom: 50px;
}
</style>