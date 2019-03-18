<template>
	<v-card class="v-alert--no-icon" style="width: 40%; padding: 20px">
		<v-toolbar>
			<v-toolbar-title>Datos de Departamento</v-toolbar-title>
		</v-toolbar>
		<v-form ref="form" style="padding-top:20px">
			<v-card-text>
				<v-layout wrap>
					<v-flex sm12>
						<h4 class="mb-0">IDDepartamento:</h4>
						<v-text-field v-model="departamento.iddepartamento" @input="departamento.iddepartamento = $event.toUpperCase()" required readonly hint="Ingrese IDDepartamento"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">IDEmpresa:</h4>
						<v-text-field v-model="departamento.idempresa" @input="departamento.idempresa = $event.toUpperCase()" required readonly hint="Ingrese IDEmpresa"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Descripcion:</h4>
						<v-text-field v-model="departamento.descripcion" @input="departamento.descripcion = $event.toUpperCase()" required clearable hint="Ingrese Descripcion"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">Nivel:</h4>
						<v-text-field v-model="departamento.nivel" @input="departamento.nivel = $event.toUpperCase()" clearable hint="Ingrese Nivel"></v-text-field>
					</v-flex>
					<v-flex sm12>
						<h4 class="mb-0">DeptoPadre:</h4>
						<v-text-field v-model="departamento.deptopadre" @input="departamento.deptopadre = $event.toUpperCase()" clearable hint="Ingrese DeptoPadre"></v-text-field>
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

<script src="./administrar.departamento.ts"></script>
