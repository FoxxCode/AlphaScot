<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de SMDR</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarsmdr"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de smdr</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstsmdr"
					  v-bind:headers="headers"
					  :search="buscarsmdr"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstsmdr">
				<td style="width: 10%;">{{ lstsmdr.item.idllamada }}</td>
				<td style="width: 70%;">{{ lstsmdr.item.idestado }}</td>
				<td style="width: 70%;">{{ lstsmdr.item.codigo }}</td>
				<td style="width: 70%;">{{ lstsmdr.item.fecha }}</td>
				<td style="width: 70%;">{{ lstsmdr.item.hora }}</td>
				<td style="width: 70%;">{{ lstsmdr.item.duracion }}</td>
				<td style="width: 70%;">{{ lstsmdr.item.linea }}</td>
				<td style="width: 70%;">{{ lstsmdr.item.interno }}</td>
				<td style="width: 70%;">{{ lstsmdr.item.cuenta }}</td>
				<td style="width: 70%;">{{ lstsmdr.item.numero }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstsmdr.item.idllamada)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de smdr</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstsmdr.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de SMDR</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarsmdr }}", no se encontraron registros.
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

<script src="./consultar.smdr.ts"></script>
