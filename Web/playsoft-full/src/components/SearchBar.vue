<template>
    <v-form class="form">
        <v-container>
            <v-layout class="layout" style="position: fixed; z-index: 2; top: 11%;">
                <v-flex xs12 sm6 md3>
                    <v-text-field label="Search..." class="search" type="text" v-model="query" @input="Search()" autofocus 
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
            query: "",
            
        }
    },
    
    methods: {
        Search() {
            this.$store.commit('updateQuery', this.query)
            if (this.$route.name != 'search') {
                router.push({ path: 'search' }).catch(() => { });
            }
            this.$store.dispatch('Search');
            console.log(this.query)
        }
    },
}
</script>
<style>

.layout{
    display: flex;
    flex-direction: column;
    width: 100%;
    margin-left: 40px;
    gap: 15px;
    align-items: flex-start;
}
.form {
    height: 20vh;
    display: flex;
    align-items: flex-end;
    top: 70px;
    z-index: 1;
    left: 10px;
    width: 100%;
}
</style>