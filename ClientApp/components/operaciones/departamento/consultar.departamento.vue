<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de Departamento</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscardepartamento"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de departamento</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstdepartamento"
					  v-bind:headers="headers"
					  :search="buscardepartamento"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstdepartamento">
				<td style="width: 10%;">{{ lstdepartamento.item.iddepartamento }}</td>
				<td style="width: 10%;">{{ lstdepartamento.item.idempresa }}</td>
				<td style="width: 70%;">{{ lstdepartamento.item.descripcion }}</td>
				<td style="width: 70%;">{{ lstdepartamento.item.nivel }}</td>
				<td style="width: 70%;">{{ lstdepartamento.item.deptopadre }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstdepartamento.item.iddepartamento ,lstdepartamento.item.idempresa)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de departamento</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstdepartamento.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de Departamento</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscardepartamento }}", no se encontraron registros.
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

<script src="./consultar.departamento.ts"></script>
