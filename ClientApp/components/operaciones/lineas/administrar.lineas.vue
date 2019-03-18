<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de Lineas</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDLinea:</h4>
						<v-text-field v-model="lineas.idlinea" @input="lineas.idlinea = $event.toUpperCase()" required readonly hint="Ingrese IDLinea"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDCentral:</h4>
						<v-text-field v-model="lineas.idcentral" @input="lineas.idcentral = $event.toUpperCase()" required readonly hint="Ingrese IDCentral"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDProveedor:</h4>
						<v-text-field v-model="lineas.idproveedor" @input="lineas.idproveedor = $event.toUpperCase()" required clearable hint="Ingrese IDProveedor"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Etiqueta:</h4>
						<v-text-field v-model="lineas.etiqueta" @input="lineas.etiqueta = $event.toUpperCase()" clearable hint="Ingrese Etiqueta"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Descripcion:</h4>
						<v-text-field v-model="lineas.descripcion" @input="lineas.descripcion = $event.toUpperCase()" required clearable hint="Ingrese Descripcion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Numero:</h4>
						<v-text-field v-model="lineas.numero" @input="lineas.numero = $event.toUpperCase()" required clearable hint="Ingrese Numero"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">ReportaEntrada:</h4>
						<v-text-field v-model="lineas.reportaentrada" @input="lineas.reportaentrada = $event.toUpperCase()" required clearable hint="Ingrese ReportaEntrada"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">ReportaSalida:</h4>
						<v-text-field v-model="lineas.reportasalida" @input="lineas.reportasalida = $event.toUpperCase()" required clearable hint="Ingrese ReportaSalida"></v-text-field>
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

<script src="./administrar.lineas.ts"></script>
