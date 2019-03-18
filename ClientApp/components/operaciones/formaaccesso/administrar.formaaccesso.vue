<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de FormaAccesso</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDRol:</h4>
						<v-text-field v-model="formaaccesso.idrol" @input="formaaccesso.idrol = $event.toUpperCase()" required readonly hint="Ingrese IDRol"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDForma:</h4>
						<v-text-field v-model="formaaccesso.idforma" @input="formaaccesso.idforma = $event.toUpperCase()" required readonly hint="Ingrese IDForma"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Acceso:</h4>
						<v-text-field v-model="formaaccesso.acceso" @input="formaaccesso.acceso = $event.toUpperCase()" clearable hint="Ingrese Acceso"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Insercion:</h4>
						<v-text-field v-model="formaaccesso.insercion" @input="formaaccesso.insercion = $event.toUpperCase()" clearable hint="Ingrese Insercion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Modificacion:</h4>
						<v-text-field v-model="formaaccesso.modificacion" @input="formaaccesso.modificacion = $event.toUpperCase()" clearable hint="Ingrese Modificacion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Eliminacion:</h4>
						<v-text-field v-model="formaaccesso.eliminacion" @input="formaaccesso.eliminacion = $event.toUpperCase()" clearable hint="Ingrese Eliminacion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Consulta:</h4>
						<v-text-field v-model="formaaccesso.consulta" @input="formaaccesso.consulta = $event.toUpperCase()" clearable hint="Ingrese Consulta"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Impresion:</h4>
						<v-text-field v-model="formaaccesso.impresion" @input="formaaccesso.impresion = $event.toUpperCase()" clearable hint="Ingrese Impresion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Operacion:</h4>
						<v-text-field v-model="formaaccesso.operacion" @input="formaaccesso.operacion = $event.toUpperCase()" clearable hint="Ingrese Operacion"></v-text-field>
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

<script src="./administrar.formaaccesso.ts"></script>
