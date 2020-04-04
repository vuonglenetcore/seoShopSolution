# ASP.NET Core 3.1 project from TEDU
## Technologies
- ASP.NET Core 3.1
- Entity Framework Core 3.1

##################
##Bài 3. Tạo solution
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