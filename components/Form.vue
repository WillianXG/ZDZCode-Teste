<template>
    <form>
      <v-text-field
        v-model="state.name"
        :counter="45"
        :error-messages="v$.name.$errors.map(e => e.$message)"
        label="Name"
        required
        @blur="v$.name.$touch"
        @input="v$.name.$touch"
      ></v-text-field>
  
      <v-text-field
        label="Descrição"
      ></v-text-field>

      <v-btn
        class="me-4"
        @click="handleSubmit"
      >
        Salvar
      </v-btn>
      <v-btn @click="clear">
        clear
      </v-btn>
    </form>
  </template>
<script setup>
import { reactive } from 'vue'
import { useVuelidate } from '@vuelidate/core'
import { email, required } from '@vuelidate/validators'

const initialState = {
  name: '',
  email: '',
}

const state = reactive({
  ...initialState,
})


const rules = {
  name: { required },
  email: {  email },
}

const v$ = useVuelidate(rules, state)

function clear () {
  v$.value.$reset()

  for (const [key, value] of Object.entries(initialState)) {
    state[key] = value
  }
}

function handleSubmit() {
  v$.value.$validate()

  if (!v$.value.$error) {
    console.log('Tudo certo!')
  }
  else{
  console.log("Algo deu errado")
  }
}
</script>
<style lang="">
    
</style>
