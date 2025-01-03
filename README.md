# Aplicación .NET 8 y Angular 18

Esta es una aplicación desarrollada con **.NET 8** para el backend y **Angular 18** para el frontend. Utiliza diversas tecnologías modernas para proporcionar una experiencia robusta y eficiente.

## Tecnologías utilizadas

- **.NET 8**: Framework para el desarrollo del backend.
- **Entity Framework Core**: ORM utilizado para la gestión de la base de datos.
- **SQL Server**: Sistema de gestión de bases de datos relacional.
- **Angular 18**: Framework para el desarrollo del frontend.
- **TypeScript**: Lenguaje utilizado en el desarrollo del frontend con Angular.
- **Bootstrap**: Framework de CSS para diseño responsivo y estilos predefinidos.


## Pasos de Instalación

### Backend (.NET 8)

1. **Actualizar la migración**: Ejecuta el siguiente comando para actualizar la base de datos:
    ```bash
    update-database
    ```

2. **Agregar el procedimiento almacenado**: Ejecuta el siguiente script en tu base de datos para crear el procedimiento almacenado:
    ```sql
    CREATE PROCEDURE GetAllPersons
    AS
    BEGIN
        SELECT * FROM Persons
    END
    ```

3. **Correr la API**: Puedes correr la API utilizando Visual Studio. Esta API permite:
    - Crear una persona con su usuario.
    - Iniciar sesión (login).
    - Ver las personas creadas.

 

### Frontend (Angular)

1. **Dirigirse al directorio ClientApp dentro de UserManagerApp.Web**:
    ```bash
    cd ClientApp
    ```

2. **Iniciar el proyecto Angular**:
    ```bash
    ng serve
    ```

3. **Abrir el navegador**:

   Una vez que el servidor de desarrollo esté en funcionamiento, abre tu navegador preferido y navega a: http://localhost:4200



## Funcionalidades

- **Crear Persona**: Permite registrar una nueva persona con su usuario.
- **Login**: Permite a los usuarios iniciar sesión.
- **Ver Personas**: Muestra una lista de las personas creadas.


## Imagenes
![Crear persona](https://github.com/lcarriel-coder/UserManagerApp/blob/main/imagenes/Crear.png?raw=true)
![Lista personas](https://github.com/lcarriel-coder/UserManagerApp/blob/main/imagenes/Personas.png?raw=true)
![Login JWT](https://github.com/lcarriel-coder/UserManagerApp/blob/main/imagenes/login.png?raw=true)







¡Y eso es todo! Con estos pasos, deberías tener tu aplicación .NET 8 con Angular funcionando correctamente.
