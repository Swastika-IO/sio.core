# Swastika I/O

### If you have any concern about the brand, you may considering to switch to [Mixcore CMS](https://www.mixcore.org).

![Swastika I/O CMS](https://github.com/mixcore/mix.core/blob/master/assets/mixcore.png?raw=true "What is Swastika I/O CMS?")

# Tutorials
- Demo: http://dev.swastika.io
- Docs: https://docs.swastika.io
- Youtube: https://www.youtube.com/channel/UChqzh6JnC8HBUSQ9AWIcZAw

# GITs clone

```
mkdir siocore
cd siocore

git clone https://github.com/Swastika-IO/sio.heart.git
git clone https://github.com/Swastika-IO/sio.identity.git
git clone https://github.com/Swastika-IO/sio.core.git
```

# Build & Run

```
cd sio.core/src/Sio.Cms.Web

npm install
gulp build
dotnet restore
dotnet bundle
dotnet build
dotnet run
```

> Note: If you facing any System.Data.SqlClient.SqlException error, please replace all content inside "appsettings.json" file with "{}".

# UI:  
  - **Default template:**
![Swastika I/O CMS default template with Now UI Pro](https://github.com/mixcore/mix.core/blob/master/assets/front-end.jpg?raw=true "Swastika I/O CMS default template with Now UI Pro")
  - **Admin Portal:**
![Swastika I/O Admin Portal Bootstrap 4.x](https://github.com/mixcore/mix.core/blob/master/assets/admin-portal.jpg?raw=true "Swastika I/O CMS Admin Portal Bootstrap 4")
