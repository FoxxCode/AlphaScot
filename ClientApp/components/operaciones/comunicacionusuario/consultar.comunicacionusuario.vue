<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de ComunicacionUsuario</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarcomunicacionusuario"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de comunicacionusuario</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstcomunicacionusuario"
					  v-bind:headers="headers"
					  :search="buscarcomunicacionusuario"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstcomunicacionusuario">
				<td style="width: 10%;">{{ lstcomunicacionusuario.item.idcomunicacion }}</td>
				<td style="width: 70%;">{{ lstcomunicacionusuario.item.idtipocomunicacion }}</td>
				<td style="width: 70%;">{{ lstcomunicacionusuario.item.valor }}</td>
				<td style="width: 70%;">{{ lstcomunicacionusuario.item.pordefecto }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstcomunicacionusuario.item.idcomunicacion)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de comunicacionusuario</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstcomunicacionusuario.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de ComunicacionUsuario</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarcomunicacionusuario }}", no se encontraron registros.
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

<script src="./consultar.comunicacionusuario.ts"></script>
