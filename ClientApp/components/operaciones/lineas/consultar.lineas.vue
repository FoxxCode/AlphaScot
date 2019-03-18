<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de Lineas</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarlineas"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de lineas</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstlineas"
					  v-bind:headers="headers"
					  :search="buscarlineas"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstlineas">
				<td style="width: 10%;">{{ lstlineas.item.idlinea }}</td>
				<td style="width: 10%;">{{ lstlineas.item.idcentral }}</td>
				<td style="width: 70%;">{{ lstlineas.item.idproveedor }}</td>
				<td style="width: 70%;">{{ lstlineas.item.etiqueta }}</td>
				<td style="width: 70%;">{{ lstlineas.item.descripcion }}</td>
				<td style="width: 70%;">{{ lstlineas.item.numero }}</td>
				<td style="width: 70%;">{{ lstlineas.item.reportaentrada }}</td>
				<td style="width: 70%;">{{ lstlineas.item.reportasalida }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstlineas.item.idlinea ,lstlineas.item.idcentral)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de lineas</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstlineas.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de Lineas</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarlineas }}", no se encontraron registros.
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

<script src="./consultar.lineas.ts"></script>
