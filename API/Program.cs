using BLL.Interfaces;
using BLL.Mappers;
using BLL.Services;
using DAL.Context;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 🔹 Register Swagger service

            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Secret"]))
                    };
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Medical Warehouse API",
                    Version = "v1",
                    Description = "API documentation for the Medical Warehouse System",
                    Contact = new OpenApiContact
                    {
                        Name = "Support",
                        Email = "support@example.com",
                        Url = new Uri("https://example.com")
                    }
                });

                // 🔹 Enable JWT Authentication in Swagger UI (Optional)
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer <TOKEN>'",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            // 🔹 Register Authorization Policies
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
                options.AddPolicy("SupplierPolicy", policy => policy.RequireRole("Supplier"));
                options.AddPolicy("StaffPolicy", policy => policy.RequireRole("Staff"));
                options.AddPolicy("CustomerPolicy", policy => policy.RequireRole("Customer"));
                options.AddPolicy("DeliveryUnitPolicy", policy => policy.RequireRole("DeliveryUnit"));
            });




            builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            //Repository Dependency Injection
            builder.Services.AddScoped<IItemCategoryRepository, ItemCategoryRepository>();
            builder.Services.AddScoped<IItemRepository, ItemRepository>();
            builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<ISubmissionRepository, SubmissionRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ILotRequestRepository, LotRequestRepository>();

            //Service Dependency Injection
            builder.Services.AddScoped<IItemCategoryService, ItemCategoryService>();
            builder.Services.AddScoped<IItemService, ItemService>();
            builder.Services.AddScoped<ILotRequestService, LotRequestService>();
            builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<ISubmissionService, SubmissionService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IEmailService, EmailService>();

            // Calendar picker for query that accepts datetime
            builder.Services.AddSwaggerGen(c =>
            {
                c.MapType<DateTime>(() => new Microsoft.OpenApi.Models.OpenApiSchema
                {
                    Type = "string",
                    Format = "date", // Use "date" so the calendar picker appears
                    Example = new Microsoft.OpenApi.Any.OpenApiString("12-02-2000")
                });
            });

            var connectionString = (builder.Configuration.GetConnectionString("DefaultConnection"));
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly("DAL")));

            // 🔹 Add services to the container
            builder.Services.AddControllers();

            var app = builder.Build();

            // 🔹 Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Medical Warehouse API v1");
                    options.RoutePrefix = "swagger"; // Set Swagger UI at root (http://localhost:<port>/)
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();

        }
    }
}
