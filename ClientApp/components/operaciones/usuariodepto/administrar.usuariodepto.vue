<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de UsuarioDepto</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDUsuarioDepto:</h4>
						<v-text-field v-model="usuariodepto.idusuariodepto" @input="usuariodepto.idusuariodepto = $event.toUpperCase()" required readonly hint="Ingrese IDUsuarioDepto"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDDepartamento:</h4>
						<v-text-field v-model="usuariodepto.iddepartamento" @input="usuariodepto.iddepartamento = $event.toUpperCase()" required clearable hint="Ingrese IDDepartamento"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDCargo:</h4>
						<v-text-field v-model="usuariodepto.idcargo" @input="usuariodepto.idcargo = $event.toUpperCase()" required clearable hint="Ingrese IDCargo"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDEmpresa:</h4>
						<v-text-field v-model="usuariodepto.idempresa" @input="usuariodepto.idempresa = $event.toUpperCase()" required clearable hint="Ingrese IDEmpresa"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDUsuario:</h4>
						<v-text-field v-model="usuariodepto.idusuario" @input="usuariodepto.idusuario = $event.toUpperCase()" required clearable hint="Ingrese IDUsuario"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">FechaRegistro:</h4>
						<v-text-field v-model="usuariodepto.fecharegistro" @input="usuariodepto.fecharegistro = $event.toUpperCase()" clearable hint="Ingrese FechaRegistro"></v-text-field>
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

<script src="./administrar.usuariodepto.ts"></script>
