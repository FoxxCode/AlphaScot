<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de SMDR</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDLlamada:</h4>
						<v-text-field v-model="smdr.idllamada" @input="smdr.idllamada = $event.toUpperCase()" required readonly hint="Ingrese IDLlamada"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDEstado:</h4>
						<v-text-field v-model="smdr.idestado" @input="smdr.idestado = $event.toUpperCase()" required clearable hint="Ingrese IDEstado"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Codigo:</h4>
						<v-text-field v-model="smdr.codigo" @input="smdr.codigo = $event.toUpperCase()" required clearable hint="Ingrese Codigo"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Fecha:</h4>
						<v-text-field v-model="smdr.fecha" @input="smdr.fecha = $event.toUpperCase()" clearable hint="Ingrese Fecha"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Hora:</h4>
						<v-text-field v-model="smdr.hora" @input="smdr.hora = $event.toUpperCase()" clearable hint="Ingrese Hora"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Duracion:</h4>
						<v-text-field v-model="smdr.duracion" @input="smdr.duracion = $event.toUpperCase()" clearable hint="Ingrese Duracion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Linea:</h4>
						<v-text-field v-model="smdr.linea" @input="smdr.linea = $event.toUpperCase()" clearable hint="Ingrese Linea"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Interno:</h4>
						<v-text-field v-model="smdr.interno" @input="smdr.interno = $event.toUpperCase()" clearable hint="Ingrese Interno"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Cuenta:</h4>
						<v-text-field v-model="smdr.cuenta" @input="smdr.cuenta = $event.toUpperCase()" clearable hint="Ingrese Cuenta"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Numero:</h4>
						<v-text-field v-model="smdr.numero" @input="smdr.numero = $event.toUpperCase()" clearable hint="Ingrese Numero"></v-text-field>
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

<script src="./administrar.smdr.ts"></script>
