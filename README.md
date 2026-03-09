# Web Agri Supply Chain

Hệ thống quản lý chuỗi cung ứng nông sản với kiến trúc Microservices

## Kiến trúc hệ thống

```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   React App     │    │   API Gateway   │    │  Microservices  │
│   (Frontend)    │◄──►│    (Ocelot)     │◄──►│                 │
└─────────────────┘    └─────────────────┘    │ • AuthService   │
                                              │ • NongDanService│
                                              │ • DaiLyService  │
                                              │ • SieuThiService│
                                              │ • AdminService  │
                                              └─────────────────┘
```

## Công nghệ sử dụng

### Backend
- **.NET 8.0** - Framework chính
- **ASP.NET Core Web API** - RESTful APIs
- **Ocelot** - API Gateway
- **Microsoft.Data.SqlClient** - Database connectivity (ADO.NET)
- **JWT Authentication** - Xác thực và phân quyền
- **SQL Server** - Database

### Frontend
- **React** - UI Framework 

## Cấu trúc dự án

```
CNWeb_Agri_Supply_Chain/
├── AuthService/          # Xác thực và JWT
├── NongDanService/       # Quản lý nông dân
├── DaiLyService/         # Quản lý đại lý
├── SieuThiService/       # Quản lý siêu thị
├── AdminService/         # Quản lý admin
├── Gateway/              # API Gateway (Ocelot)
└── GiaoDien/            # Frontend (React)
```

## Microservices

<<<<<<< HEAD
### 1. AuthService (Port: 5001)
=======
### 1. AuthService
>>>>>>> fae431a834389dc8a291d7a906077672b7f0ee39
- Đăng nhập/Đăng ký
- Tạo và xác thực JWT Token
- Quản lý phiên đăng nhập

<<<<<<< HEAD
### 2. NongDanService (Port: 5002)
=======
### 2. NongDanService
>>>>>>> fae431a834389dc8a291d7a906077672b7f0ee39
- CRUD Nông dân
- Quản lý sản phẩm nông sản
- Quản lý đơn hàng bán cho đại lý

<<<<<<< HEAD
### 3. DaiLyService (Port: 5003)
=======
### 3. DaiLyService 
>>>>>>> fae431a834389dc8a291d7a906077672b7f0ee39
- CRUD Đại lý
- Quản lý kho hàng
- Quản lý đơn hàng từ nông dân
- Quản lý đơn hàng bán cho siêu thị
- Kiểm định chất lượng

<<<<<<< HEAD
### 4. SieuThiService (Port: 5004)
=======
### 4. SieuThiService
>>>>>>> fae431a834389dc8a291d7a906077672b7f0ee39
- CRUD Siêu thị
- Quản lý đơn hàng từ đại lý
- Quản lý bán hàng cho khách

<<<<<<< HEAD
### 5. AdminService (Port: 5005)
=======
### 5. AdminService
>>>>>>> fae431a834389dc8a291d7a906077672b7f0ee39
- Quản lý toàn bộ hệ thống
- Báo cáo thống kê
- Quản lý người dùng

<<<<<<< HEAD
### 6. Gateway (Port: 5000)
=======
### 6. Gateway 
>>>>>>> fae431a834389dc8a291d7a906077672b7f0ee39
- Định tuyến requests
- Load balancing
- Authentication middleware
- CORS handling

## Cài đặt và chạy
<<<<<<< HEAD

### Yêu cầu
- .NET 8.0 SDK
- SQL Server
- Visual Studio 2022 hoặc VS Code

### Cài đặt
```bash
# Clone repository
git clone https://github.com/Thuanzz05/Web_Agri_Supply_Chain.git
cd CNWeb_Agri_Supply_Chain

# Restore packages
dotnet restore

# Build solution
dotnet build
```

=======
>>>>>>> fae431a834389dc8a291d7a906077672b7f0ee39
### Chạy từng service
```bash
# Chạy Gateway
dotnet run --project Gateway

# Chạy AuthService
dotnet run --project AuthService

# Chạy các service khác...
dotnet run --project NongDanService
dotnet run --project DaiLyService
dotnet run --project SieuThiService
dotnet run --project AdminService
```

## Database

Sử dụng SQL Server với ADO.NET (không Entity Framework)
- Connection string trong `appsettings.Development.json`
- Stored Procedures cho các operations
- Synchronous operations (không async/await)

## API Documentation

Mỗi service sẽ có Swagger UI tại:
<<<<<<< HEAD
- AuthService: `https://localhost:5001/swagger`
- NongDanService: `https://localhost:5002/swagger`
- DaiLyService: `https://localhost:5003/swagger`
- SieuThiService: `https://localhost:5004/swagger`
- AdminService: `https://localhost:5005/swagger`
=======
- AuthService: `https://localhost:xxxx/swagger`
- NongDanService: `https://localhost:xxxx/swagger`
- DaiLyService: `https://localhost:xxxx/swagger`
- SieuThiService: `https://localhost:xxxx/swagger`
- AdminService: `https://localhost:xxxx/swagger`
>>>>>>> fae431a834389dc8a291d7a906077672b7f0ee39

