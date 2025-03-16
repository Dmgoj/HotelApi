# 🏨 Hotel API  (wip)
*A RESTful API for managing hotels, rooms, and reservations.*

---

## 📌 About  
The **Hotel API** allows users to:  
- ✅ Manage hotels and rooms  
- ✅ Make and manage reservations  
- ✅ Check room availability  
- ✅ Implement pagination and filtering  

Built using **ASP.NET Core**, **Entity Framework Core**, and **PostgreSQL**.  

---

## 🚀 Features  
- 🏨 **Hotel Management** – Add, update, and delete hotels  
- 🛏️ **Room Management** – Create, update, and list rooms per hotel  
- 📅 **Reservation System** – Book, update, and cancel room reservations  
- 🔍 **Pagination & Filtering** – Retrieve data efficiently  

---

## 🛠 Tech Stack  
- **Backend**: ASP.NET Core, C#  
- **Database**: PostgreSQL, EF Core  

---

## 📦 Installation  

### 1️⃣ Clone the Repository
```sh
git clone https://github.com/Dmgoj/HotelApi.git
cd HotelApi
```

### 2️⃣ Configure Database  
Update `appsettings.json` with your PostgreSQL connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=HotelDb;Username=youruser;Password=yourpassword"
}
```
Run migrations:  
```sh
dotnet ef database update
```

### 3️⃣ Run the Application
```sh
dotnet run
```
API will be available at:  
📍 `http://localhost:5184`  

---

## 🏨 API Endpoints  

### 🏢 Hotels
| Method | Endpoint                 | Description         |
|--------|--------------------------|---------------------|
| GET    | `/api/Hotels`            | Get all hotels      |
| POST   | `/api/Hotels`            | Add a new hotel     |
| GET    | `/api/Hotels/{id}`       | Get hotel by ID     |

### 🏠 Rooms
| Method | Endpoint                            | Description            |
|--------|-------------------------------------|------------------------|
| GET    | `/api/Hotels/{hotelId}/Rooms`       | Get rooms in a hotel   |
| POST   | `/api/Hotels/{hotelId}/Rooms`       | Add a room to a hotel  |
| GET    | `/api/Hotels/{hotelId}/Rooms{id}`   | Get room by ID         |

### 🏷️ Reservations (in progress)
| Method | Endpoint                                  | Description            |
|--------|-------------------------------------------|------------------------|
| POST   | `/api/Reservations`                       | Create a reservation   |
| GET    | `/api/Reservations/{id}`                  | Get reservation by ID  |
| DELETE | `/api/Reservations/{id}`                  | Cancel reservation     |
