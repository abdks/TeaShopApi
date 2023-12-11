using TeaShopApiBusinessLayer.Abstract;
using TeaShopApiBusinessLayer.Concrete;
using TeaShopApiDataAccessLayer.Abstract;
using TeaShopApiDataAccessLayer.Context;
using TeaShopApiDataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped<IDrinkDal, EfDrinkDal>();
//builder.Services.AddScoped<ýdri,DrinkManager>();

builder.Services.AddScoped<IQuestionDal, EfQuestionDal>();
builder.Services.AddScoped<IQuestionService, QuestionManager>();



builder.Services.AddScoped<ITestimonialDal, EfTestimonial>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

builder.Services.AddScoped<IAboutPageDal, EfAboutPageDal>();
builder.Services.AddScoped<IAboutPageService,AboutPageManager>();


builder.Services.AddScoped<IGalleryDal, EfGalleryDal>();
builder.Services.AddScoped<IGalleryService, GalleryManager>();

builder.Services.AddScoped<IEventDal, EfEventsDal>();
builder.Services.AddScoped<IEventService,EventsManager>();

builder.Services.AddScoped<IChefDal, EfChefsDal>();
builder.Services.AddScoped<IChefService, ChefManager>();

builder.Services.AddScoped<IMainPageDal, EfMainPageDal>();
builder.Services.AddScoped<IMainPageService, MainPageManager>();

builder.Services.AddScoped<IServicesDal,EfServicesDal>();
builder.Services.AddScoped<IServicesService, ServicesManager>();

builder.Services.AddScoped<IAboutDal,EfAboutDal>();
builder.Services.AddScoped<IAboutService,AboutManager>();

builder.Services.AddScoped<IMessageDal, EfMessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();

builder.Services.AddScoped<IDrinkDal, EfDrinksDal>();
builder.Services.AddScoped<IDrinksService, DrinksManager>();

builder.Services.AddScoped<IBreakFastDal,EfBreakFastDal>();
builder.Services.AddScoped<IBreakFastService, BreakFastManager>();

builder.Services.AddScoped<IMainFoodDal, EfMainFoodDal>();
builder.Services.AddScoped<IMainFoodService, MainFoodManager>();

builder.Services.AddScoped<IDessertsDal, EfDessertsDal>();
builder.Services.AddScoped<IDessertsService, DessertsManager>();




builder.Services.AddDbContext<TeaContext>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
