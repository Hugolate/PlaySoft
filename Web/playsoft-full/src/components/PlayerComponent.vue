<template>
    <div class="home">
        <iframe
            style="border-radius:50px; position: absolute; z-index: 1; left: 50%; top: 50%; transform: translate(-50%, -50%); width: 40%;"
            :src="'https://open.spotify.com/embed/track/' + id + '?utm_source=generator'" width="100%" height="352"
            frameBorder="0" allowfullscreen=""
            allow="autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture" loading="lazy"></iframe>

    </div>
</template>
  
<script>

export default {
    name: 'PlayerComponent',
    data() {
        return {
            id: '2f0Ft2XdvNSMSY5TUlZgEz'
        };
    },
}
</script>
  
<style></style>