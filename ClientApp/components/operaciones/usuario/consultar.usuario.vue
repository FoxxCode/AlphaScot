<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de Usuario</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarusuario"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de usuario</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstusuario"
					  v-bind:headers="headers"
					  :search="buscarusuario"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstusuario">
				<td style="width: 10%;">{{ lstusuario.item.idusuario }}</td>
				<td style="width: 10%;">{{ lstusuario.item.idempresa }}</td>
				<td style="width: 70%;">{{ lstusuario.item.idcomunicacion }}</td>
				<td style="width: 70%;">{{ lstusuario.item.descripcion }}</td>
				<td style="width: 70%;">{{ lstusuario.item.encargado }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstusuario.item.idusuario ,lstusuario.item.idempresa)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de usuario</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstusuario.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de Usuario</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarusuario }}", no se encontraron registros.
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

<script src="./consultar.usuario.ts"></script>
