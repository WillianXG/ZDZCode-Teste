// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  devtools: { enabled: false },
  alias: {
    css: '/<rootDir>/assets/css',
  },
  css: ['vuetify/styles/main.sass'],
  build: {
    transpile: ['vuetify'],
  }
})
