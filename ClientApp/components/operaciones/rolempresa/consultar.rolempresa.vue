<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de RolEmpresa</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarrolempresa"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de rolempresa</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstrolempresa"
					  v-bind:headers="headers"
					  :search="buscarrolempresa"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstrolempresa">
				<td style="width: 10%;">{{ lstrolempresa.item.idrolempresa }}</td>
				<td style="width: 70%;">{{ lstrolempresa.item.idempresa }}</td>
				<td style="width: 70%;">{{ lstrolempresa.item.idrol }}</td>
				<td style="width: 70%;">{{ lstrolempresa.item.fecharegistro }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstrolempresa.item.idrolempresa)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de rolempresa</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstrolempresa.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de RolEmpresa</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarrolempresa }}", no se encontraron registros.
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

<script src="./consultar.rolempresa.ts"></script>
