<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de Areas</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarareas"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de areas</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstareas"
					  v-bind:headers="headers"
					  :search="buscarareas"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstareas">
				<td style="width: 10%;">{{ lstareas.item.idarea }}</td>
				<td style="width: 70%;">{{ lstareas.item.descripcion }}</td>
				<td style="width: 70%;">{{ lstareas.item.etiqueta }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstareas.item.idarea)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de areas</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstareas.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de Areas</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarareas }}", no se encontraron registros.
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

<script src="./consultar.areas.ts"></script>
