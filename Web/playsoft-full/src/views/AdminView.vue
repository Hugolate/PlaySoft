<template>
    <div class="home" v-if="this.$store.state.usuario == 1">
        <CabeceraPlaysoft></CabeceraPlaysoft>
        <AdminTable></AdminTable>
    </div>
    <div v-else>
        <h1>FORBIDDEN</h1>
    </div>
</template>
  
<script>
import CabeceraPlaysoft from '@/components/CabeceraPlaysoft.vue';
import AdminTable from '@/components/AdminTable.vue';

export default {
    name: 'HomeView',
    components: {
        CabeceraPlaysoft,
        AdminTable,
    },
    data() {
        return {
            languages: [
                { title: "español", value: "es" },
                { title: "inglés", value: "en" },
            ],
        };
    },
}
</script>

<style></style>
  