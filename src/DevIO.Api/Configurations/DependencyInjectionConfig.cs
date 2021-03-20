﻿using DevIO.Api.Configuration;
using DevIO.Api.Extensions;
using DevIO.Business.Intefaces;
using DevIO.Business.Notificacoes;
using DevIO.Business.Services;
using DevIO.Data.Context;
using DevIO.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DevIO.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            #region DATA BASE
            services.AddScoped<MeuDbContext>();
            #endregion

            #region NOTIFICADORES
            services.AddScoped<INotificador, Notificador>();
            #endregion

            #region SERVICES
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            #endregion

            #region REPOSITORIES
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IEnderecoFornecedorRepository, EnderecoFornecedorRepository>();
            services.AddScoped<IEnderecoClienteRepository, EnderecoClienteRepository>();
            #endregion

            #region OTHERS
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            #endregion

            return services;
        }
    }
}
