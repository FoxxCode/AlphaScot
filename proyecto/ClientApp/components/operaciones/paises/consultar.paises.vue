<template>
	<v-card style="width: 50%;">
		<v-toolbar>
			<v-toolbar-title>Datos de Paises</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarpaises"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de paises</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstpaises"
					  v-bind:headers="headers"
					  :search="buscarpaises"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstpaises">
				<td style="width: 10%;">{{ lstpaises.item.idpais }}</td>
				<td style="width: 70%;">{{ lstpaises.item.descripcion }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstpaises.item.idpais)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de paises</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstpaises.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de Paises</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarpaises }}", no se encontraron registros.
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

<script src="./consultar.paises.ts"></script>
