using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using TimeSheet.DatabaseContext;
using TimeSheet.Entities;

namespace TimeSheet.Helper
{
    public interface IAuthenticationManager
    {
        JwtSecurityToken CurrentClaim(string token);
        Employee tokenOwner(JwtSecurityToken tokenS);
        Answer<string> Manager(Employee user, JwtSecurityToken tokenS);
    }

    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly DataContext _context;
        public AuthenticationManager(DataContext context)
        {
            _context = context;
        }

        public JwtSecurityToken CurrentClaim(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenS = new JwtSecurityToken(); 
            try
            {
                var jsonToken = handler.ReadToken(token);
                tokenS = jsonToken as JwtSecurityToken;
            }
            catch (Exception)
            {

                return null;
            }
          

            if (tokenS == null)
            {
                return null;
            }
            else
            {
                return tokenS;
            }
        }

        public Employee tokenOwner(JwtSecurityToken tokenS)
        {

            var claim = tokenS.Claims.FirstOrDefault(x => x.Type == "Key").Value;

            var user = _context.Employees.FirstOrDefault(x => x.fin == claim);

            if (user == null)
            {
                return null;
            }
            return user;
        }

        public Answer<string> Manager(Employee user, JwtSecurityToken tokenS)
        {
            Answer<string> getFinishObject;


            var currentRefreshToken = _context.RefreshTokens.FirstOrDefault(a => a.employeeId == user.id);

            if (currentRefreshToken == null)
            {
                return getFinishObject = new Answer<string>(404, "Token not found", null);
            }

            if (tokenS.ValidTo < DateTime.UtcNow)
            {
                return getFinishObject = new Answer<string>(401, "Unauthorized", null);
            }

            return getFinishObject = new Answer<string>(200, "Token is active", null);
        }

    }
}

