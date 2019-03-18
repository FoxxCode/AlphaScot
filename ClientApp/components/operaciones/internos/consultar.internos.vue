<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de Internos</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarinternos"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de internos</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstinternos"
					  v-bind:headers="headers"
					  :search="buscarinternos"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstinternos">
				<td style="width: 10%;">{{ lstinternos.item.idinterno }}</td>
				<td style="width: 10%;">{{ lstinternos.item.idcentral }}</td>
				<td style="width: 70%;">{{ lstinternos.item.descripcion }}</td>
				<td style="width: 70%;">{{ lstinternos.item.etiqueta }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstinternos.item.idinterno ,lstinternos.item.idcentral)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de internos</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstinternos.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de Internos</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarinternos }}", no se encontraron registros.
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

<script src="./consultar.internos.ts"></script>
