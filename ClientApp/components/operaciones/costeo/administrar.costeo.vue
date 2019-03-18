<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de Costeo</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDLlamada:</h4>
						<v-text-field v-model="costeo.idllamada" @input="costeo.idllamada = $event.toUpperCase()" required readonly hint="Ingrese IDLlamada"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDInternoUsuario:</h4>
						<v-text-field v-model="costeo.idinternousuario" @input="costeo.idinternousuario = $event.toUpperCase()" required clearable hint="Ingrese IDInternoUsuario"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDUsuarioDepto:</h4>
						<v-text-field v-model="costeo.idusuariodepto" @input="costeo.idusuariodepto = $event.toUpperCase()" required clearable hint="Ingrese IDUsuarioDepto"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDInterno:</h4>
						<v-text-field v-model="costeo.idinterno" @input="costeo.idinterno = $event.toUpperCase()" required clearable hint="Ingrese IDInterno"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDUsuarioCuenta:</h4>
						<v-text-field v-model="costeo.idusuariocuenta" @input="costeo.idusuariocuenta = $event.toUpperCase()" required clearable hint="Ingrese IDUsuarioCuenta"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDCuenta:</h4>
						<v-text-field v-model="costeo.idcuenta" @input="costeo.idcuenta = $event.toUpperCase()" required clearable hint="Ingrese IDCuenta"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDCentral:</h4>
						<v-text-field v-model="costeo.idcentral" @input="costeo.idcentral = $event.toUpperCase()" required clearable hint="Ingrese IDCentral"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDLinea:</h4>
						<v-text-field v-model="costeo.idlinea" @input="costeo.idlinea = $event.toUpperCase()" required clearable hint="Ingrese IDLinea"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDProveedor:</h4>
						<v-text-field v-model="costeo.idproveedor" @input="costeo.idproveedor = $event.toUpperCase()" required clearable hint="Ingrese IDProveedor"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDTramo:</h4>
						<v-text-field v-model="costeo.idtramo" @input="costeo.idtramo = $event.toUpperCase()" required clearable hint="Ingrese IDTramo"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDTarifa:</h4>
						<v-text-field v-model="costeo.idtarifa" @input="costeo.idtarifa = $event.toUpperCase()" required clearable hint="Ingrese IDTarifa"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">ID:</h4>
						<v-text-field v-model="costeo.id" @input="costeo.id = $event.toUpperCase()" required clearable hint="Ingrese ID"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Fecha:</h4>
						<v-text-field v-model="costeo.fecha" @input="costeo.fecha = $event.toUpperCase()" clearable hint="Ingrese Fecha"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Hora:</h4>
						<v-text-field v-model="costeo.hora" @input="costeo.hora = $event.toUpperCase()" clearable hint="Ingrese Hora"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Duracion:</h4>
						<v-text-field v-model="costeo.duracion" @input="costeo.duracion = $event.toUpperCase()" clearable hint="Ingrese Duracion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Numero:</h4>
						<v-text-field v-model="costeo.numero" @input="costeo.numero = $event.toUpperCase()" clearable hint="Ingrese Numero"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Costo:</h4>
						<v-text-field v-model="costeo.costo" @input="costeo.costo = $event.toUpperCase()" clearable hint="Ingrese Costo"></v-text-field>
					</v-flex>
				</v-layout>
			</v-card-text>
		</v-form>
		<v-card-actions>
			<v-btn color="green" style="width: 50%" @click="Grabar">Grabar</v-btn>
			<v-btn color="red" style="width: 50%" @click="Cancelar">Cancelar</v-btn>
		</v-card-actions>
		<v-footer class="pa-3">
			{{ error }}
			<v-spacer></v-spacer>
			<div>&copy; {{ new Date().getFullYear() }}</div>
		</v-footer>
	</v-card>
</template>

<script src="./administrar.costeo.ts"></script>
