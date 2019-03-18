<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de Central</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarcentral"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de central</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstcentral"
					  v-bind:headers="headers"
					  :search="buscarcentral"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstcentral">
				<td style="width: 10%;">{{ lstcentral.item.idcentral }}</td>
				<td style="width: 70%;">{{ lstcentral.item.idciudad }}</td>
				<td style="width: 70%;">{{ lstcentral.item.idpais }}</td>
				<td style="width: 70%;">{{ lstcentral.item.idempresa }}</td>
				<td style="width: 70%;">{{ lstcentral.item.descripcion }}</td>
				<td style="width: 70%;">{{ lstcentral.item.codigo }}</td>
				<td style="width: 70%;">{{ lstcentral.item.procesaentrada }}</td>
				<td style="width: 70%;">{{ lstcentral.item.procesasalida }}</td>
				<td style="width: 70%;">{{ lstcentral.item.procesacuentas }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstcentral.item.idcentral)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de central</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstcentral.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de Central</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarcentral }}", no se encontraron registros.
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

<script src="./consultar.central.ts"></script>
