# 🩸 BloodConnect.pk — Frontend

### Blood Management & Emergency Response Platform

**BloodConnect.pk** is a modern web-based blood management and emergency response platform designed to connect **blood centers, hospitals, and volunteer donors across Pakistan**.

This repository contains the **frontend application** of BloodConnect.pk, built with **Blazor Server and .NET 9**. The application provides dedicated experiences for administrators, registered blood centers, and public users through a modular and responsive web interface.

---

## ✨ Features

### 🔐 Authentication

* User login and authentication
* Role-based access
* Secure authentication flow
* Dedicated authentication pages
* Protected portal routes

### 👨‍💼 Admin Portal

The Admin Portal provides centralized management and monitoring of the BloodConnect.pk platform.

* 📊 Admin Dashboard
* 👥 User Management
* 🏥 Blood Center Management
* 🩸 Blood Inventory Monitoring
* 🚨 Emergency Request Management
* 📋 Dispatch & Activity Monitoring
* ⚙️ System Administration

### 🏥 Center Portal

The Center Portal provides blood centers with dedicated tools to manage their daily operations.

* 📊 Center Dashboard
* 🩸 Blood Inventory Management
* 🚨 Emergency Blood Requests
* 📋 Blood Dispatch Management
* 👥 Donor Management
* 📈 Center Statistics
* ⚙️ Center Settings

### 🌐 Public Portal

The Public Portal provides blood-related information and services to general users and donors.

* 🏠 Landing Page
* 🩸 Blood Availability
* 👥 Donor Information
* 🚨 Emergency Blood Requests
* 📖 About BloodConnect.pk
* 📞 Contact & Support

### 🎨 Responsive UI

* Modern dashboard interfaces
* Responsive layouts
* Reusable Blazor components
* Dedicated layouts for different portals
* Consistent navigation experience
* Modular page structure

---

# 🏗️ Frontend Architecture

The frontend is structured around **separate application portals**, reusable Blazor components, layouts, and navigation elements.

```text
BCP_Frontend/
│
├── Components/
│   │
│   ├── Layout/
│   │   ├── AdminLayout.razor
│   │   ├── CenterLayout.razor
│   │   ├── EmptyLayout.razor
│   │   └── MainLayout.razor
│   │
│   └── Navbars/
│       ├── AdminSidebar.razor
│       ├── CenterSidebar.razor
│       ├── PublicFooter.razor
│       └── PublicNavbar.razor
│
├── Pages/
│   │
│   ├── Admin-Portal/
│   │   └── Admin Pages
│   │
│   ├── Auth-Pages/
│   │   └── Authentication Pages
│   │
│   ├── Center-Portal/
│   │   └── Blood Center Pages
│   │
│   └── Public-Portal/
│       └── Public Pages
│
├── wwwroot/
│   ├── css/
│   ├── js/
│   ├── images/
│   └── other static assets
│
├── App.razor
├── Routes.razor
├── _Imports.razor
├── Program.cs
└── appsettings.json
```

---

# 🎯 Portal Architecture

```text
                         BloodConnect.pk
                               │
              ┌────────────────┼────────────────┐
              │                │                │
              ▼                ▼                ▼
        Admin Portal     Center Portal     Public Portal
              │                │                │
              ▼                ▼                ▼
       Administration      Operations      Public Access
```

Each portal has its own **layout, navigation, and page structure**, while common functionality is implemented through reusable Blazor components.

---

# 🧩 Component Structure

## 👨‍💼 Admin Portal

```text
AdminLayout
     │
     └── AdminSidebar
            │
            ├── Dashboard
            ├── Management
            ├── Requests
            ├── Inventory
            └── Settings
```

## 🏥 Center Portal

```text
CenterLayout
     │
     └── CenterSidebar
            │
            ├── Dashboard
            ├── Inventory
            ├── Emergency Requests
            ├── Donors
            ├── Dispatch
            └── Settings
```

## 🌐 Public Portal

```text
MainLayout
     │
     ├── PublicNavbar
     │
     ├── Public Pages
     │
     └── PublicFooter
```
# 🛠️ Technology Stack

| Technology           | Usage                                     |
| -------------------- | ----------------------------------------- |
| **Blazor Server**    | Frontend UI & Interactive Web Application |
| **.NET 9**           | Application Framework                     |
| **C#**               | Application Development                   |
| **Razor Components** | UI Components & Pages                     |
| **Tailwind CSS**     | Primary UI Styling & Responsive Design    |
| **HTML5**            | Page Structure                            |
| **JavaScript**       | Client-side functionality                 |
| **REST API**         | Backend Communication                     |

### 🎨 UI & Styling

The frontend primarily uses **Tailwind CSS** to build a modern, responsive, and consistent user interface.

* Utility-first CSS approach
* Responsive layouts
* Reusable styling patterns
* Modern dashboard interfaces
* Responsive navigation and sidebars
* Consistent spacing, typography, and UI components
* Mobile, tablet, and desktop support

---

# 🔗 Backend Integration

The BloodConnect.pk frontend and backend are maintained as **separate solutions**.

```text
┌─────────────────────────────┐
│       BCP Frontend          │
│                             │
│   Blazor Server + .NET 9    │
└──────────────┬──────────────┘
               │
               │ HTTP / REST API
               ▼
┌─────────────────────────────┐
│        BCP Backend          │
│                             │
│    ASP.NET Core Web API     │
└──────────────┬──────────────┘
               │
               │
               ▼
┌─────────────────────────────┐
│          Database           │
│                             │
│          SQL Server         │
└─────────────────────────────┘
```

### Frontend Responsibilities

The frontend is responsible for:

* User interface
* Navigation
* Form handling
* Client-side interactions
* API communication
* Displaying backend data
* Portal-specific workflows
* Responsive user experience

### Backend Responsibilities

The backend is responsible for:

* Business logic
* Authentication & authorization
* Database operations
* API endpoints
* Data processing
* Validation
* Persistence

---

# 🚀 Getting Started

## Prerequisites

Before running the project, make sure you have:

* **.NET 9 SDK**
* **Visual Studio 2022** or later
* **Git**
* Running **BloodConnect.pk Backend API**

---

## 📥 Clone Repository

```bash
git clone https://github.com/YourUsername/BCP_Frontend.git
cd BCP_Frontend
```

---

## 📦 Restore Dependencies

```bash
dotnet restore
```

---

## ⚙️ Configure API

Configure the backend API URL according to your environment.

For example, in `appsettings.json`:

```json
{
  "ApiSettings": {
    "BaseUrl": "https://localhost:7001/api/"
  }
}
```

> Update the API URL according to your local or deployed backend environment.

---

## ▶️ Run the Application

Using the .NET CLI:

```bash
dotnet run
```

Or open the solution in **Visual Studio** and run the application using the configured launch profile.

---

# 📁 Main Application Areas

| Area                   | Description                                      |
| ---------------------- | ------------------------------------------------ |
| 🔐 **Auth-Pages**      | Login and authentication-related pages           |
| 👨‍💼 **Admin-Portal** | Platform administration                          |
| 🏥 **Center-Portal**   | Blood center operations                          |
| 🌐 **Public-Portal**   | Public-facing website                            |
| 🧩 **Components**      | Reusable layouts and navigation components       |
| 🌍 **wwwroot**         | CSS, JavaScript, images, and other static assets |

---

# 🗺️ Roadmap

* [x] Establish frontend architecture
* [x] Implement portal-based navigation
* [ ] Complete Admin Portal
* [ ] Complete Center Portal
* [ ] Complete Public Portal
* [ ] Integrate all backend APIs
* [ ] Add real-time emergency notifications
* [ ] Improve responsive design
* [ ] Add advanced dashboard analytics
* [ ] Optimize frontend performance

---

# 🤝 Contributing

Contributions and suggestions are welcome.

1. Create a feature branch
2. Implement your changes
3. Test the application
4. Commit your changes
5. Push the branch
6. Create a Pull Request

---

# 🩸 BloodConnect.pk

### Connecting Blood. Connecting People. Saving Lives.

**BCP Frontend**

🇵🇰 **Built for Pakistan**

---
