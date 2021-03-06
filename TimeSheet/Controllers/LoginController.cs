using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Dtos.LoginDtos;
using TimeSheet.Dtos.PositionDtos;
using TimeSheet.Dtos.RefreshTokenDtos;
using TimeSheet.Dtos.UserDto;
using TimeSheet.Entities;
using TimeSheet.Helper;
using VoltekApi.Helper;

namespace TimeSheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]



    public class loginController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        Answer<UserLoginDto> loginfinishObject;
        public loginController(DataContext context, IConfiguration config, IJwtService jwtService, IMapper mapper)
        {
            _context = context;
            _config = config;
            _jwtService = jwtService;
            _mapper = mapper;
        }


        [HttpPost]
        public ActionResult<Answer<UserLoginDto>> Login(UserLoginDto userLoginDto)
        {

            TokenInit tokenInitilizing = new TokenInit(_jwtService, _context);
            if (userLoginDto.key == null)
            {
                return loginfinishObject = new Answer<UserLoginDto>(404, "Username empty", null);
            }
            var User = _context.Employees.FirstOrDefault(x => x.fin.ToLower() == userLoginDto.key.ToLower());
            
            if (User == null)
            {
                return loginfinishObject = new Answer<UserLoginDto>(400, "FIN or password is incorrect", null);

            }
            if (User.password != Hashing.ToSHA256(userLoginDto.password))
            {

                return loginfinishObject = new Answer<UserLoginDto>(409, "FIN or password is incorrect", null);
            }
            UserLoginDto UserLoginDto = new UserLoginDto()
            {
                key = userLoginDto.key,
                password = userLoginDto.password
            };

            Token token = tokenInitilizing.Init(UserLoginDto, _config, User.id);
            token.User = _mapper.Map<EmployeeGetDto>(User);


            return StatusCode(200, token);
        }


        [HttpPost]
        [Route("refreshToken")]
        public ActionResult<Answer<UserLoginDto>> RefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var token = _context.RefreshTokens.FirstOrDefault(x => x.RefreshTokenString == refreshTokenDto.refreshtoken);

            if (token == null)
                return loginfinishObject = new Answer<UserLoginDto>(200, "Refresh token not found. Sign in with user", null);

            var user = _context.Employees.FirstOrDefault(x => x.id == token.employeeId);

            if (user == null)
                return loginfinishObject = new Answer<UserLoginDto>(200, "User not found. Sign in another user", null);


            UserLoginDto item = new UserLoginDto()
            {
                key = user.fin,
                password = user.password
            };

            if (token.RefreshTokenEndDate > System.DateTime.Now)
            {
                Token Token = _jwtService.Generate(item, _config, _config.GetSection("JWT:secret").Value);

                token.RefreshTokenString = Token.RefreshToken;
                token.RefreshTokenEndDate = Token.ExpiredTime.AddMinutes(5);
                _context.SaveChanges();

                return Ok(new { token = Token });
            }
            else
            {
                return loginfinishObject = new Answer<UserLoginDto>(400, "Token is time out. Sign in with user", null);
            }

        }

    }
}
