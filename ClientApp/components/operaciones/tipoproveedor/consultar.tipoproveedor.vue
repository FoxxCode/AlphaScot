<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de TipoProveedor</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscartipoproveedor"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de tipoproveedor</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lsttipoproveedor"
					  v-bind:headers="headers"
					  :search="buscartipoproveedor"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lsttipoproveedor">
				<td style="width: 10%;">{{ lsttipoproveedor.item.idtipo }}</td>
				<td style="width: 70%;">{{ lsttipoproveedor.item.descripcion }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lsttipoproveedor.item.idtipo)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de tipoproveedor</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lsttipoproveedor.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de TipoProveedor</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscartipoproveedor }}", no se encontraron registros.
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

<script src="./consultar.tipoproveedor.ts"></script>
