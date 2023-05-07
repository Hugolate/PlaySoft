<template>
  <v-app id="inspire">
    <v-main class="pa-0">
      <section id="fondo" class="fondo2">
        <span v-for="(obj, index) in 900" :key="index"></span>
      </section>
      <v-container class="fill-height" fluid>
        <v-row align="center" justify="center" v-motion-roll-left>
          <v-col cols="12" sm="8" md="8">
            <v-card class="elevation-12">
              <v-window v-model="$store.state.step">
                <v-window-item :value="1">
                  <v-row>
                    <v-col cols="12" md="8">
                      <v-card-text class="mt-12">
                        <h1 style="color: #6c176d">Sign in to PlaySoft</h1>
                        <template>
                          <v-alert v-show="loginError" style="margin-top: 20px; color: white" color="error" icon="$error"
                            id="alert">{{ alertMessage }}</v-alert></template>
                        <v-form @submit.prevent="onSubmit">

                          <v-text-field v-model="$store.state.loginEmail" label="Email" type="text" color="#6c176d" />

                          <v-text-field v-model="$store.state.loginPassword" id="password" label="Password"
                            type="password" color="#6c176d" />
                        </v-form>
                        <h3 class="text-center mt-4">Forgot your password ?</h3>
                      </v-card-text>
                      <div style="margin-bottom: 30px" class="text-center mt-3">
                        <v-btn rounded color="#6c176d" dark @click="login()">SIGN IN</v-btn>
                      </div>
                    </v-col>
                    <v-col cols="12" md="4" style="background-color: #6c176d">
                      <v-card-text class="white--text mt-12">
                        <h1 class="text-center display-1" style="color: white">
                          Hello, Friend!
                        </h1>
                        <h5 class="text-center">
                          Don't have an account? Create now!
                        </h5>
                      </v-card-text>
                      <div class="text-center">
                        <v-btn rounded outlined dark @click="$store.state.step++">SIGN UP</v-btn>
                      </div>
                    </v-col>
                  </v-row>
                </v-window-item>
                <v-window-item :value="2">
                  <v-row class="fill-height">
                    <v-col cols="12" md="4" style="background-color: #6c176d">
                      <v-card-text class="white--text mt-12">
                        <h5 class="text-center">
                          Do you have an account? Sign in now!
                        </h5>
                      </v-card-text>
                      <div class="text-center">
                        <v-btn rounded outlined dark @click="$store.state.step--">Sign in</v-btn>
                      </div>
                    </v-col>

                    <v-col cols="12" md="8">
                      <v-card-text class="mt-12">
                        <h1>Create Account</h1>
                        <template>
                          <v-alert v-show="registerError" style="margin-top: 20px; color: white" color="error"
                            icon="$error" id="alert">{{ alertMessage }}</v-alert></template>
                        <v-form>
                          <v-text-field v-model="$store.state.registerUsername" label="Name" type="text"
                            color="#6c176d" />
                          <v-text-field v-model="$store.state.registerEmail" label="Email" type="text" color="#6c176d" />

                          <v-text-field v-model="$store.state.registerPassword" id="password" label="Password"
                            type="password" color="#6c176d" />
                          <v-text-field v-model="$store.state.repeatPassword" id="password" label="Repeat Password"
                            type="password" color="#6c176d" />
                        </v-form>
                      </v-card-text>

                      <div style="margin-bottom: 30px" class="text-center mt-n5">
                        <v-btn @click="register()" color="#6c176d" dark>SIGN UP</v-btn>
                      </div>
                    </v-col>
                  </v-row>
                </v-window-item>
              </v-window>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </v-main>
  </v-app>
</template>

<script>
export default {
  data() {
    return {
      alertMessage: "",
      registerError: false,
      loginError: false,
    };
  },
  props: {
    source: String,
  },
  methods: {
    register() {
      if (this.$store.state.registerEmail == "" || this.$store.state.registerPassword == "" || this.$store.state.registerUsername == "" || this.$store.state.repeatPassword == "") {
        this.registerError = true;
        this.alertMessage = "All fields are required";
      } else if (this.$store.state.registerPassword != this.$store.state.repeatPassword) {
        this.alertMessage = "Passwords don't match";
        this.registerError = true;
      } else {
        if (this.$store.state.registerError) {
          this.registerError = false;
        }
        this.$store.dispatch('doRegister', this.$store.state.registerEmail, this.$store.state.registerUsername, this.$store.state.registerPassword)
      }
    },

    login() {
      if (this.$store.state.loginError) {
        this.loginError = false;
      }
      if (this.$store.state.loginEmail == "" || this.$store.state.loginPassword == "") {
        this.loginError = true;
        this.alertMessage = "All fields are required";
      } else {
        this.$store.dispatch('doLogin')
      }
    }

  },
};

</script>

<style>
v-content {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  background-color: black;
  padding: none !important;
}

.fondo2 {
  position: absolute;
  width: 100vw;
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 2px;
  flex-wrap: wrap;
  overflow: hidden;
  z-index: 0;
  background: gray;
}

section::before {
  content: '';
  position: absolute;
  width: 100%;
  height: 100%;
  background: linear-gradient(black, purple, black);
  animation: animate 5s linear infinite;
}

@keyframes animate {
  0% {
    transform: translateY(-100%);
  }

  100% {
    transform: translateY(100%);
  }
}

section span {
  position: relative;
  display: block;
  width: calc(6.25vw - 2px);
  height: calc(6.25vw - 2px);
  background-color: rgb(15, 15, 15);
  z-index: 2;
  transition: 1.5s;
}

section span:hover {
  background: rgb(128, 0, 128);
  transition: 0s;
}

@media(max-width: 900px) {
  section span {
    width: calc(10vw- 2px);
    height: calc(10vw - 2px);
  }
}

@media(max-width: 600px) {
  section span {
    width: calc(20vw- 2px);
    height: calc(20vw - 2px);
  }
}
</style>