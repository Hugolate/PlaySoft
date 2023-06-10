<template>
    <v-container class="fill-height small-container" fluid style="justify-content: space-around;">
        <Bar id="my-chart-id" :data="chartData" style="z-index:3;" />
    </v-container>
</template>

<script>
import { Bar } from 'vue-chartjs'
import { Chart as ChartJS, Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale } from 'chart.js'

ChartJS.register(Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale)
export default {
    name: 'GraphicComponent',
    components: { Bar },
    data() {
        return {
            chartData: {
                labels: ['March', 'April', 'May', 'June'],
                datasets: [
                    {
                        label: 'Monthly login',
                        data: [1, 3, 6, 15],
                        backgroundColor: 'rgb(128, 0, 128)',
                        borderColor: 'rgb(255, 255, 255)',
                        borderWidth: 1.5
                    }],

            },
            chartOptions: {
                responsive: true
            }
        };
    }
}
</script>

<style>
.small-container {
    height: 400px;
}
</style>