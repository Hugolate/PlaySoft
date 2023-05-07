<template>
    <div class="home">
        <CabeceraPlaysoft></CabeceraPlaysoft>
        <SettingsMenu></SettingsMenu>
    </div>
</template>

<script>
import CabeceraPlaysoft from '@/components/CabeceraPlaysoft.vue';
import SettingsMenu from '@/components/SettingsMenu.vue'

export default {

    name: 'app',
    components: {
        CabeceraPlaysoft, SettingsMenu
    }
}

</script>

<style></style>