<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de ProveedorServicio</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarproveedorservicio"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de proveedorservicio</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstproveedorservicio"
					  v-bind:headers="headers"
					  :search="buscarproveedorservicio"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstproveedorservicio">
				<td style="width: 10%;">{{ lstproveedorservicio.item.idservicio }}</td>
				<td style="width: 10%;">{{ lstproveedorservicio.item.idproveedor }}</td>
				<td style="width: 70%;">{{ lstproveedorservicio.item.descripcion }}</td>
				<td style="width: 70%;">{{ lstproveedorservicio.item.etiqueta }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstproveedorservicio.item.idservicio ,lstproveedorservicio.item.idproveedor)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de proveedorservicio</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstproveedorservicio.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de ProveedorServicio</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarproveedorservicio }}", no se encontraron registros.
			</v-alert>
			<template slot="pageText" scope="{ pageStart, pageStop }">
				Desde {{ pageStart }} a {{ pageStop }} de {{ totalItems }}
			</template>
			<template slot = "no-data">
				<v-alert :value="true" color="error" icon="warning">
					Lo sentimos, no exiten datos a desplegar: (
				</v-alert>
			</template>
		</v-data-table>
	</v-card>
</template>

<script src="./consultar.proveedorservicio.ts"></script>
