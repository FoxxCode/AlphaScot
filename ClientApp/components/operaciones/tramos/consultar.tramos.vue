<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de Tramos</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscartramos"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de tramos</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lsttramos"
					  v-bind:headers="headers"
					  :search="buscartramos"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lsttramos">
				<td style="width: 10%;">{{ lsttramos.item.idtramo }}</td>
				<td style="width: 70%;">{{ lsttramos.item.etiqueta }}</td>
				<td style="width: 70%;">{{ lsttramos.item.horainicio }}</td>
				<td style="width: 70%;">{{ lsttramos.item.horafinal }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lsttramos.item.idtramo)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de tramos</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lsttramos.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de Tramos</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscartramos }}", no se encontraron registros.
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

<script src="./consultar.tramos.ts"></script>
