# 💬 WhatsappIntegration.API

API desarrollada con **.NET 8** para la integración con **WhatsApp Cloud API**, permitiendo la comunicación bidireccional entre aplicaciones y usuarios a través de mensajes de texto, imágenes, audio, video, documentos, ubicación y botones interactivos.

---

## 🚀 Características principales

- ✅ **Verificación del Token de Webhook** para validar la conexión con Meta.
- 📥 **Recepción y captura de mensajes** enviados desde WhatsApp.
- 📤 **Envío de mensajes** en formato texto, multimedia y botones interactivos.
- 🧩 **Endpoints RESTful** para interacción con otros servicios.
- 🧱 **Estructura modular** basada en buenas prácticas de arquitectura limpia.
- 🌐 **Preparada para despliegue** en entornos locales o en la nube (Azure, Render, etc.).

---

## 🧰 Tecnologías utilizadas

- **.NET 8 / ASP.NET Core Web API**  
- **C#**  
- **WhatsApp Cloud API (Meta)**  
- **JSON Webhooks**  
- **RESTful API**  
- **Visual Studio**

---

## 📂 Estructura del proyecto

La solución está organizada siguiendo principios de **Clean Architecture**, separando responsabilidades en capas bien definidas:

```text
WhatsappIntegration/
├── API/
│   └── WhatsappIntegration.Api
│       ├── Controllers/
│       │   └── WhatsappController.cs          # Webhook (GET/POST) y puntos de entrada HTTP
│       ├── Models/
│       │   └── Meta/
│       │       └── WhatsAppCloudModel.cs      # Modelo que representa el payload de Meta
│       ├── appsettings.json                   # Configuración de la API
│       └── Program.cs                         # Bootstrapping e inyección de dependencias
│
├── Common/
│   └── WhatsappIntegration.Common             # Utilidades y componentes compartidos
│
├── Core/
│   ├── WhatsappIntegration.Application        # Lógica de aplicación (qué hacer con cada mensaje)
│   │   ├── Configuration/
│   │   │   └── Whatsapp/WhatsAppSettings.cs   # Configuración tipada para WhatsApp Cloud API
│   │   ├── Contracts/
│   │   │   └── WhatsappCloud/SendMessage/
│   │   │       └── IWhatsappCloudSendMessage.cs
│   │   └── Service/
│   │       └── WhatsAppMessageHandler.cs      # Orquestador de mensajes entrantes
│   │       └── WhatsAppMessageBuilder.cs      # Construcción de respuestas (texto, imagen, video, etc.)
│   │
│   └── WhatsappIntegration.Domain             # Contratos y modelos de dominio
│       └── (entidades, enums e interfaces de negocio)
│
└── Infrastructure/
    └── WhatsappIntegration.External
        └── WhatsappCloud/
            └── SendMessage/
                └── WhatsappCloudSendMessage.cs  # Cliente HttpClient para enviar mensajes a Meta
```

Esta estructura permite escalar la solución, probar la lógica de negocio de forma aislada y reutilizar la integración de WhatsApp en distintos escenarios de negocio.

---

## 🔌 Endpoints principales

| Método | Ruta | Descripción |
|--------|------|--------------|
| `GET` | `/api/whatsapp` | Verificación del token de WhatsApp Cloud API (webhook) |
| `POST` | `/api/whatsapp` | Recepción de mensajes entrantes desde Meta (webhook) |

> El envío de mensajes hacia WhatsApp se realiza internamente desde la capa **Application**, utilizando el cliente HTTP tipado definido en la capa **Infrastructure**.

---

## 🧠 Ejemplo de envío de mensaje

A continuación se muestra un ejemplo del **payload JSON** que la API construye y envía a **WhatsApp Cloud API** para enviar un mensaje de texto simple a un usuario:

```json
{
  "messaging_product": "whatsapp",
  "to": "50584376543",
  "type": "text",
  "text": {
    "body": "¡Hola! Este mensaje fue enviado desde la integración .NET con WhatsApp Cloud API 🚀"
  }
}
```

La construcción de este objeto se realiza en la clase `WhatsAppMessageBuilder` dentro de la capa **Application**, y su envío se ejecuta a través de `WhatsappCloudSendMessage` en la capa **Infrastructure**, usando `HttpClient` y configuración tipada (`WhatsAppSettings`).

---

## 🤝 Contribuciones

¡Las contribuciones son bienvenidas!  
Si deseas colaborar, abre un **pull request** o crea un **issue** con tus sugerencias.

---

## 🧾 Licencia

Este proyecto se distribuye bajo la licencia **MIT**.  
Consulta el archivo `LICENSE` para más detalles.

---

📧 **Desarrollado por:** [Angel Bustamante](https://github.com/IgnacioBG17)  
💡 *Proyecto personal de integración con WhatsApp Cloud API.*
