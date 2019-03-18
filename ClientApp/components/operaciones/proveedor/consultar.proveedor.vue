<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de Proveedor</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarproveedor"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de proveedor</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstproveedor"
					  v-bind:headers="headers"
					  :search="buscarproveedor"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstproveedor">
				<td style="width: 10%;">{{ lstproveedor.item.idproveedor }}</td>
				<td style="width: 70%;">{{ lstproveedor.item.idtipo }}</td>
				<td style="width: 70%;">{{ lstproveedor.item.etiqueta }}</td>
				<td style="width: 70%;">{{ lstproveedor.item.idciudad }}</td>
				<td style="width: 70%;">{{ lstproveedor.item.idpais }}</td>
				<td style="width: 70%;">{{ lstproveedor.item.descripcion }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstproveedor.item.idproveedor)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de proveedor</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstproveedor.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de Proveedor</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarproveedor }}", no se encontraron registros.
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

<script src="./consultar.proveedor.ts"></script>
