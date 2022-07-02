using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalCarWebApi.Dtos;
using RentalCarWebApi.InterafceRepository;
using RentalCarWebApi.Models;

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
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetMemberById(int id)
        {
            var member = await _memberRepository.GetMemeberByIdAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            var memberDto = _mapper.Map<MemberGetDto>(member);
            return Ok(memberDto);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> CreateMember([FromBody] MemberCreateDto memberPostDto)
        {
            var member = _mapper.Map<Member>(memberPostDto);
            await _memberRepository.CreateMemberAsync(member);
            var memberGet = _mapper.Map<MemberGetDto>(member);
            return CreatedAtAction(nameof(GetMemberById), new { id = member.MemberId }, memberGet);
        }
        [HttpPut("Put/{id}")]
        public async Task<IActionResult> UpdateMember([FromBody] MemberCreateDto memberUpdateDto, int id)
        {
            var toUpdate = _mapper.Map<Member>(memberUpdateDto);
            toUpdate.MemberId = id;

            await _memberRepository.UpdateMemberAsync(toUpdate);
            return NoContent();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await _memberRepository.DeleteMemberAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
