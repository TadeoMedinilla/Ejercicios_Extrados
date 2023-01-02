// See https://aka.ms/new-console-template for more information
using Empresa.Servicios;

Console.WriteLine("Hello, World!");

//Instanciar un objeto Configuracion
Configuracion Configuracion= new Configuracion();

//Instanciar un objeto EmpleadoCRUD
EmpleadoCRUD EmpleadoCRUD = new EmpleadoCRUD(Configuracion);

//Pruebas metodos EmpleadosCRUD

//await EmpleadoCRUD.Insert();
//await EmpleadoCRUD.Update(6,2);
//await EmpleadoCRUD.Get(6);
//await EmpleadoCRUD.Delete(6);

SupervisorCRUD SupervisorCRUD = new SupervisorCRUD(Configuracion);

//Pruebas metodos SupervisorCRUD

//await SupervisorCRUD.Insert();
//await SupervisorCRUD.Update(7,3);
//await SupervisorCRUD.Get(7);
//await SupervisorCRUD.Delete(7);

EncargadoCRUD EncargadoCRUD = new EncargadoCRUD(Configuracion);

//Pruebas metodos EncargadosCRUD

//await EncargadoCRUD.Insert();
//await EncargadoCRUD.Update(8,1);
//await EncargadoCRUD.Get(8);
//await EncargadoCRUD.Delete(8);

Consultas consultas = new Consultas(Configuracion);

//Pruebas metodos consultas

//consultas.ListarPersonal();
await consultas.AscenderEmpleado(1, 1);

Console.WriteLine("Listo");
Console.ReadLine();