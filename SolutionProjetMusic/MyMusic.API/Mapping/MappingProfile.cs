using AutoMapper;
using MyMusic.API.Resources;
using MysMusic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusic.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain(base de donnée )  vers Resource
            CreateMap<Music, MusicResource>();
            CreateMap<Artist, ArtistResource>();
            CreateMap<Music, SaveMusicResource>();
            CreateMap<Artist, SaveArtistResource>();
            CreateMap<Composer, ComposerResourse>();
            CreateMap<Composer, SaveComposerResource>();
            CreateMap<User, UserResource>();


            // Resources vers Domain ou la base de données

            CreateMap<MusicResource,Music >();
            CreateMap<ArtistResource,Artist>();
            CreateMap<SaveMusicResource,Music>();
            CreateMap<SaveArtistResource,Artist >();
            CreateMap<ComposerResourse,Composer >();
            CreateMap<SaveComposerResource,Composer >();
            CreateMap<UserResource,User >();





        }

    }
}
