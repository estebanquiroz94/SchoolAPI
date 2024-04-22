# SchoolAPI

Prueba técnica

1.Clonar repositorio https://github.com/estebanquiroz94/SchoolAPI.git
2.Ejecutar script CrateTablesScheme.sql para la creación de  base de datos y las tablas. 
3.Ejecutar script TransactionImplementation.sql para insertar los datos.
4.En el archivo SchoolDbContext.cs en la linea 28, se debe actualizar el valor del "Server" por el correspondiente al equipo donde se ejecuta. 
5.Al ejecutar el proyecto, la API cargará la interfaz Swagger donde se evidencian los métodos disponibles por el controlador Student con sus respectivos verbos y parámetros requeridos. 
6.Se comparte colección de postman SchoolAPICollection donde se encuentran las peticiones para consumir la API. 
7. Se implentó proceso de Autenticación mediante Bearer Token, el cual se obtiene desde la petición "GetToken" con los valores brindados. Actualmente se hace la autenticación contra los valores del Appsettings.
8.Para activar la autenticación es necesario desdocumentar la linea 7 del archivo StudenController.cs
9. Se implementó patrón Repository para el acceso a Datos