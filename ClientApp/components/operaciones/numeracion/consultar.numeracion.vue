<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de Numeracion</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarnumeracion"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de numeracion</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstnumeracion"
					  v-bind:headers="headers"
					  :search="buscarnumeracion"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstnumeracion">
				<td style="width: 10%;">{{ lstnumeracion.item.idrango }}</td>
				<td style="width: 70%;">{{ lstnumeracion.item.descripcion }}</td>
				<td style="width: 70%;">{{ lstnumeracion.item.etiqueta }}</td>
				<td style="width: 70%;">{{ lstnumeracion.item.numeroinicio }}</td>
				<td style="width: 70%;">{{ lstnumeracion.item.numerofinal }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstnumeracion.item.idrango)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de numeracion</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstnumeracion.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de Numeracion</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarnumeracion }}", no se encontraron registros.
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

<script src="./consultar.numeracion.ts"></script>
