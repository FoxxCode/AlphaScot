<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de DireccionEmpresa</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscardireccionempresa"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de direccionempresa</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstdireccionempresa"
					  v-bind:headers="headers"
					  :search="buscardireccionempresa"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstdireccionempresa">
				<td style="width: 10%;">{{ lstdireccionempresa.item.iddireccion }}</td>
				<td style="width: 10%;">{{ lstdireccionempresa.item.idempresa }}</td>
				<td style="width: 70%;">{{ lstdireccionempresa.item.idzona }}</td>
				<td style="width: 70%;">{{ lstdireccionempresa.item.idciudad }}</td>
				<td style="width: 70%;">{{ lstdireccionempresa.item.idpais }}</td>
				<td style="width: 70%;">{{ lstdireccionempresa.item.descripcion }}</td>
				<td style="width: 70%;">{{ lstdireccionempresa.item.numero }}</td>
				<td style="width: 70%;">{{ lstdireccionempresa.item.pordefecto }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstdireccionempresa.item.iddireccion ,lstdireccionempresa.item.idempresa)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de direccionempresa</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstdireccionempresa.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de DireccionEmpresa</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscardireccionempresa }}", no se encontraron registros.
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

<script src="./consultar.direccionempresa.ts"></script>
