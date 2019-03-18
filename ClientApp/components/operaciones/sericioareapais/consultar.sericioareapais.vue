<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de SericioAreaPais</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarsericioareapais"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de sericioareapais</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstsericioareapais"
					  v-bind:headers="headers"
					  :search="buscarsericioareapais"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstsericioareapais">
				<td style="width: 10%;">{{ lstsericioareapais.item.idareapais }}</td>
				<td style="width: 10%;">{{ lstsericioareapais.item.idservicio }}</td>
				<td style="width: 70%;">{{ lstsericioareapais.item.idarea }}</td>
				<td style="width: 70%;">{{ lstsericioareapais.item.idpais }}</td>
				<td style="width: 70%;">{{ lstsericioareapais.item.fecharegistro }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstsericioareapais.item.idareapais ,lstsericioareapais.item.idservicio)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de sericioareapais</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstsericioareapais.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de SericioAreaPais</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarsericioareapais }}", no se encontraron registros.
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

<script src="./consultar.sericioareapais.ts"></script>
