<template>
    <div class="text-center">
        <br>
        <h1>Produtos</h1>
        <br>
        <table>
            <thead>
                <tr>
                    <th class="text-left">Nome</th>
                    <th class="text-left">Descrição</th>
                    <th class="text-left">Ações</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in desserts" :key="item.id">
                    <td>{{ item.nome }}</td>
                    <td>{{ item.descricao }}</td>
                    <td>
                        <button @click="editItem(item)">Editar</button>
                        <button @click="deleteItem(item.id)">Excluir</button>
                    </td>
                </tr>
            </tbody>
        </table>

        <!-- Modal para editar item -->
        <div v-if="isEditModalOpen" class="modal">
            <div class="modal-content">
                <span class="close" @click="isEditModalOpen = false">&times;</span>
                <h2>Editar Produto</h2>
                <form @submit.prevent="updateItem">
                    <div>
                        <label for="nome">Nome:</label>
                        <input type="text" v-model="selectedItem.nome" required>
                    </div>
                    <div>
                        <label for="descricao">Descrição:</label>
                        <input type="text" v-model="selectedItem.descricao" required>
                    </div>
                    <button type="submit">Salvar</button>
                </form>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            desserts: [],
            isEditModalOpen: false,
            selectedItem: {}
        };
    },
    mounted() {
        this.fetchDesserts();
    },
    methods: {
        async fetchDesserts() {
            try {
                const response = await fetch('http://localhost:5032/Categoria');
                if (response.ok) {
                    const data = await response.json();
                    this.desserts = data;
                } else {
                    console.error('Erro na requisição:', response.statusText);
                }
            } catch (error) {
                console.error('Erro ao buscar dados:', error);
            }
        },
        editItem(item) {
            this.selectedItem = { ...item };
            this.isEditModalOpen = true;
        },
        async updateItem() {
    try {
        const response = await fetch(`http://localhost:5032/Categoria/${this.selectedItem.id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(this.selectedItem)
        });
        if (response.ok) {
            const index = this.desserts.findIndex(item => item.id === this.selectedItem.id);
            if (index !== -1) {
                this.desserts[index] = { ...this.selectedItem };
                this.isEditModalOpen = false;
            }
        } else {
            console.error('Erro na atualização:', response.statusText);
        }
    } catch (error) {
        console.error('Erro ao atualizar item:', error);
    }
},
        async deleteItem(id) {
            try {
                const response = await fetch(`http://localhost:5032/Categoria/${id}`, {
                    method: 'DELETE'
                });
                if (response.ok) {
                    this.desserts = this.desserts.filter(item => item.id !== id);
                } else {
                    console.error('Erro na exclusão:', response.statusText);
                }
            } catch (error) {
                console.error('Erro ao excluir item:', error);
            }
        }
    }
};
</script>

<style scoped>
table {
    width: 100%;
    border-collapse: collapse;
}

th, td {
    border: 1px solid #ddd;
    padding: 8px;
}

th {
    background-color: #f2f2f2;
    text-align: left;
}

button {
    margin-right: 5px;
}

.modal {
    display: block;
    position: fixed;
    z-index: 1;
    left: 0;
    top: 0;
    width: 100%;
    height: 100%;
    overflow: auto;
    background-color: rgb(0,0,0);
    background-color: rgba(0,0,0,0.4);
    padding-top: 60px;
}

.modal-content {
    background-color: #fefefe;
    margin: 5% auto;
    padding: 20px;
    border: 1px solid #888;
    width: 80%;
}

.close {
    color: #aaa;
    float: right;
    font-size: 28px;
    font-weight: bold;
}

.close:hover,
.close:focus {
    color: black;
    text-decoration: none;
    cursor: pointer;
}
</style>
