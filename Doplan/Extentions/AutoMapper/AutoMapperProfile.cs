using AutoMapper;
using Doplan.Data.Entities;
using Doplan.Models.DTO.Requests;
using Doplan.Models.DTO.Responses;

namespace Doplan.Extentions.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        private void CreateReviewMaps()
        {
            CreateMap<TaskToDo, TaskToDoResponse>();
            CreateMap<TaskToDoRequest, TaskToDo>();
        }

        public AutoMapperProfile()
        {
            CreateReviewMaps();
        }

    }
}
