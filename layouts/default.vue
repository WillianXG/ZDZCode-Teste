<template>
    <v-layout class="rounded rounded-md">
      <v-navigation-drawer>
        <v-list>
          <v-list-item>
            <h1>Menu</h1>
            <v-divider></v-divider>
            <NuxtLink to="/"><v-btn color="black" prepend-icon="$vuetify" variant="plain" @click="closeRail">
              Principal
            </v-btn></NuxtLink><br />
            <NuxtLink to="/categorias"><v-btn color="black" prepend-icon="$vuetify" variant="plain" @click="closeRail">
              Categorias
            </v-btn></NuxtLink><br />
            <NuxtLink to="/produtos">
              <v-btn color="black" prepend-icon="$vuetify" variant="plain" @click="closeRail">
                Produtos
              </v-btn>
            </NuxtLink>
          </v-list-item>
        </v-list>
      </v-navigation-drawer>
  
      <v-app-bar title="Teste ZDZCode"></v-app-bar>
  
      <v-main class="d-flex align-center justify-center" style="min-height: 300px;">
        <NuxtPage />
      </v-main>
    </v-layout>
  </template>
  
  <script>
  export default {
    data() {
      return {
        drawer: true,
        rail: false
      };
    },
    methods: {
      closeRail() {
        this.rail = false;
      }
    }
  };
  </script>
  
  <style lang="">
  
  </style>
  