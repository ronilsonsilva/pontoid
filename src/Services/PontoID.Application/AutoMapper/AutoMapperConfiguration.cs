using AutoMapper;
using PontoID.Domain.Entities;
using PontoID.Domain.Shared.ViewModels;

namespace PontoID.Application.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Escola, EscolaViewModel>().ReverseMap();
            CreateMap<Aluno, AlunoViewModel>().ReverseMap();
            CreateMap<Turma, TurmaViewModel>().ReverseMap();
        }
    }
}
