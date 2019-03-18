<template>
	<v-card style="width: 60%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de Continente</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarcontinente"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de continente</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstcontinente"
					  v-bind:headers="headers"
					  :search="buscarcontinente"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstcontinente">
				<td style="width: 10%;">{{ lstcontinente.item.idcontinente }}</td>
				<td style="width: 80%;">{{ lstcontinente.item.descripcion }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 10%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstcontinente.item.idcontinente)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de continente</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstcontinente.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de Continente</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarcontinente }}", no se encontraron registros.
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

<script src="./consultar.continente.ts"></script>
