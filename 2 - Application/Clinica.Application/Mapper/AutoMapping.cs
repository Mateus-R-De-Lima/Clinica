using AutoMapper;
using Clinica.Communication.Usuario.Request;
using Clinica.Communication.Usuario.Response;
using Clinica.Domain.Usuario.Entities;

namespace Clinica.Application.Usuario.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            AutoMappingRequest();
            AutoMappingResponse();
        }
        /// <summary>
        /// Mapeamento de Request
        /// </summary>
        private void AutoMappingRequest()
        {
            // CreateMap<Origem, Destino>();
            CreateMap<RequestCreateUserDTO, User>();
        }
        /// <summary>
        /// Mapeamento de Response
        /// </summary>
        private void AutoMappingResponse()
        {
            // CreateMap<Origem, Destino>();
            CreateMap<User, ResponseCreateUserDTO>();
        }
    }
}
