using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using LifeInUK.Api.Documents;
using LifeInUK.Api.Models;

namespace LifeInUK.Api
{

    public static class ServiceCollectionExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<QuestionSetDocument, QuestionSet>();
                    cfg.CreateMap<QuestionSetDocument, QuestionSetDetail>();
                    cfg.CreateMap<QuestionDocument, Question>();
                    cfg.CreateMap<QuestionOptionDocument, QuestionOption>();
                    cfg.CreateMap<QuestionMetadataDocument, QuestionMetadata>();
                });
            configuration.AssertConfigurationIsValid();

            services.AddSingleton<IMapper>(configuration.CreateMapper());
        }
    }
}
