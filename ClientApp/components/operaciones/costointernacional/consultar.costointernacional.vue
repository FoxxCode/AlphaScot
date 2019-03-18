<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de CostoInterNacional</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarcostointernacional"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de costointernacional</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstcostointernacional"
					  v-bind:headers="headers"
					  :search="buscarcostointernacional"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstcostointernacional">
				<td style="width: 10%;">{{ lstcostointernacional.item.iddia }}</td>
				<td style="width: 10%;">{{ lstcostointernacional.item.idtramo }}</td>
				<td style="width: 10%;">{{ lstcostointernacional.item.idtarifa }}</td>
				<td style="width: 10%;">{{ lstcostointernacional.item.idservicio }}</td>
				<td style="width: 10%;">{{ lstcostointernacional.item.idareapais }}</td>
				<td style="width: 70%;">{{ lstcostointernacional.item.costo }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstcostointernacional.item.iddia ,lstcostointernacional.item.idtramo ,lstcostointernacional.item.idtarifa ,lstcostointernacional.item.idservicio ,lstcostointernacional.item.idareapais)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de costointernacional</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstcostointernacional.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de CostoInterNacional</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarcostointernacional }}", no se encontraron registros.
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

<script src="./consultar.costointernacional.ts"></script>
