# ✂️ Barbería Turnos — Sistema de Gestión de Turnos

API REST + UI Web para gestionar turnos de una barbería o peluquería.  
Construida con **.NET 9** y almacenamiento **en memoria**. Ideal como base para proyectos CI/CD.

---

## 🚀 Cómo correrlo

### Local (sin Docker)

```bash
dotnet run
# Abrí http://localhost:5207
```

### Con Docker

```bash
docker build -t barberia-api .
docker run -d -p 8080:8080 --name barberia barberia-api
# Abrí http://localhost:8080
```

---

## 🧭 Páginas

| Ruta | Descripción |
|------|-------------|
| `/` | Dashboard con resumen de turnos, clientes y servicios |
| `/Servicios` | Listado y creación de servicios |
| `/Clientes` | Listado y registro de clientes |
| `/Turnos` | Listado, creación y cancelación de turnos |
| `/Turnos/Create` | Formulario para nuevo turno |

## 🔌 API REST

| Método | Ruta | Descripción |
|--------|------|-------------|
| `GET` | `/api/servicios` | Listar servicios |
| `POST` | `/api/servicios` | Crear servicio |
| `GET` | `/api/clientes` | Listar clientes |
| `POST` | `/api/clientes` | Registrar cliente |
| `GET` | `/api/turnos` | Listar turnos |
| `GET` | `/api/turnos/{id}` | Obtener turno por ID |
| `POST` | `/api/turnos` | Crear turno |
| `DELETE` | `/api/turnos/{id}` | Cancelar turno |

Ejemplos de requests en [`SistemaDeTurnosWeb.http`](SistemaDeTurnosWeb.http).

---

## 🧠 Stack

- **.NET 9** — ASP.NET Core Web API + Razor Pages
- **Bootstrap 5** + Bootstrap Icons — UI responsive
- **ConcurrentDictionary** — almacenamiento en memoria (thread-safe)
- **Docker** — imagen multi-stage lista para deploy

---

## 🗂️ Estructura

```
SistemaDeTurnosWeb/
├── Controllers/       → API REST endpoints
├── Models/            → Cliente, Servicio, Turno
├── Repositories/      → Almacenamiento en memoria
├── Pages/             → Razor Pages (UI web)
│   ├── Clientes/      → ABM de clientes
│   ├── Servicios/     → ABM de servicios
│   └── Turnos/        → Gestión de turnos
├── Program.cs         → Entry point + DI
└── Dockerfile         → Imagen lista para producción
```

---

## 🚧 Próximos pasos

- [ ] Test project con xUnit
- [ ] Pipeline CI/CD (GitHub Actions / Azure DevOps)
- [ ] Frontend en React / Blazor
- [ ] Persistencia con base de datos

---

Hecho con ❤️ para aprender y practicar CI/CD.
