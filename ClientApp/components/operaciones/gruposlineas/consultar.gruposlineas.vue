<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de GruposLineas</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscargruposlineas"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de gruposlineas</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstgruposlineas"
					  v-bind:headers="headers"
					  :search="buscargruposlineas"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstgruposlineas">
				<td style="width: 10%;">{{ lstgruposlineas.item.idgrupo }}</td>
				<td style="width: 70%;">{{ lstgruposlineas.item.idcentral }}</td>
				<td style="width: 70%;">{{ lstgruposlineas.item.descripcion }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstgruposlineas.item.idgrupo)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de gruposlineas</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstgruposlineas.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de GruposLineas</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscargruposlineas }}", no se encontraron registros.
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

<script src="./consultar.gruposlineas.ts"></script>
