<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de SericioAreaPais</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDAreaPais:</h4>
						<v-text-field v-model="sericioareapais.idareapais" @input="sericioareapais.idareapais = $event.toUpperCase()" required readonly hint="Ingrese IDAreaPais"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDServicio:</h4>
						<v-text-field v-model="sericioareapais.idservicio" @input="sericioareapais.idservicio = $event.toUpperCase()" required readonly hint="Ingrese IDServicio"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDArea:</h4>
						<v-text-field v-model="sericioareapais.idarea" @input="sericioareapais.idarea = $event.toUpperCase()" required clearable hint="Ingrese IDArea"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDPais:</h4>
						<v-text-field v-model="sericioareapais.idpais" @input="sericioareapais.idpais = $event.toUpperCase()" required clearable hint="Ingrese IDPais"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">FechaRegistro:</h4>
						<v-text-field v-model="sericioareapais.fecharegistro" @input="sericioareapais.fecharegistro = $event.toUpperCase()" clearable hint="Ingrese FechaRegistro"></v-text-field>
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

<script src="./administrar.sericioareapais.ts"></script>
