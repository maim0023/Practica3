using System;
using System.Collections;

namespace practica3
{
  public class Programa
	{		
		private Hashtable tablaDatos;
		
		public Programa(){
			this.tablaDatos = new Hashtable();
		}
		
		public void capturar(){
			for(int i = 0; i<4 ;i++){
				Console.Clear();
				this.capturarDatosPersona(new Persona());
			}
		}
		
		private void capturarDatosPersona(Persona persona){
			this.capturarDatos(persona);
			this.agregarPersona(persona);

		}
		
		private void capturarDatos(Persona persona){
			Console.WriteLine("CAPTURA LOS DATOS DE LA PERSONA");
			if(persona.codigo == ""){
				Console.WriteLine("Dame el código");
				persona.codigo = Console.ReadLine();
			}
			
			Console.WriteLine("Nombre: ");
			persona.nombre = Console.ReadLine();
			Console.WriteLine("Dirección: ");
			persona.direccion = Console.ReadLine();
			Console.WriteLine("Teléfono: ");
			persona.telefono = Console.ReadLine();
			Console.WriteLine("Correo: ");
			persona.correo = Console.ReadLine();
		}
		
		private void agregarPersona(Persona persona){			
			if(this.tablaDatos.ContainsKey(persona.codigo)){
				this.tablaDatos.Remove(persona.codigo);
			}
			
			this.tablaDatos.Add(persona.codigo,persona);
		}
		
		public void editar(){
			for(int i = 0; i < 2; i++){
				Console.Clear();
				string codigo = "";
				Console.WriteLine("Cual es el código a editar");
				codigo = Console.ReadLine();
				if(this.tablaDatos.ContainsKey(codigo)){
					Persona persona = (Persona)this.tablaDatos[codigo];
					this.imprimePersona(persona);
					this.capturarDatosPersona(persona);
				}else{
					this.imprimeError();
				}
			}
		}
		
		public void eliminar(){
			for(int i = 0; i < 2; i++){
				Console.Clear();
				string codigo = "";
				Console.WriteLine("Cual es el código a eliminar");
				codigo = Console.ReadLine();
				if(this.tablaDatos.ContainsKey(codigo)){
					Persona persona = (Persona) this.tablaDatos[codigo];
					this.imprimePersona(persona);
					this.confirmarEliminacionYEliminar(persona.codigo);
				}else{
					this.imprimeError();
				}
			}
		}
		
		private void confirmarEliminacionYEliminar(string codigo){
			Console.WriteLine("¿Esta seguro que desea eliminar?");
			Console.WriteLine("0) No,\t 1) Si");
			string opcion = Console.ReadLine();
			if(opcion != "0"){
				this.tablaDatos.Remove(codigo);
			}
		}
		
		private void imprimeError(){
			Console.WriteLine("Lo sentimos el código no existe.");
			Console.WriteLine("Presione cualquier tecla para continuar.");
			Console.ReadLine();
		}
		
		public void imprimirTodos(){
	        ICollection personas = this.tablaDatos.Values;
	        
	        Console.WriteLine();
	        foreach( object objeto in personas )
	        {
	            Persona persona = (Persona) objeto;
				this.imprimePersona(persona);
	        }
		}
		
		private void imprimePersona(Persona persona){
			Console.WriteLine("Código: " + persona.codigo);
			Console.WriteLine("Nombre: " + persona.nombre);
			Console.WriteLine("Dirección: " + persona.direccion);
			Console.WriteLine("Teléfono: " + persona.telefono);
			Console.WriteLine("Facebook: " + persona.correo);
			Console.WriteLine("");
		}
		
	}
}
