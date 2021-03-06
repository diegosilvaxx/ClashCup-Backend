using DevIO.Api.Configuration;
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
            services.AddScoped<IJogadorService, JogadorService>();
            services.AddScoped<IPagamentoService, PagamentoService>();
            services.AddScoped<ITorneioService, TorneioService>();
            services.AddScoped<IRankingService, RankingService>();
            #endregion

            #region REPOSITORIES
            services.AddScoped<IJogadorRepository, JogadorRepository>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<ITorneioRepository, TorneioRepository>();
            services.AddScoped<IRankingRepository, RankingRepository>();

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
