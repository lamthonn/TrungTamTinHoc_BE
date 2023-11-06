﻿using Microsoft.EntityFrameworkCore;
using TrungTamTinHoc_BE.Data;
using TrungTamTinHoc_BE.Services;
using TrungTamTinHoc_BE.Services.GiangVien;
using TrungTamTinHoc_BE.Services.HocVien;
using TrungTamTinHoc_BE.Services.KhoaHocServices;
using TrungTamTinHoc_BE.Services.tài_khoản;
using TrungTamTinHoc_BE.Services.ThongBao;
using TrungTamTinHoc_BE.Services.thongBaoServices;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connect")));

//register service
builder.Services.AddScoped<ITaiKhoanRepository, TaiKhoanRepository>();
builder.Services.AddScoped<IHocvienRepository, HocvienRepository>();
builder.Services.AddScoped<IGiangVienRepository, GiangVienRepository>();
builder.Services.AddScoped<IThongBaoRepository,ThongBaoRepository>();
builder.Services.AddScoped<IKhoaHocRepository, KhoaHocRepository>();

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
