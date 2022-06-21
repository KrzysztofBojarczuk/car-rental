using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCarWebApi.Dtos;
using RentalCarWebApi.InterafceRepository;

namespace RentalCarWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberController(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = await _memberRepository.GetAllMemebersAsync();
            var membersDto = _mapper.Map<List<MemberGetDto>>(members);
            return Ok(membersDto);
        }
    }
}
