using AutoMapper;
using Character.Repository.Model;
using Character.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character.Business.Profiles
{
    public sealed class AssemblyMarker
    {
        public AssemblyMarker() { }
    }
    public class CharacterProfiles : Profile
    {
        public CharacterProfiles()
        {
            CreateMap<CharacterDb, CharacterDTO>();
            CreateMap<CharacterDTO, CharacterDb>();
        }
    }
}
