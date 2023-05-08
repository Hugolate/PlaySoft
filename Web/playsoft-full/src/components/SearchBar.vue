<template>
    <v-form class="form">
        <v-container>
            <v-layout>
                <v-flex xs12 sm6 md3>
                    <v-text-field id="a" label="Search" type="text" v-model="query" @keypress="Search()"
                        solo></v-text-field>
                </v-flex>
            </v-layout>
        </v-container>
    </v-form>
</template>

<script>
import router from '@/router';
export default {
    data() {
        return {
            query: this.$store.state.query,
        }
    },
    methods: {
        Search() {
            this.$store.commit('updateQuery', this.query)

            if (this.$route.name != 'search') {
                router.push({ path: 'search' })
            }
            this.$store.dispatch('Search');
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