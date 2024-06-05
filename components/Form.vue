<template>
  <form>
    <v-text-field v-model="state.name" :counter="45" :error-messages="v$.name.$errors.map(e => e.$message)" label="Name"
      required @blur="v$.name.$touch" @input="v$.name.$touch"></v-text-field>

    <v-text-field v-model="state.descricao" label="Descrição"></v-text-field>

    <v-btn class="me-4" @click="handleSubmit">Salvar</v-btn>
    <v-btn @click="clear">Limpar</v-btn>

    
  </form>
</template>

<script setup>
import { reactive } from 'vue'
import { useVuelidate } from '@vuelidate/core'
import { required } from '@vuelidate/validators'

const initialState = {
  name: '',
  descricao: ''
}

const state = reactive({
  ...initialState
})

const rules = {
  name: { required },
}

const v$ = useVuelidate(rules, state)

function clear() {
  v$.value.$reset()

  for (const [key, value] of Object.entries(initialState)) {
    state[key] = value
  }
}

async function handleSubmit() {
  v$.value.$validate()

  if (!v$.value.$error) {
    const payload = {
      Nome: state.name,
      Descricao: state.descricao
    };

    try {
      const response = await fetch('http://localhost:5032/Categoria', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(payload)
      });

      const data = await response.json();

      if (!response.ok) {
        console.error('Validation errors:', data.errors);
      } else {
        console.log('Success:', data);
      }
    } catch (error) {
      console.log("Deu ruim");
      console.error('Request failed:', error);
    }
  }
}


console.log(state);

</script>

<style lang="">

</style>
