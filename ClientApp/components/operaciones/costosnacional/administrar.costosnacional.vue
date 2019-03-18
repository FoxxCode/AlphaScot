<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de CostosNacional</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDDia:</h4>
						<v-text-field v-model="costosnacional.iddia" @input="costosnacional.iddia = $event.toUpperCase()" required readonly hint="Ingrese IDDia"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDTramo:</h4>
						<v-text-field v-model="costosnacional.idtramo" @input="costosnacional.idtramo = $event.toUpperCase()" required readonly hint="Ingrese IDTramo"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDTarifa:</h4>
						<v-text-field v-model="costosnacional.idtarifa" @input="costosnacional.idtarifa = $event.toUpperCase()" required readonly hint="Ingrese IDTarifa"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDServicio:</h4>
						<v-text-field v-model="costosnacional.idservicio" @input="costosnacional.idservicio = $event.toUpperCase()" required readonly hint="Ingrese IDServicio"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDRango:</h4>
						<v-text-field v-model="costosnacional.idrango" @input="costosnacional.idrango = $event.toUpperCase()" required readonly hint="Ingrese IDRango"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Costo:</h4>
						<v-text-field v-model="costosnacional.costo" @input="costosnacional.costo = $event.toUpperCase()" required clearable hint="Ingrese Costo"></v-text-field>
					</v-flex>
				</v-layout>
			</v-card-text>
		</v-form>
		<v-card-actions>
			<v-btn color="green" style="width: 50%" @click="Grabar">Grabar</v-btn>
			<v-btn color="red" style="width: 50%" @click="Cancelar">Cancelar</v-btn>
		</v-card-actions>
		<v-footer class="pa-3">
			{{ error }}
			<v-spacer></v-spacer>
			<div>&copy; {{ new Date().getFullYear() }}</div>
		</v-footer>
	</v-card>
</template>

<script src="./administrar.costosnacional.ts"></script>
