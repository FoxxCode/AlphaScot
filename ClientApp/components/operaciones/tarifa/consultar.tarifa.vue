<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de Tarifa</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscartarifa"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de tarifa</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lsttarifa"
					  v-bind:headers="headers"
					  :search="buscartarifa"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lsttarifa">
				<td style="width: 10%;">{{ lsttarifa.item.idtarifa }}</td>
				<td style="width: 70%;">{{ lsttarifa.item.idservicio }}</td>
				<td style="width: 70%;">{{ lsttarifa.item.descripcion }}</td>
				<td style="width: 70%;">{{ lsttarifa.item.idciudad }}</td>
				<td style="width: 70%;">{{ lsttarifa.item.idpais }}</td>
				<td style="width: 70%;">{{ lsttarifa.item.etiqueta }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lsttarifa.item.idtarifa)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de tarifa</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lsttarifa.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de Tarifa</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscartarifa }}", no se encontraron registros.
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

<script src="./consultar.tarifa.ts"></script>
