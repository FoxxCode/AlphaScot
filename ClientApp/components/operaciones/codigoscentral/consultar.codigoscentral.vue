<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de CodigosCentral</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarcodigoscentral"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de codigoscentral</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstcodigoscentral"
					  v-bind:headers="headers"
					  :search="buscarcodigoscentral"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstcodigoscentral">
				<td style="width: 10%;">{{ lstcodigoscentral.item.idcodigo }}</td>
				<td style="width: 10%;">{{ lstcodigoscentral.item.fecha }}</td>
				<td style="width: 10%;">{{ lstcodigoscentral.item.idcuenta }}</td>
				<td style="width: 10%;">{{ lstcodigoscentral.item.idcentral }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstcodigoscentral.item.idcodigo ,lstcodigoscentral.item.fecha ,lstcodigoscentral.item.idcuenta ,lstcodigoscentral.item.idcentral)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de codigoscentral</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstcodigoscentral.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de CodigosCentral</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarcodigoscentral }}", no se encontraron registros.
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

<script src="./consultar.codigoscentral.ts"></script>
