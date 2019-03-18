<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de CodigosCentral</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDCodigo:</h4>
						<v-text-field v-model="codigoscentral.idcodigo" @input="codigoscentral.idcodigo = $event.toUpperCase()" required readonly hint="Ingrese IDCodigo"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Fecha:</h4>
						<v-text-field v-model="codigoscentral.fecha" @input="codigoscentral.fecha = $event.toUpperCase()" required readonly hint="Ingrese Fecha"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDCuenta:</h4>
						<v-text-field v-model="codigoscentral.idcuenta" @input="codigoscentral.idcuenta = $event.toUpperCase()" required readonly hint="Ingrese IDCuenta"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDCentral:</h4>
						<v-text-field v-model="codigoscentral.idcentral" @input="codigoscentral.idcentral = $event.toUpperCase()" required readonly hint="Ingrese IDCentral"></v-text-field>
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

<script src="./administrar.codigoscentral.ts"></script>
