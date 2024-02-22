# Aprendiendo Entity Framework Core y Visual Studio

## Índice
- [Introducción](#introducción)
- [Problema que Resuelve](#problema-que-resuelve)
- [Características y Tecnologías](#características-y-tecnologías)
- [Cómo Empezar](#cómo-empezar)
- [Ejemplos de Código](#ejemplos-de-código)
- [Contribuir](#contribuir)
- [Licencia](#licencia)
- [Contacto](#contacto)

## Introducción
Bienvenidos a este proyecto introductorio sobre Entity Framework (EF) para .NET, diseñado específicamente para aquellos que están comenzando su viaje en el desarrollo de software y buscan una comprensión sólida de la persistencia de datos y las operaciones básicas de manipulación de datos con EF. A través de ejemplos sencillos y directos, este repositorio ofrece una introducción práctica a conceptos clave como las operaciones CRUD, consultas LINQ, y la gestión de relaciones entre entidades, todo ello dentro de una estructura de proyecto fácil de entender y seguir.

El objetivo de este proyecto es brindar a los principiantes un recurso amigable y accesible para aprender a utilizar EF en aplicaciones .NET, cubriendo desde las tareas más básicas hasta algunas técnicas más avanzadas de forma gradual y comprensible. Se incluyen ejemplos prácticos que muestran cómo configurar EF, realizar consultas eficientes, insertar registros en la base de datos, y manejar relaciones complejas entre entidades, como las relaciones muchos a muchos, proporcionando así una base robusta para proyectos más complejos en el futuro.

Más allá de solo mostrar código, este proyecto pretende ser una guía para entender cómo EF facilita el desarrollo de aplicaciones con acceso a bases de datos, permitiendo a los nuevos desarrolladores adentrarse con confianza en proyectos más ambiciosos con una base sólida en EF. Si estás empezando con EF o deseas solidificar tu comprensión sobre la persistencia de datos en aplicaciones .NET, este proyecto te ofrecerá las herramientas y el conocimiento necesario para dar tus primeros pasos con confianza.

## Problema que Resuelve
El aprendizaje inicial de Entity Framework (EF) y la implementación de patrones de acceso a datos en aplicaciones .NET pueden ser desafiantes para los desarrolladores principiantes. Muchos enfrentan dificultades para comprender cómo realizar operaciones de base de datos de manera eficiente, cómo estructurar sus consultas, o incluso cómo manejar relaciones entre entidades de manera efectiva. Además, la transición de la teoría a la práctica y la comprensión de las mejores prácticas para aplicaciones reales suele ser un obstáculo significativo.

Este proyecto aborda estos desafíos al proporcionar una serie de ejemplos prácticos y fácilmente comprensibles que cubren el espectro de funcionalidades básicas y algunas avanzadas de EF. Se enfoca en demistificar el uso de EF para operaciones CRUD, consultas con LINQ, la inserción de registros, y la gestión de relaciones entre entidades, entre otros aspectos fundamentales. Al hacerlo, el proyecto facilita un camino de aprendizaje claro y estructurado para los desarrolladores que están dando sus primeros pasos en el mundo del desarrollo de software con EF.

El principal problema que este proyecto busca resolver es la brecha entre el conocimiento teórico de EF y su aplicación práctica en proyectos reales. Al ofrecer un recurso comprensible y accesible, aspira a empoderar a los desarrolladores principiantes con la confianza y las habilidades necesarias para comenzar a construir sus propias aplicaciones .NET con EF, promoviendo una comprensión profunda de los principios de acceso a datos y las mejores prácticas en la industria.

## Características y Tecnologías
- Entity Framework
- LINQ
- ASP.NET Core
- Ejemplos de operaciones CRUD
- Relaciones muchos a muchos
- Consultas entre múltiples entidades

## Cómo Empezar
Para comenzar a explorar y ejecutar este proyecto de Entity Framework en tu entorno local, sigue estos pasos detallados. Estas instrucciones te guiarán desde la configuración inicial hasta la ejecución de diferentes funcionalidades del proyecto.

### Prerrequisitos

Antes de clonar y ejecutar el proyecto, asegúrate de tener instalados los siguientes componentes en tu sistema:

- **SQL Server Management Studio (SSMS) Express:** Esencial para gestionar la base de datos SQL Server que utilizará el proyecto.
- **SDK de .NET 6:** Necesario para compilar y ejecutar las aplicaciones .NET, incluido este proyecto.

### Configuración del Proyecto

1. **Clonar el Repositorio:** Comienza clonando este repositorio en tu máquina local utilizando tu cliente Git favorito o la línea de comando.

2. **Configurar la Base de Datos:**
   - **Crear una Base de Datos en SQL Server:** Utiliza SSMS para crear una nueva base de datos que el proyecto utilizará para almacenar y gestionar los datos.
   - **Modificar el Archivo appsettings.json:** Abre el proyecto y localiza el archivo `StreamerDbContext.cs`. Modifica la cadena de conexión para apuntar a la base de datos que acabas de crear, asegurándote de que el nombre del servidor, la base de datos y las credenciales sean correctos. (Simplemente Modificar la seccion de OnConfiguring en l parte que indica Database = "Nombre_De_Tu_Base_Datos")

3. **Aplicar Migraciones:**
   - Abre la consola del Administrador de Paquetes (Package Manager Console) en Visual Studio.
   - Ejecuta el comando `update-database` para aplicar las migraciones de Entity Framework al esquema de tu base de datos. Esto preparará tu base de datos con la estructura necesaria para el proyecto.

### Ejecución del Proyecto

Para explorar las diferentes funcionalidades del proyecto, puedes ir comentando y descomentando las llamadas a las funciones en el archivo `Program.cs`. Aquí tienes una lista de las funciones disponibles para ejecutar:

- `await MultipleEntitiesQuery();`
- `await AddNewDirectorWithVideo();`
- `await AddNewActorWithVideo();`
- `await AddNewStreamerWhithVideoId();`
- `await AddNewStreamerWhithVideo();`
- `await streamingNoTracking();`
- `await QueryLinQ();`
- `await QueryMethods();`
- `await QueryFilter();`
- `await AddNewRecords();`
- `QueryStreaming();`

Esto te permitirá hacer un recorrido paso a paso por las diferentes consultas y métodos utilizados en el proyecto, comprendiendo mejor cómo se realiza cada operación con Entity Framework.

### Comenzar a Explorar

Con la base de datos configurada y el proyecto listo, puedes comenzar a explorar las distintas características y funcionalidades que ofrece este proyecto. Experimenta con las diferentes consultas y operaciones para ver cómo Entity Framework maneja la interacción con la base de datos.

## Ejemplos de Código

### Ejemplo 1: Agregar un Nuevo Director y Asociarlo con un Video
```csharp
async Task AddNewDirectorWithVideo()
{
    var director = new Director
    {
        Nombre = "Lorenzo",
        Apellido = "Basteri",
        VideoId = 1 // Asume que el video con ID 1 ya existe
    };
    
    await dbContext.AddAsync(director);
    await dbContext.SaveChangesAsync();
    Console.WriteLine("Director agregado exitosamente.");
}
```

Este ejemplo demuestra cómo agregar un nuevo director a la base de datos y asociarlo con un video existente.

### Ejemplo 2: Consulta de Entidades Relacionadas
```csharp
async Task MultipleEntitiesQuery()
{
    var videoWithDirector = await dbContext.Videos
        .Where(v => v.Director != null)
        .Include(v => v.Director)
        .Select(v => new {
            Director_Nombre_Completo = $"{v.Director.Nombre} {v.Director.Apellido}",
            Movie = v.Nombre
        })
        .ToListAsync();

    foreach (var pelicula in videoWithDirector)
    {
        Console.WriteLine($"{pelicula.Movie} - {pelicula.Director_Nombre_Completo}");
    }
}
```

Este fragmento realiza una consulta para obtener videos que tienen un director asociado, incluyendo los detalles del director y el nombre del video.

### Ejemplo 3: Consulta y Filtro con LINQ
```csharp
async Task QueryLinQ()
{
    Console.WriteLine("Ingrese el servicio de streaming");
    var streamerNombre = Console.ReadLine();

    var streamers = await dbContext.Streamers
        .Where(s => EF.Functions.Like(s.Nombre, $"%{streamerNombre}%"))
        .ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}
```

Este código muestra cómo realizar consultas filtradas utilizando LINQ y el método Like para buscar streamers por nombre.


## Contribuir

¡Tu contribución es bienvenida! Estamos encantados de recibir ayuda para mejorar y expandir este proyecto. Si estás interesado en contribuir, por favor sigue los siguientes pasos:

1. **Fork el Repositorio:** Comienza haciendo un fork del proyecto a tu cuenta de GitHub. Esto te permite experimentar y realizar cambios sin afectar el proyecto original.

2. **Clona tu Fork:** Clona el repositorio forkeado a tu máquina local para comenzar a trabajar en los cambios.

3. **Crea una Rama:** Para cada nueva característica o corrección, crea una rama separada en tu fork. Esto facilita la gestión de los cambios y mantiene el proyecto organizado. Usa nombres descriptivos para tus ramas, por ejemplo, `caracteristica-nueva-interfaz` o `correccion-error-conexión`.

4. **Implementa tus Cambios:** Realiza los cambios o mejoras en tu rama. Asegúrate de seguir las convenciones de codificación del proyecto y de probar tu código exhaustivamente.

5. **Documenta tus Cambios:** Actualiza la documentación si estás introduciendo nuevas características o realizando cambios que alteren el comportamiento existente. La documentación clara y precisa es crucial para la usabilidad y mantenibilidad del proyecto.

6. **Envía un Pull Request (PR):** Una vez que hayas completado tus cambios, envía un pull request al repositorio original. En la descripción del PR, explica los cambios realizados y cualquier otra información relevante que ayude a los revisores a entender tu contribución.

7. **Revisión:** Tu PR será revisado por los mantenedores del proyecto. Esté preparado para discutir tus cambios y realizar ajustes según sea necesario. La comunicación abierta y respetuosa es clave para una colaboración exitosa.

### Directrices para Contribuir

- **Sigue las convenciones de codificación:** Mantén tu código en línea con las prácticas establecidas en el proyecto.
- **Escribe pruebas:** Si es posible, incluye pruebas que validen los cambios o nuevas características que estás introduciendo.
- **Reporta errores:** Si encuentras errores o problemas, por favor crea un issue describiendo el problema, cómo reproducirlo, y, si es posible, una sugerencia para solucionarlo.
- **Sugiere mejoras:** Las ideas para nuevas características o mejoras en las existentes son siempre bienvenidas. Crea un issue para discutir tus ideas con el equipo.

### Código de Conducta

Nos comprometemos a proporcionar un ambiente amigable y acogedor para todos los colaboradores. Por favor, sé respetuoso con los demás miembros de la comunidad y sigue nuestro código de conducta. Los detalles del código de conducta están disponibles en el repositorio.


## Licencia

Este proyecto se distribuye bajo la Licencia MIT. Esto significa que puedes utilizar, copiar, modificar, fusionar, publicar, distribuir, sublicenciar, y/o vender copias del software, siempre y cuando incluyas el aviso de derechos de autor y el aviso de permiso en todas las copias o partes sustanciales del software.

## Contacto

Si tienes alguna pregunta, comentario o deseas contribuir al proyecto, no dudes en contactarme. Puedes abrir un issue en este repositorio para preguntas generales o discusiones sobre el proyecto.

- **GitHub:** [rolan1025](https://github.com/rolan1025)
- **Correo Electrónico:** delgadoorlando.25@gmail.com

Agradecemos tu interés en el proyecto y esperamos tus contribuciones y comentarios.

