<template>
	<v-card>
		<v-toolbar>
			<v-toolbar-title>Datos de GrupoLineaLineas</v-toolbar-title>
			<v-spacer></v-spacer>
			<v-text-field v-model="buscargrupolinealineas"
						  append-icon="search"
						  label="Buscar Registro"
						  single-line
						  hide-details></v-text-field>
		</v-toolbar>
		<div class="text-xs-left d-flex align-left" style="width: 20%;">
			<v-tooltip bottom>
				<v-btn slot="activator" color="white" block @click="Insertar">Adicionar Nuevo Registro</v-btn>
				<span>Adicionar nuevo registro de grupolinealineas</span>
			</v-tooltip>
		</div>
		<v-data-table v-bind:items="lstgrupolinealineas"
					  v-bind:headers="headers"
					  :search="buscargrupolinealineas"
					  :rows-per-page-text="rowsPerPageText"
					  :rows-per-page-items = "rowsperpageitems"
					  class="elevation-1">
			<template slot="items" scope="lstgrupolinealineas">
				<td style="width: 10%;">{{ lstgrupolinealineas.item.idgrupo }}</td>
				<td style="width: 10%;">{{ lstgrupolinealineas.item.idlinea }}</td>
				<td style="width: 10%;">{{ lstgrupolinealineas.item.idcentral }}</td>
				<td style="width: 70%;">{{ lstgrupolinealineas.item.fecharegistro }}</td>
				<td class="text-xs-left d-flex align-left" style="width: 20%;">
					<v-tooltip bottom>
						<v-btn slot="activator" color="green" fab small dark @click="Actualizar(lstgrupolinealineas.item.idgrupo ,lstgrupolinealineas.item.idlinea ,lstgrupolinealineas.item.idcentral)"><v-icon>edit</v-icon></v-btn>
						<span>Editar Datos de grupolinealineas</span>
					</v-tooltip>
					<v-tooltip bottom>
						<v-btn slot="activator" color="red" fab small dark @click="Eliminar(lstgrupolinealineas.item)"><v-icon>delete</v-icon></v-btn>
						<span>Eliminar Registro de GrupoLineaLineas</span>
					</v-tooltip>
				</td>
			</template>
			<v-alert slot="no-results" :value="true" color="error" icon="warning">
				Error buscando "{{ buscargrupolinealineas }}", no se encontraron registros.
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

<script src="./consultar.grupolinealineas.ts"></script>
