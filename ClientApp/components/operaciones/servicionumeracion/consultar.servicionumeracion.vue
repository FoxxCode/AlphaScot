<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de ServicioNumeracion</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarservicionumeracion"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de servicionumeracion</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstservicionumeracion"
					  v-bind:headers="headers"
					  :search="buscarservicionumeracion"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstservicionumeracion">
				<td style="width: 10%;">{{ lstservicionumeracion.item.idrango }}</td>
				<td style="width: 10%;">{{ lstservicionumeracion.item.idservicio }}</td>
				<td style="width: 70%;">{{ lstservicionumeracion.item.idciudad }}</td>
				<td style="width: 70%;">{{ lstservicionumeracion.item.idpais }}</td>
				<td style="width: 70%;">{{ lstservicionumeracion.item.descripcion }}</td>
				<td style="width: 70%;">{{ lstservicionumeracion.item.etiqueta }}</td>
				<td style="width: 70%;">{{ lstservicionumeracion.item.numeroinicio }}</td>
				<td style="width: 70%;">{{ lstservicionumeracion.item.numerofinal }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstservicionumeracion.item.idrango ,lstservicionumeracion.item.idservicio)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de servicionumeracion</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstservicionumeracion.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de ServicioNumeracion</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarservicionumeracion }}", no se encontraron registros.
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

<script src="./consultar.servicionumeracion.ts"></script>
