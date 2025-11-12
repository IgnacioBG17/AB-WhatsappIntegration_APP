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

\`\`\`
WhatsappIntegration.API/
├── Controllers/
│   ├── WebhookController.cs
│   ├── MessageController.cs
│
├── Services/
│   ├── WhatsappService.cs
│
├── Models/
│   ├── MessageRequest.cs
│   ├── MessageResponse.cs
│
├── appsettings.json
├── Program.cs
└── README.md
\`\`\`

---

## 🔌 Endpoints principales

| Método | Ruta | Descripción |
|--------|------|--------------|
| \`GET\` | \`/api/webhook\` | Verificación del token de WhatsApp Cloud API |
| \`POST\` | \`/api/webhook\` | Recepción de mensajes entrantes |
| \`POST\` | \`/api/messages/send\` | Envío de mensajes (texto, multimedia, botones) |

---

## 🧠 Ejemplo de envío de mensaje

\`\`\`http
POST /api/messages/send
Content-Type: application/json

{
  "to": "51999999999",
  "type": "text",
  "text": {
    "body": "¡Hola! Este mensaje fue enviado desde la API 🚀"
  }
}
\`\`\`

---

## 🤝 Contribuciones

¡Las contribuciones son bienvenidas!  
Si deseas colaborar, abre un **pull request** o crea un **issue** con tus sugerencias.

---

## 🧾 Licencia

Este proyecto se distribuye bajo la licencia **MIT**.  
Consulta el archivo \`LICENSE\` para más detalles.

---

📧 **Desarrollado por:** [Angel Bustamante](https://github.com/IgnacioBG17)  
💡 *Proyecto personal de integración con WhatsApp Cloud API.*
