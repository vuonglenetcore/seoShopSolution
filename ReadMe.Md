# ASP.NET Core 3.1 project from TEDU
## Technologies
- ASP.NET Core 3.1
- Entity Framework Core 3.1

##################
##Bài 1. Tạo solution
1. tạo solution trống
 - seoShopSolution.BackendApi
 - seoShopSolution.WebApp
 - seoShopSolution.Application  -- viết các service
 - seoShopSolution.Utilities   -- tiện ích
 - seoShopSolution.ViewModel
 - seoShopSolution.Data         -- kết nối database, migration

 2. tắt mở lại studio add source controll vào git
 - master là nhánh chính
 - tạo nhánh develope
 - tạo các nhánh feture/xxx xữ lý các task

## Bài 4 tạo các class entities định nghĩa bảng
1. install trong data
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Design

2. seoShopSolution.Data > entities > tạo class entties model (* các tham chiếu bảng, list bảng phù hợp khóa ngoại)

3. configuration entities (* có thể config trong model entites luôn)

4. Tao class seoShopSolutionDbContext trong EF
-   public coreShopDbContext(DbContextOptions options) : base(options)
    {
    }

- protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            ...
       }

-   public DbSet<Product> products { set; get; }
    public DbSet<Category> Categories { get; set; }
    ...
5. Tạo class coreShopDbContextFactory : IDesignTimeDbContextFactory<coreShopDbContext> trong EF
     public coreShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("coreShopSolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<coreShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new coreShopDbContext(optionsBuilder.Options);
        }

    - tao file appsettings.json
    {
      "ConnectionStrings": {
        "coreShopSolutionDb": "Server=DESKTOP-K9E5QJ9\\SQLEXPRESS;Database=coreShopSolution;Trusted_Connection=True;"
      }
    }

    - Microsoft.Extensions.Configuration.FileExtensions sử dụng cho S
    - Microsoft.Extensions.Configuration.Json sử dụng cho AddJsonFile
6. migration database:
- add-migration database
- update-database

##Bài 2. viết các phương thức service trong application
1. Viết các interface 
2. các class viewModel dùng cho get, create, update...
3. imlement interface triển khai các nghiệp vụ service 
- DI DbContext trong class service

----note------------------SERVICE ghi file
    copy theo : interface và class này:  FileStorageService : IStorageService
    * phương thức webHostEnvironment.WebRootPath
    cần khai báo: 
                Microsoft.AspNetCore.Hosting
                Microsoft.AspNetCore.Hosting.Abstractions
                Microsoft.Extensions.Hosting
    Nhấp dúp vào seoShopSolution.Application mở file seoShopSolution.Application.scproj
    clear hết nội dung trong <ItemGroup> dâu tiên. thay lại như sau:
    <ItemGroup>
        <PackageReference Include="Microsoft.AspNetCore.App" />
    </ItemGroup>    
    
    trong wwwroot của backend api phải tạo thư mục user-content để chưa file
---note----------------------------------

##Bài 3. Viết controller api cho backendApi
1. tao ex: productApi empty 
2. copy chuổi connecstring vào appsettings.Development.json
        "ConnectionStrings": {
            "seoShopSolutionDb": "Server=DESKTOP-K9E5QJ9\\SQLEXPRESS;Database=SEOSHOP;Trusted_Connection=True;"
          }
3. cấu hình startUp.cs
+ tìm   public void ConfigureServices(IServiceCollection services){
    //connect db
    ...
}
+ cấu hình connect db 
     //tao ket noi db
            services.AddDbContext<coreShopDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString(SystemContants.MainConnectionString)));
+ DI service
        services.AddTransient<IPublicProductService, PublicProductService>();
        services.AddTransient<IManageProductService, ManageProductService>();
4. Viết phương thức trong controller api
    
##Bài 4 cài đặt AddSwagger hiển thị giao diện api
1. install Swashbuckle.AspNet
2. cấu hình trong startUp
- hướng dẫn:  https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio
- services.AddSwaggerGen(...)
- app.UseSwagger();
- app.UseSwaggerUI(...)
3. Chỉ định "launchUrl": "swagger", trong Properties > launchSetting.json
## Bài 5 api quản lý file ảnh
1. viết các method servie quản lý ảnh, create, getlistimg, update, remove...
2. viết api quản lý image

##Bài 6 thêm identity - api login, register
1. Tạo bảng AppUser, AppRole
- install Microsoft.AspNetCore.Identity
- Thêm model entity AppUser, AppRole
    public class AppUser : IdentityUser<Guid>
    {
        ...
        thêm các thuộc tính tự định nghĩa
        các khóa ngoại đến bảng có liên quan đến user
    }
    
    public class AppRole : IdentityRole<Guid>
    {
        ...
        thêm các thuộc tính tự định nghĩa
        các khóa ngoại đến bảng có liên quan đến user
    }
- Configuration cho 2 bảng trên

2. class DbContext kế thừa lại từ identity
- public class coreShopDbContext :  IdentityDbContext<AppUser, AppRole, Guid>

3. Cấu hình thuộc tính configuration cho 5 bảng mặc định trong identity ở class dbcontext dể 
renradatabase(có thể tách ra như class khác)
- 5 bảng sau
    //config identity table
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            
4. Add-migration update-database cho 2 bảng user và role

5. Tạo UserService api . tạo trong thư mục System > Users dể quản lý
- 2 phương thức service copy paste > install token

6. qua benendApi add tokens vào appsetting.json
        "Tokens": {
            "Key": "0123456789ABCDEF",
            "Issuer": "https://webapi.vuongle.com.vn"
          }
7. Cấu hình StartUp
- trong void ConfigureServices khai báo identity
services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<coreShopDbContext>().AddDefaultTokenProviders();
-DI Service 
            services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
            services.AddTransient<IUserService, UserService>();


8. UserController api
- 2 phuong thuc login và register

-> Kết thúc bài, dk thành công. đăng nhập trả về dc mã token

