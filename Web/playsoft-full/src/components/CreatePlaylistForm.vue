<template>
    <div id="app" v-cloak style="min-height: 0px;">
        <v-app style="max-height: 0px;">
            <div style="position: fixed; bottom: 6%; right: 0%; margin: 6%;" class="btnContainer">
                <v-btn v-if="this.$route.name == 'playlists'" class="btn" @click="compose({})">New Playlist</v-btn>
                <v-btn v-else class="btn-edit" @click="compose({})">Edit Playlist</v-btn>
            </div>

            <v-dialog v-model="$store.state.dialogCompose" width="500" :retain-focus="false">
                <v-card>
                    <v-card-title v-if="this.$route.name == 'playlists'" class="headline purple" primary-title>
                        New PLaylist
                    </v-card-title>
                    <v-card-title v-else class="headline purple" primary-title>
                        Edit PLaylist
                    </v-card-title>
                    <v-alert v-show="error" style="margin: 20px; color: white" color="error" icon="$error"
                        id="alert">Playlist must have a name</v-alert>
                    <v-card-text class="pa-5">
                        <v-form ref="sendForm" v-model="$store.state.valid" lazy-validation>
                            <v-text-field v-model="$store.state.playListName" label="Playlist name"
                                :rules="[rules.required]"></v-text-field>
                            <div v-html="$store.state.composeMessage.originalBody"></div>
                            <v-textarea v-model="$store.state.playlistDescription" label="Description"></v-textarea>
                            <div class="switch">
                                <div>
                                    <input v-model="$store.state.privacity" type="checkbox" class="switch-input"
                                        name="view">
                                    <label class="switch-label switch-label-off">Private</label>
                                </div>
                                <!-- <div> <input v-model="privacity" type="radio" class="switch-input" name="view" value=true>
                                    <label class="switch-label switch-label-on">Public</label>
                                </div> -->
                            </div>

                        </v-form>
                    </v-card-text>
                    <v-card-actions class="pa-5">
                        <v-btn class="ml-auto" @click="saveDraft()" outlined color="primary">Cancel</v-btn>
                        <v-btn v-if="this.$route.name == 'playlists'" @click="nuevaPl()" outlined color="primary">Save</v-btn>
                        <v-btn v-else @click="editPl()" outlined color="primary">Save</v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>
        </v-app>
    </div>
</template>
<script>
import Swal from 'sweetalert2'

export default {
    data() {
        return {
            error: false,
            rules: {
                required: value => !!value || "This field is required",
                email: v => /.+@.+\..+/.test(v) || "Must be a valid email"
            }

        }

    },
    methods: {
        compose() {
            this.$store.state.dialogCompose = true
        },
        saveDraft() {
            this.$store.state.dialogCompose = false
        },
        nuevaPl() {
            
            Swal.fire({
                
                icon: 'success',
                title: 'Playlist ' + this.$store.state.playListName + ' created!',
                showConfirmButton: false,
                timer: 1500
            })
            this.$store.dispatch('addPlaylist')
            
        },
        editPl(){
            Swal.fire('Playlist edited')
            this.$store.dispatch('editPlaylist')
        }
    }
}
</script>
<style>
.switch {
    display: flex;
    gap: 30px;
}

.btn {
    margin-top: 150px;
    margin-left: 50px;
}

.btn-edit{
    margin-left: 50px;
}

.layout {
    width: 60% !important;

}

.btn:hover {
    background-color: rgb(189, 15, 180) !important;
    height: 40px !important;
}
</style>