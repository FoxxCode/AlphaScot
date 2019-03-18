<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de Costeo</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarcosteo"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de costeo</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstcosteo"
					  v-bind:headers="headers"
					  :search="buscarcosteo"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstcosteo">
				<td style="width: 10%;">{{ lstcosteo.item.idllamada }}</td>
				<td style="width: 70%;">{{ lstcosteo.item.idinternousuario }}</td>
				<td style="width: 70%;">{{ lstcosteo.item.idusuariodepto }}</td>
				<td style="width: 70%;">{{ lstcosteo.item.idinterno }}</td>
				<td style="width: 70%;">{{ lstcosteo.item.idusuariocuenta }}</td>
				<td style="width: 70%;">{{ lstcosteo.item.idcuenta }}</td>
				<td style="width: 70%;">{{ lstcosteo.item.idcentral }}</td>
				<td style="width: 70%;">{{ lstcosteo.item.idlinea }}</td>
				<td style="width: 70%;">{{ lstcosteo.item.idproveedor }}</td>
				<td style="width: 70%;">{{ lstcosteo.item.idtramo }}</td>
				<td style="width: 70%;">{{ lstcosteo.item.idtarifa }}</td>
				<td style="width: 70%;">{{ lstcosteo.item.id }}</td>
				<td style="width: 70%;">{{ lstcosteo.item.fecha }}</td>
				<td style="width: 70%;">{{ lstcosteo.item.hora }}</td>
				<td style="width: 70%;">{{ lstcosteo.item.duracion }}</td>
				<td style="width: 70%;">{{ lstcosteo.item.numero }}</td>
				<td style="width: 70%;">{{ lstcosteo.item.costo }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstcosteo.item.idllamada)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de costeo</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstcosteo.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de Costeo</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarcosteo }}", no se encontraron registros.
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

<script src="./consultar.costeo.ts"></script>
