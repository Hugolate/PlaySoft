<template>
    <div>
        <CabeceraPlaysoft></CabeceraPlaysoft>
        <LoginCard></LoginCard>
    </div>
</template>

<script>
import CabeceraPlaysoft from '@/components/CabeceraPlaysoft.vue'
import LoginCard from '@/components/LoginCard.vue';

export default {
    name: 'LoginPage',
    components: {
        LoginCard, CabeceraPlaysoft
    }
}

</script>