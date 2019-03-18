<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de CostosNacional</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarcostosnacional"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de costosnacional</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstcostosnacional"
					  v-bind:headers="headers"
					  :search="buscarcostosnacional"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstcostosnacional">
				<td style="width: 10%;">{{ lstcostosnacional.item.iddia }}</td>
				<td style="width: 10%;">{{ lstcostosnacional.item.idtramo }}</td>
				<td style="width: 10%;">{{ lstcostosnacional.item.idtarifa }}</td>
				<td style="width: 10%;">{{ lstcostosnacional.item.idservicio }}</td>
				<td style="width: 10%;">{{ lstcostosnacional.item.idrango }}</td>
				<td style="width: 70%;">{{ lstcostosnacional.item.costo }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstcostosnacional.item.iddia ,lstcostosnacional.item.idtramo ,lstcostosnacional.item.idtarifa ,lstcostosnacional.item.idservicio ,lstcostosnacional.item.idrango)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de costosnacional</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstcostosnacional.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de CostosNacional</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarcostosnacional }}", no se encontraron registros.
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

<script src="./consultar.costosnacional.ts"></script>
