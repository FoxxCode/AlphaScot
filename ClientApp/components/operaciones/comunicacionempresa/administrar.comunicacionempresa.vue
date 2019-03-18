<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de ComunicacionEmpresa</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDComunicacion:</h4>
						<v-text-field v-model="comunicacionempresa.idcomunicacion" @input="comunicacionempresa.idcomunicacion = $event.toUpperCase()" required readonly hint="Ingrese IDComunicacion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDEmpresa:</h4>
						<v-text-field v-model="comunicacionempresa.idempresa" @input="comunicacionempresa.idempresa = $event.toUpperCase()" required readonly hint="Ingrese IDEmpresa"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDTipoComunicacion:</h4>
						<v-text-field v-model="comunicacionempresa.idtipocomunicacion" @input="comunicacionempresa.idtipocomunicacion = $event.toUpperCase()" required clearable hint="Ingrese IDTipoComunicacion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Valor:</h4>
						<v-text-field v-model="comunicacionempresa.valor" @input="comunicacionempresa.valor = $event.toUpperCase()" clearable hint="Ingrese Valor"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">PorDefecto:</h4>
						<v-text-field v-model="comunicacionempresa.pordefecto" @input="comunicacionempresa.pordefecto = $event.toUpperCase()" clearable hint="Ingrese PorDefecto"></v-text-field>
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

<script src="./administrar.comunicacionempresa.ts"></script>
