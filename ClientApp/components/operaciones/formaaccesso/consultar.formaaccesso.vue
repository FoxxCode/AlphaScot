<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de FormaAccesso</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscarformaaccesso"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de formaaccesso</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstformaaccesso"
					  v-bind:headers="headers"
					  :search="buscarformaaccesso"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstformaaccesso">
				<td style="width: 10%;">{{ lstformaaccesso.item.idrol }}</td>
				<td style="width: 10%;">{{ lstformaaccesso.item.idforma }}</td>
				<td style="width: 70%;">{{ lstformaaccesso.item.acceso }}</td>
				<td style="width: 70%;">{{ lstformaaccesso.item.insercion }}</td>
				<td style="width: 70%;">{{ lstformaaccesso.item.modificacion }}</td>
				<td style="width: 70%;">{{ lstformaaccesso.item.eliminacion }}</td>
				<td style="width: 70%;">{{ lstformaaccesso.item.consulta }}</td>
				<td style="width: 70%;">{{ lstformaaccesso.item.impresion }}</td>
				<td style="width: 70%;">{{ lstformaaccesso.item.operacion }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstformaaccesso.item.idrol ,lstformaaccesso.item.idforma)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de formaaccesso</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstformaaccesso.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de FormaAccesso</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscarformaaccesso }}", no se encontraron registros.
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

<script src="./consultar.formaaccesso.ts"></script>
