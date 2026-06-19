# BlazorHybridTP4
Resolución de las consignas propuestas en el TP4 de programación web.

Aplicación .NET MAUI Blazor Hybrid que consume la [Platzi Fake API](https://fakeapi.platzi.com/), una API REST pública para pruebas. El proyecto implementa un sistema CRUD completo utilizando los métodos HTTP correspondientes y aplicando buenas prácticas de desarrollo.

## Configuración y Arquitectura

* **Inyección de Dependencias:** En `MauiProgram.cs` se registra el `HttpClient` con su `BaseAddress` apuntando a `https://api.escuelajs.co/api/v1/`. Se utiliza la interfaz `IProductService` para desacoplar la lógica de acceso a datos de la interfaz de usuario.
* **Arquitectura SPA (Single Page Application):** A diferencia del modelo tradicional multi-página, todas las operaciones CRUD (Crear, Leer, Actualizar y Eliminar) se realizan dinámicamente dentro del mismo componente `Products.razor`, ofreciendo una experiencia de usuario más moderna y fluida.

## Visibilidad de Códigos HTTP (Status Codes)

El servicio `ProductService` fue configurado para leer las respuestas crudas del servidor (`HttpResponseMessage`). La interfaz gráfica intercepta estas respuestas y muestra en tiempo real el código exacto devuelto por la API de Platzi (por ejemplo: `200 OK`, `201 Created`) inmediatamente después de cada interacción.

## Páginas y Rutas

| Ruta | Componente | Operaciones HTTP Integradas |
| :--- | :--- | :--- |
| `/` y `/productos` | `Products.razor` | GET, POST, PUT, DELETE |
| `/usuarios` | `Users.razor` | GET (Lectura de directorio) |

## Endpoints Consumidos

| Método | Endpoint | Uso en la Aplicación |
| :--- | :--- | :--- |
| **GET** | `/products` | Listar el catálogo de productos disponibles. |
| **POST** | `/products/` | Crear un nuevo producto. |
| **PUT** | `/products/{id}` | Actualizar datos de un producto existente. |
| **DELETE** | `/products/{id}` | Eliminar un producto (Baja física en la API). |
| **GET** | `/users` | Listar usuarios registrados. |

## Características Adicionales
* **Baja Lógica (Soft Delete):** Se implementó un estado en memoria para simular una "papelera de reciclaje", permitiendo al usuario discontinuar productos de la vista principal sin borrarlos inmediatamente de la base de datos externa.
* **Alertas de Seguridad:** Integración con `IJSRuntime` para prevenir borrados accidentales mediante cuadros de diálogo nativos.
