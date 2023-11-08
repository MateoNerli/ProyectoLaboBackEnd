using AutoMapper;
using ProyectoLaboBackEnd.Models.Comment;
using ProyectoLaboBackEnd.Models.Comment.Dto;
using ProyectoLaboBackEnd.Models.Community;
using ProyectoLaboBackEnd.Models.Community.Dto;
using ProyectoLaboBackEnd.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

public class CommunityService
{
    private readonly ICommunityRepository _communityRepository;
    private readonly IMapper _mapper;

    public CommunityService(ICommunityRepository communityRepository, IMapper mapper)
    {
        _communityRepository = communityRepository;
        _mapper = mapper;
    }

    private async Task<Community> GetOneByIdOrException(int id)
    {
        var post = await _communityRepository.GetOne(u => u.CommunityId == id);

        if (post == null)
        {
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        return post;
    }

    public async Task<List<CommunitysDto>> GetAll()
    {
        var lista = await _communityRepository.GetAll();
        return _mapper.Map<List<CommunitysDto>>(lista);
    }

    public async Task<CommunityDto> GetById(int id)
    {
        var post = await GetOneByIdOrException(id);

        return _mapper.Map<CommunityDto>(post);
    }

    public async Task<CommunityDto> Create(CreateCommunityDto createPostDto)
    {
        var post = _mapper.Map<Community>(createPostDto);

        await _communityRepository.Add(post);

        return _mapper.Map<CommunityDto>(post);
    }

    public async Task<CommunityDto> UpdateById(int id, UpdateCommunityDto updatePostDto)
    {
        var post = await GetOneByIdOrException(id);

        var updated = _mapper.Map(updatePostDto, post);

        return _mapper.Map<CommunityDto>(await _communityRepository.Update(updated));
    }

    public async Task DeleteById(int id)
    {
        var comment = await GetOneByIdOrException(id);

        await _communityRepository.Delete(comment);
    }

}
