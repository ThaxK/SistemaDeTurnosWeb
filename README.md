# ✂️ Barbería Turnos — Sistema de Gestión de Turnos

![Build status](https://github.com/ThaxK/SistemaDeTurnosWeb/actions/workflows/feature-a%C3%B1adir-proyecto-base_sistemadeturnosweb.yml/badge.svg)

API REST + UI Web para gestionar turnos de una barbería o peluquería.  
Construida con **.NET 9** y almacenamiento **en memoria**. Desplegada en **Azure Web Apps** con CI/CD via GitHub Actions.

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
| `/Turnos` | Listado, creación, cancelación y realización de turnos |
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
- **Azure Web Apps** — hosting en la nube
- **GitHub Actions** — CI/CD automatizado

---

## 🤖 CI/CD

El proyecto tiene un pipeline de **GitHub Actions** que:

1. **Build** — `dotnet build --configuration Release`
2. **Publish** — `dotnet publish -c Release`
3. **Deploy** — a **Azure Web App** (`SistemaDeTurnosWeb`)

El workflow se ejecuta automáticamente al pushear a la branch `feature/añadir-proyecto-base`.

Workflow: [`.github/workflows/feature-añadir-proyecto-base_sistemadeturnosweb.yml`](.github/workflows/feature-a%C3%B1adir-proyecto-base_sistemadeturnosweb.yml)

---

## 🗂️ Estructura

```
SistemaDeTurnosWeb/
├── .github/workflows/ → CI/CD pipeline (GitHub Actions)
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

- [x] Pipeline CI/CD (GitHub Actions → Azure Web Apps)
- [ ] Test project con xUnit
- [ ] Frontend en React / Blazor
- [ ] Persistencia con base de datos

---

Hecho con ❤️ para aprender y practicar CI/CD.
