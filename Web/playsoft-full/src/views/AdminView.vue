<template>
    <div class="home">
        <CabeceraPlaysoft></CabeceraPlaysoft>
        <AdminTable></AdminTable>
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
  