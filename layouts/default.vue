<template>
    <v-layout class="rounded rounded-md">
        <v-navigation-drawer>
            <v-list>
                <v-list-item title="Navigation drawer">
                    <NuxtLink to="/"><v-btn color="black" prepend-icon="$vuetify" variant="">
                            Principal
                        </v-btn></NuxtLink><br />
                    <NuxtLink to="/categorias"><v-btn color="black" prepend-icon="$vuetify" variant="">
                            Categorias
                        </v-btn></NuxtLink><br />
                    <NuxtLink to="/produtos">
                        <v-btn color="black" prepend-icon="$vuetify" variant="">
                            Produtos
                        </v-btn>
                    </NuxtLink>
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