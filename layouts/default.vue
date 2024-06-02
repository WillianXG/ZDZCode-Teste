<template>
    <v-layout class="rounded rounded-md">
      <v-navigation-drawer>
        <v-list>
          <v-list-item title="Navigation drawer">
            <NuxtLink to ="/">Home</NuxtLink><br/>
            <NuxtLink to ="/categorias">Categorias</NuxtLink><br/>
            <NuxtLink to ="/produtos">Produtos</NuxtLink>
          </v-list-item>
        </v-list>
      </v-navigation-drawer>
  
      <v-app-bar title="Application bar"></v-app-bar>
  
      <v-main class="d-flex align-center justify-center" style="min-height: 300px;">
        <NuxtPage />
      </v-main>
    </v-layout>
  </template>
<script>
export default {
    
}
</script>
<style lang="">
    
</style>