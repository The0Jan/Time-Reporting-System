using System.Globalization;
using AutoMapper;
using NTR.Models;
using NTR.Models.RestModels;

namespace NTR.Models;

public class ModelProfile : Profile
{
    public ModelProfile()
    {
        CreateMap<AcceptedActivity, Activity>();
    }
}
