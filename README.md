# ADAS Simulation Platform


```
      ___          _____          ___           ___     
     /  /\        /  /::\        /  /\         /  /\    
    /  /::\      /  /:/\:\      /  /::\       /  /:/_   
   /  /:/\:\    /  /:/  \:\    /  /:/\:\     /  /:/ /\  
  /  /:/~/::\  /__/:/ \__\:|  /  /:/~/::\   /  /:/ /::\ 
 /__/:/ /:/\:\ \  \:\ /  /:/ /__/:/ /:/\:\ /__/:/ /:/\:\
 \  \:\/:/__\/  \  \:\  /:/  \  \:\/:/__\/ \  \:\/:/~/:/
  \  \::/        \  \:\/:/    \  \::/       \  \::/ /:/ 
   \  \:\         \  \::/      \  \:\        \__\/ /:/  
    \  \:\         \__\/        \  \:\         /__/:/   
     \__\/                       \__\/         \__\/    
```

Este repositorio contiene el programa desarrollado en Unity para la plataforma de simulación de Sistemas Avanzados de Asistencia al Conductor (ADAS). Este proyecto es una colaboración entre el Tecnológico de Monterrey Campus Guadalajara y Bosch.

## Tabla de Contenidos

- [Descripción del Proyecto](#descripción-del-proyecto)
- [Estado actual](#características)
- [Requisitos](#requisitos)
- [Instalación](#instalación)
- [Uso](#uso)
- [Contribuciones](#contribuciones)
- [Licencia](#licencia)
- [Autores](#autores)
- [Agradecimientos](#agradecimientos)

## Descripción del Proyecto

Este proyecto tiene como objetivo desarrollar una plataforma de simulación para probar y validar algoritmos de ADAS, incluyendo detección de puntos ciegos y prevención de colisiones.

## Estado actual

- Simulación de diferentes escenarios de conducción implementada.
- Integración de un solo modelo de vehículo.
- Comunicación con periféricos de Logitech.
- Sensor radar LIDAR simulado.
- Cluster de instrumentos implementado.
- Dos algoritmos desarrollados: precolisión y punto ciego.
- Visualización en tiempo real funcionando.

## Requisitos

### Software

- Unity 2020.3 o superior.
- Sistema operativo Windows.
- [Logitech G Hub](https://www.logitechg.com/es-mx/innovation/g-hub.html).

### Hardware

- Procesador: Intel Core i3 10th Gen o AMD equivalente.
- Memoria RAM: 8 GB o más.
- Almacenamiento: 10 GB de espacio disponible.
- Graficos integrados.
- Periféricos: Logitech G920.
- Pantalla con relación de aspecto 16:9 (Recomendado: 1920x1080).

## Instalación

1. Inicia clonando este repositorio para tener acceso a todos los recursos del simulador.
```
> git clone https://github.com/yako2792/adas-project.git
```

2. Abre Unity Hub e importa el proyecto clonado.
3. Abre el proyecto desde Unity Hub.
4. Listo :) 

## Framework

Las carpetas y directorios se encuentran organizados de la siguiente manera.

```
driveSim
├── Assets
│   ├── Icons
│   ├── Images
│   ├── Imported
│   ├── Materials
│   ├── Prefabs
│   ├── Scenes
│   └── Scripts
├── Library
├── Logs
├── Packages
├── ProjectSettings
└── UserSettings

```

### Directorios importantes

* **Assets**: Este directorio contiene todos los recursos fundamentales del proyecto.

* **Prefabs**: Aquí se encuentran elementos prefabricados listos para ser arrastrados a las escenas. Algunos prefabs presentes son: Sensor LIDAR, Vehículo Host y Cluster.

* **Scripts**: Contiene todos los scripts utilizados y futuros scripts.

* **Scenes**: Almacena todas las escenas de Unity. Actualmente, solo hay una escena llamada `Level1.unity`. Aquí se deben almacenar todos los "niveles" o escenarios de prueba para validar los algoritmos.



## Licencia

Pendiente

## Autores

- Alejandro Gil Ruiz - [LinkedIn](https://www.linkedin.com/in/alejandro-gil-ruiz-3a8878274/https://github.com/tuusuario)
- Alberto Varela Cárdenas - [LinkedIn](https://www.linkedin.com/in/urielpavelmoraless%C3%A1nchez-365b04227/)
- Uriel Pavel Morales Sánchez - [LinkedIn](https://www.linkedin.com/in/alvarelacar/)

## Agradecimientos

- Tecnológico de Monterrey Campus Guadalajara.
- Bosch.

