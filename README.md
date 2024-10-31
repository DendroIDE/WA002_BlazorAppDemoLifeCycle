
# WA002_BlazorAppDemoLifeCycle - Blazor App

Este proyecto es una aplicación ASP.NET Blazor diseñada para explorar los métodos del ciclo de vida de un componente Blazor. La clase principal, `Home`, demuestra cómo gestionar el estado y el comportamiento de una variable llamada `Valor` en función de los diferentes eventos del ciclo de vida del componente. Este enfoque facilita el desarrollo de aplicaciones Blazor al permitir la observación en tiempo real de los cambios de estado en la interfaz de usuario durante las distintas fases del ciclo de vida.

## Descripción del Componente `Home`

El componente `Home` utiliza métodos del ciclo de vida de Blazor para modificar el valor de `Valor` en cada etapa del ciclo de vida. Cada cambio de estado se registra en la consola de depuración, lo que permite a los desarrolladores ver en qué punto se encuentra el componente durante su ejecución.

### Código del Componente `Home.razor`

Este componente Blazor combina métodos de ciclo de vida y una interfaz HTML para presentar el valor de `Valor` en la página.

```razor
@page "/"
@rendermode InteractiveServer

<PageTitle>Home</PageTitle>

<h1>Hello, world!</h1>
<h2>@Valor</h2>

Welcome to your new app.
```

### Explicación de las Directivas y Elementos

- `@page "/"`: Define la ruta de la página como la raíz (`"/"`), de modo que al navegar a la raíz del sitio web, el contenido de `Home` se cargará.
- `@rendermode InteractiveServer`: Especifica el modo de renderizado interactivo en tiempo real en el servidor, permitiendo que el componente se actualice automáticamente cuando cambia su estado. Es una característica común en aplicaciones Blazor Server.
- `<PageTitle>Home</PageTitle>`: Define el título de la pestaña del navegador cuando esta página está activa, en este caso, "Home".

### HTML del Componente

- `<h1>Hello, world!</h1>`: Muestra un título de nivel 1 con el texto "Hello, world!".
- `<h2>@Valor</h2>`: Muestra el valor actual de la propiedad `Valor`, que cambia en función del método de ciclo de vida ejecutado en ese momento.
- `"Welcome to your new app."`: Un mensaje de bienvenida para los usuarios.

### Relación con el Ciclo de Vida

El valor de `@Valor` en `<h2>` cambia automáticamente conforme se ejecutan los métodos del ciclo de vida en el componente (`SetParametersAsync`, `OnInitializedAsync`, `OnParametersSetAsync` y `OnAfterRenderAsync`). Esto permite observar los cambios en tiempo real en la interfaz, útil tanto para depuración como para pruebas en la fase de desarrollo.

## Descripción General de la Clase `Home`

La clase `Home` es un componente parcial de Blazor ubicado en el espacio de nombres `WA002_BlazorAppDemoLifeCycle.Components.Pages`. Implementa varios métodos del ciclo de vida que permiten modificar el valor de la propiedad `Valor` en diferentes etapas de la vida del componente. En cada método, `Valor` toma un valor descriptivo y se registra en la consola para facilitar la depuración.

### Propiedad

```csharp
public string Valor { get; set; }
```

Almacena un valor de tipo `string` que cambia en cada método de ciclo de vida, permitiendo rastrear en qué método del ciclo de vida se encuentra el componente.

### Métodos de Ciclo de Vida

1. **SetParametersAsync(ParameterView parameters)**:
   - Sobrescribe el método `SetParametersAsync` que Blazor llama cuando el componente recibe nuevos parámetros.
   - Establece el valor "Ejecución de SetParametersAsync" en `Valor` y lo registra.
   - Llama al método base `SetParametersAsync`.
   - **Propósito**: Inicializar o actualizar parámetros antes de la renderización.

2. **OnInitializedAsync()**:
   - Sobrescribe el método `OnInitializedAsync`, que se llama al inicializar el componente.
   - Cambia `Valor` a "OnInitializedAsync" y lo registra.
   - Llama al método base para continuar con la inicialización asíncrona.
   - **Propósito**: Configurar el componente después de su creación, pero antes de que se procesen parámetros.

3. **OnParametersSetAsync()**:
   - Sobrescribe el método `OnParametersSetAsync`, que se ejecuta al establecer parámetros en el componente.
   - Cambia `Valor` a "OnParametersSetAsync" y lo registra.
   - Llama al método base.
   - **Propósito**: Realizar lógica adicional cuando se establecen nuevos parámetros.

4. **OnAfterRenderAsync(bool firstRender)**:
   - Sobrescribe `OnAfterRenderAsync`, que se ejecuta después de cada renderización.
   - Si `firstRender == true`, establece `Valor` en "OnAfterRenderAsync" y lo registra.
   - Llama a `StateHasChanged()` para actualizar el estado.
   - **Propósito**: Ejecutar lógica de post-renderización, como la manipulación del DOM.

### Ejemplo de Salida en el Registro

La secuencia en el registro debería mostrar el orden de los métodos del ciclo de vida, facilitando la depuración y comprensión del flujo:

```
Ejecución de SetParametersAsync
Ejecución de OnInitializedAsync
Ejecución de OnParametersSetAsync
Ejecución de OnAfterRenderAsync (solo en el primer render)
```

Este flujo proporciona una visión detallada del ciclo de vida de los componentes en Blazor, ayudando a optimizar el flujo de trabajo y la lógica de UI en aplicaciones complejas.
