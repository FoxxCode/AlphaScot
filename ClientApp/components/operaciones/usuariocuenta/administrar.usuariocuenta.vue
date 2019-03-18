<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de UsuarioCuenta</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDUsuarioCuenta:</h4>
						<v-text-field v-model="usuariocuenta.idusuariocuenta" @input="usuariocuenta.idusuariocuenta = $event.toUpperCase()" required readonly hint="Ingrese IDUsuarioCuenta"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDCuenta:</h4>
						<v-text-field v-model="usuariocuenta.idcuenta" @input="usuariocuenta.idcuenta = $event.toUpperCase()" required clearable hint="Ingrese IDCuenta"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDCentral:</h4>
						<v-text-field v-model="usuariocuenta.idcentral" @input="usuariocuenta.idcentral = $event.toUpperCase()" required clearable hint="Ingrese IDCentral"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDUsuario:</h4>
						<v-text-field v-model="usuariocuenta.idusuario" @input="usuariocuenta.idusuario = $event.toUpperCase()" required clearable hint="Ingrese IDUsuario"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDEmpresa:</h4>
						<v-text-field v-model="usuariocuenta.idempresa" @input="usuariocuenta.idempresa = $event.toUpperCase()" required clearable hint="Ingrese IDEmpresa"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">FechaRegistro:</h4>
						<v-text-field v-model="usuariocuenta.fecharegistro" @input="usuariocuenta.fecharegistro = $event.toUpperCase()" required clearable hint="Ingrese FechaRegistro"></v-text-field>
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

<script src="./administrar.usuariocuenta.ts"></script>
