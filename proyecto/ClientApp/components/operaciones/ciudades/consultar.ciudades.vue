<template>
	<v-card style="width: 50%;">
		<v-toolbar>
			<v-toolbar-title>Datos de Ciudades</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarciudades"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de ciudades</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstciudades"
					  v-bind:headers="headers"
					  :search="buscarciudades"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstciudades">
				<td style="width: 50%;">{{ lstciudades.item.descripcion }}</td>
                <td style="width: 30%;">{{ select_pais(lstciudades.item.idpais) }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 10%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstciudades.item.idciudad)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de ciudades</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstciudades.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de Ciudades</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarciudades }}", no se encontraron registros.
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

<script src="./consultar.ciudades.ts"></script>
