<template>
    <v-form class="form">
        <v-container>
            <v-layout>
                <v-flex xs12 sm6 md3>
                    <v-text-field label="Search" v-model="query" @keypress="Search()" solo></v-text-field>
                    <p href="">{{ query }}</p>
                </v-flex>
            </v-layout>
        </v-container>
    </v-form>
</template>

<script>
export default {
    data() {
        return {
            query: this.$store.state.query,
        }
    },
    methods: {
        Search() {
        
            if (!(this.query == '')) {
                console.log(this.query)
                this.$store.dispatch('Search')
            }
        }
    }

}
</script>
<style>
.form {
    position: absolute;
    top: 70px;
    z-index: 1;
    left: 10px;
    width: 70%;
}
</style>