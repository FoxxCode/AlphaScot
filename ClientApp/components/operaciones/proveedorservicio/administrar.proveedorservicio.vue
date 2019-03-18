<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de ProveedorServicio</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDServicio:</h4>
						<v-text-field v-model="proveedorservicio.idservicio" @input="proveedorservicio.idservicio = $event.toUpperCase()" required readonly hint="Ingrese IDServicio"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDProveedor:</h4>
						<v-text-field v-model="proveedorservicio.idproveedor" @input="proveedorservicio.idproveedor = $event.toUpperCase()" required readonly hint="Ingrese IDProveedor"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Descripcion:</h4>
						<v-text-field v-model="proveedorservicio.descripcion" @input="proveedorservicio.descripcion = $event.toUpperCase()" required clearable hint="Ingrese Descripcion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Etiqueta:</h4>
						<v-text-field v-model="proveedorservicio.etiqueta" @input="proveedorservicio.etiqueta = $event.toUpperCase()" clearable hint="Ingrese Etiqueta"></v-text-field>
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

<script src="./administrar.proveedorservicio.ts"></script>
