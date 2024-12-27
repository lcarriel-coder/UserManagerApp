# Aplicación .NET 8 con Angular

Esta es una aplicación desarrollada con .NET 8 y Angular 18. A continuación, se detallan los pasos para la instalación y configuración.

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

1. **Dirigirse al directorio ClientApp**:
    ```bash
    cd ClientApp
    ```

2. **Iniciar el proyecto Angular**:
    ```bash
    ng serve
    ```



## Funcionalidades

- **Crear Persona**: Permite registrar una nueva persona con su usuario.
- **Login**: Permite a los usuarios iniciar sesión.
- **Ver Personas**: Muestra una lista de las personas creadas.


## Imagenes
![Crear persona]([Images/api_running.png](https://github.com/lcarriel-coder/UserManagerApp/blob/main/imagenes/Crear.png?raw=true))




¡Y eso es todo! Con estos pasos, deberías tener tu aplicación .NET 8 con Angular funcionando correctamente.
