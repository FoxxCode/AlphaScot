<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de Central</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDCentral:</h4>
						<v-text-field v-model="central.idcentral" @input="central.idcentral = $event.toUpperCase()" required readonly hint="Ingrese IDCentral"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDCiudad:</h4>
						<v-text-field v-model="central.idciudad" @input="central.idciudad = $event.toUpperCase()" required clearable hint="Ingrese IDCiudad"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDPais:</h4>
						<v-text-field v-model="central.idpais" @input="central.idpais = $event.toUpperCase()" required clearable hint="Ingrese IDPais"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDEmpresa:</h4>
						<v-text-field v-model="central.idempresa" @input="central.idempresa = $event.toUpperCase()" required clearable hint="Ingrese IDEmpresa"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Descripcion:</h4>
						<v-text-field v-model="central.descripcion" @input="central.descripcion = $event.toUpperCase()" required clearable hint="Ingrese Descripcion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Codigo:</h4>
						<v-text-field v-model="central.codigo" @input="central.codigo = $event.toUpperCase()" required clearable hint="Ingrese Codigo"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">ProcesaEntrada:</h4>
						<v-text-field v-model="central.procesaentrada" @input="central.procesaentrada = $event.toUpperCase()" required clearable hint="Ingrese ProcesaEntrada"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">ProcesaSalida:</h4>
						<v-text-field v-model="central.procesasalida" @input="central.procesasalida = $event.toUpperCase()" required clearable hint="Ingrese ProcesaSalida"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">ProcesaCuentas:</h4>
						<v-text-field v-model="central.procesacuentas" @input="central.procesacuentas = $event.toUpperCase()" required clearable hint="Ingrese ProcesaCuentas"></v-text-field>
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

<script src="./administrar.central.ts"></script>
