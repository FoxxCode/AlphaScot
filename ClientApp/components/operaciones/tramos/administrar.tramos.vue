<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de Tramos</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDTramo:</h4>
						<v-text-field v-model="tramos.idtramo" @input="tramos.idtramo = $event.toUpperCase()" required readonly hint="Ingrese IDTramo"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Etiqueta:</h4>
						<v-text-field v-model="tramos.etiqueta" @input="tramos.etiqueta = $event.toUpperCase()" required clearable hint="Ingrese Etiqueta"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">HoraInicio:</h4>
						<v-text-field v-model="tramos.horainicio" @input="tramos.horainicio = $event.toUpperCase()" required clearable hint="Ingrese HoraInicio"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">HoraFinal:</h4>
						<v-text-field v-model="tramos.horafinal" @input="tramos.horafinal = $event.toUpperCase()" required clearable hint="Ingrese HoraFinal"></v-text-field>
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

<script src="./administrar.tramos.ts"></script>
