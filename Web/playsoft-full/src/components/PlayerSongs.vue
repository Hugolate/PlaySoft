<template>
    <div>
        <button @click="playTrack">Play Track</button>
    </div>
</template>
  
<script>
import axios from 'axios';

export default {
    methods: {
        async playTrack() {
            try {
                const response = await axios.get('https://api.spotify.com/v1/tracks/0eGsygTp906u18L0Oimnem', {
                    headers: {
                        Authorization: 'Bearer access_token',
                    },
                });
                const trackURI = response.data.uri;
                const player = new Spotify.Player({
                    name: 'My Spotify Player',
                    getOAuthToken: (cb) => {

                        cb('access_token');
                    }
                });
                player.addListener('ready', ({ device_id }) => {
                    player.play({
                        uris: [trackURI],
                        device_id: device_id,
                    });
                });
                player.connect();
            } catch (error) {
                console.error(error);
            }
        },
    },
};
</script>