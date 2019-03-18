<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de SMDROrigen</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDLlamada:</h4>
						<v-text-field v-model="smdrorigen.idllamada" @input="smdrorigen.idllamada = $event.toUpperCase()" required readonly hint="Ingrese IDLlamada"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDEstado:</h4>
						<v-text-field v-model="smdrorigen.idestado" @input="smdrorigen.idestado = $event.toUpperCase()" required clearable hint="Ingrese IDEstado"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Trama:</h4>
						<v-text-field v-model="smdrorigen.trama" @input="smdrorigen.trama = $event.toUpperCase()" clearable hint="Ingrese Trama"></v-text-field>
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

<script src="./administrar.smdrorigen.ts"></script>
