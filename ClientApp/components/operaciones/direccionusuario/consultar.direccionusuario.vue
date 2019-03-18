<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de DireccionUsuario</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscardireccionusuario"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de direccionusuario</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstdireccionusuario"
					  v-bind:headers="headers"
					  :search="buscardireccionusuario"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstdireccionusuario">
				<td style="width: 10%;">{{ lstdireccionusuario.item.iddireccion }}</td>
				<td style="width: 10%;">{{ lstdireccionusuario.item.idusuario }}</td>
				<td style="width: 70%;">{{ lstdireccionusuario.item.idzona }}</td>
				<td style="width: 70%;">{{ lstdireccionusuario.item.idciudad }}</td>
				<td style="width: 70%;">{{ lstdireccionusuario.item.idpais }}</td>
				<td style="width: 70%;">{{ lstdireccionusuario.item.descripcion }}</td>
				<td style="width: 70%;">{{ lstdireccionusuario.item.numero }}</td>
				<td style="width: 70%;">{{ lstdireccionusuario.item.pordefecto }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstdireccionusuario.item.iddireccion ,lstdireccionusuario.item.idusuario)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de direccionusuario</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstdireccionusuario.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de DireccionUsuario</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscardireccionusuario }}", no se encontraron registros.
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

<script src="./consultar.direccionusuario.ts"></script>
