<template>
    <div>
        <v-carousel cycle hide-delimiters class="green dark">
            <v-carousel-item v-for="(item,i) in lstitems" :src="item.src" :key="i"></v-carousel-item>
        </v-carousel>
        <v-card height="120px" flat>
            <v-card-title primary-title>
                <div>
                    <h1><b>Proyecto</b></h1>
                    <h3>
                    </h3>
                </div>
            </v-card-title>
        </v-card>
    </div>
</template>

<script src="./inicio.ts"></script>