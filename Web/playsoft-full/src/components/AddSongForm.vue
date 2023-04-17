<template>
    <div id="app" v-cloak style="min-height: 0px;">
        <v-app style="max-height: 0px;">

            <v-layout>
                <v-btn class="btn" @click="compose({})">Add Song</v-btn>
            </v-layout>

            <v-dialog v-model="dialogCompose" width="500">
                <v-card>
                    <v-card-title class="headline purple" primary-title>
                        Add Song
                    </v-card-title>
                    <v-alert v-show="error" style="margin: 20px; color: white" color="error" icon="$error" id="alert">{{
                        alertMessage }}</v-alert>
                    <v-card-text class="pa-5">

                        <v-form ref="sendForm" v-model="valid" lazy-validation>
                            <v-text-field v-model="songName" label="Song name" :rules="[rules.required]"></v-text-field>
                            <div v-html="composeMessage.originalBody"></div>
                            <div class="switch">
                            </div>
                        </v-form>
                        <div>
                            Añadir canciones
                        </div>
                    </v-card-text>
                    <v-card-actions class="pa-5">
                        <v-btn class="ml-auto" @click="saveDraft()" outlined color="primary">Cancel</v-btn>
                        <v-btn @click="addSong()" outlined color="primary">Save</v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>
        </v-app>
    </div>
</template>
<script>
export default {
    data() {
        return {
            songName: "",
            error: false,
            messages: [],
            drafts: [],
            alertMessage: "",
            sent: [],
            dialogCompose: false,
            activeMessage: {},
            composeMessage: {},
            valid: true,
            rules: {
                required: value => !!value || "This field is required",
                email: v => /.+@.+\..+/.test(v) || "Must be a valid email"
            }

        }

    },
    methods: {
        compose() {
            this.dialogCompose = true
        },
        saveDraft() {
            this.dialogCompose = false
            this.error = false
        },

        async addSong() {
            if (this.songName != "") {
                this.$store.dispatch('checkSong', this.songName)
                if (this.$store.state.addSong != null) {
                    console.log(this.$store.state.addSong.songID);
                    this.$store.dispatch('postSong')
                    this.error = false
                }
            } else {
                this.error = true
                this.alertMessage = "Name field is required"
            }
        }
    },
    mounted: function () {
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
</style>