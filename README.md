# BlazorHybridTP4
Resolución de las consignas propuestas en el TP4 de programación web.
Proyecto de desarrollo Blazor Hybrid (.NET MAUI). Consume de forma dinámica los endpoints de la Fake API de Platzi.

## Documentación de Endpoints Consumidos

* **URL Base de la API:** `https://api.escuelajs.co/api/v1/`
* **Página del Proyecto:** `/productos` (Componente: `Products.razor`)

### Registro de operaciones HTTP:

1. **GET `/products`**
   * **Método:** `GET`
   * **Descripción:** Trae el listado completo de productos en formato JSON para rellenar la tabla.
   * **Status Code:** `200 OK`

2. **POST `/products/`**
   * **Método:** `POST`
   * **Descripción:** Envía un objeto JSON con los campos estructurados en el formulario (Title, Price, Description, Images, CategoryId) para dar de alta un ítem.
   * **Status Code:** `201 Created`

3. **DELETE `/products/{id}`**
   * **Método:** `DELETE`
   * **Descripción:** Remueve un producto del servidor de pruebas utilizando su ID correspondiente.
   * **Status Code:** `200 OK`
