<template>
  <v-app>
    <v-container>
      <v-data-table
          :headers="headers"
          :items="desserts"
          :items-per-page="10"
          class="elevation-1"
          hide-default-footer
      ></v-data-table>
      <v-btn @click="updateData()" class="mt-4"
             color="accent"
             elevation="4"
             outlined
             rounded
             x-large
      >Обновить данные</v-btn>
    </v-container>
  </v-app>
</template>

<script>
import axios from "axios";

export default {
  name: 'App',
  data () {
    return {
      headers: [
        {
          text: 'Дата',
          align: 'start',
          sortable: false,
          value: 'date',
        },
        { text: 'Температура', value: 'temperature' },
        { text: 'Давление', value: 'pressure' },
        { text: 'Влажность', value: 'humidity' },
        { text: 'Ветер', value: 'wind' },
        { text: 'Осадки', value: 'precipitation' },
      ],
      desserts: [],
    }
  },
  mounted() {
    this.updateData();
  },
  methods: {
    updateData() {
      axios.get('http://localhost:50598/weather').then(res => this.desserts = res.data).catch(err => console.warn(err));
    }
  }
};
</script>
