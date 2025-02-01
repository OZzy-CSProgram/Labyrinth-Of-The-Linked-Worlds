# INFORME DEL PROYECTO: LABYRINTH OF THE LINKED WORLDS

## 1. Requerimentos para que el juego funcione
- Instalar Spectre.Console  
  comando: `dotnet add new package Spectre.Console`
- Instalar System.Threading  
  comando: `dotnet add new package System.Threading`
- Recomendable tener el juego en el escritorio para que cargue bien la ubicación de los audios.
- Instalar NAudio  
  comando: `dotnet add new package System.NAudio`

## 2. Funcionalidad
El objetivo es llevar a tus héroes al medio del mapa para ganar. Cada jugador cuenta con 3 héroes en sus huestes. Cada héroe tiene poderes especiales que requieren que el héroe tenga el maná en su máximo. Se dice que el medio del mapa está encerrado en grandes muros, y la única forma de entrar es por la puerta, por tanto deberás encontrar la llave para entrar. El juego solo admite 2 jugadores.

## 3. Descripción

### I Heroes
El archivo `Heroes.cs` define la clase llamada `Hero`, que representa a un héroe en el juego:

#### Clase Hero
- **Propiedades**
  - Atributos del héroe: Incluye propiedades como `name`, `info`, `id`, `speed`, `maxspeed`, `icon`, `health`, `attack`, `mana`, entre otros.
  - Estado del héroe: Contiene indicadores como `haveKey`, `trapped`, `inbox`, y otros que reflejan el estado actual del héroe en el juego.
  - Ubicación y mapa: Utiliza un arreglo bidimensional (`map`) para representar el entorno del juego y un arreglo unidimensional (`location`) para la posición actual del héroe.
  
- **Constructor**
  - El constructor inicializa las propiedades del héroe con valores proporcionados al crear una instancia de la clase.

- **Métodos**
  - `Movenumber`: Calcula cuántas posiciones puede moverse el héroe en una dirección específica, teniendo en cuenta obstáculos en el mapa.
  - `GetHeroById`: Busca y devuelve un héroe específico basado en su ID dentro de los equipos de dos jugadores.
  - `isHeroInParty`: Verifica si un héroe está en el equipo de un jugador.
  - Métodos de movimiento (`moveright`, `moveleft`, `moveup`, `movedown`): Métodos que permiten al héroe moverse en diferentes direcciones, manejando la lógica de movimiento e interacciones.

- **Interacciones**
  Los métodos de movimiento incluyen lógica para manejar situaciones como:
  - Encuentros con trampas o cajas.
  - Interacción con otros héroes (incluyendo la posibilidad de mover a otro héroe).
  - Uso de llaves para abrir puertas.
  - Registro de movimientos en un historial (`locationlog`).

### II Maze
El archivo `Maze.cs` define una clase llamada `Maze`, que representa el laberinto en el juego:

#### Clase Maze
- **Propiedades**
  - Tamaño del laberinto: La propiedad estática `size` define el tamaño del laberinto (43x43).
  - Elementos del laberinto: Incluye trampas (`Trap`), caminos libres (`Path`), obstáculos (`obstacle`), y la ubicación de llaves (`KeyLocation`).
  - Estado del mapa: La propiedad `KeyOnMap` indica si la llave está presente en el mapa.
  
- **Métodos principales**
  - Generación del laberinto:
    - El método `Generator()` crea un laberinto utilizando el algoritmo de Aldous-Broder.
    - Marca celdas como visitadas y genera caminos aleatorios entre ellas, añadiendo elementos como paredes, trampas, puertas, y un artefacto en el centro del laberinto.
    
  - Obtención de caminos:
    - `GetPathes(int[,] maze)`: Identifica y almacena las coordenadas de los caminos libres en el laberinto.
    - `GetRandomPath(List list)`: Selecciona aleatoriamente un camino libre.

  - Impresión del laberinto:
    - `PrintMaze(int[,] maze, string a)`: Genera una representación visual del laberinto en formato de tabla con colores y símbolos para cada elemento (paredes, trampas, llaves, etc.).
    - `PrintMaze2(int[,] maze, string a, Table downrighttable, Hero hero)`: Similar al anterior, pero con una tabla más detallada.

  - Interacción con elementos:
    Métodos para generar ubicaciones específicas para puertas o llaves y para definir áreas alrededor de elementos clave.

### III Player
El archivo `Player.cs` define la clase Player, que gestiona la lógica y el estado de un jugador en el juego:

#### Clase Player
- **Propiedades**
  - Estado del juego: Contiene propiedades estáticas como `inmainmenu`, `play`, y `exit`.
  - Estado del jugador: Incluye propiedades como `turn`, `haveKey`, `Victory`, y `HeroesInCentre`.
  - Lista de héroes: La propiedad Party almacena los héroes seleccionados por el jugador.
  - Nombre del jugador: La propiedad name almacena el nombre del jugador.

- **Métodos principales**
  - Gestión de nombres:
    - `intname(string name, Player p)`: Permite al jugador ingresar un nombre, asegurándose de que no esté vacío.
    
  - Interacción con héroes:
    - `GetPlayerChoice(List list)`: Permite al jugador seleccionar un héroe de una lista.

- **Acciones en el juego:**
  - Validación de acciones y gestión de turnos entre jugadores.

### IV Traps
El archivo `Traps.cs` define la clase Trap en el juego:

#### Clase Trap
- **Funcionalidad principal:** Esta clase sirve como base para diferentes tipos de trampas en el juego.

- **Métodos:**
  - `CastTrap(Hero hero, int[,] map)`: Método virtual implementado en subclases para definir efectos específicos.
  - Generación de trampas en un mapa.

### V Boxes
El archivo `Boxes.cs` define un sistema de cajas sorpresa en el juego:

#### Clase Base: Box
Representa una caja genérica en el juego.

- Métodos para colocar cajas y definir interacciones con los héroes.

### VI GameMenu
El archivo GameMenu.cs implementa un sistema de menú para el juego utilizando Spectre.Console:

#### Clase Menu
Gestiona la presentación e interacción del menú del juego.

- Métodos principales incluyen visualización de tablas, gestión de sonidos y selección de héroes.

## Program
Aquí ocurre toda la funcionalidad del juego. Se crean instancias y se llaman a los métodos; también se muestran todos los mensajes y tablas hechas con Spectre, además de las animaciones.
