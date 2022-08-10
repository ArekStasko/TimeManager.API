using System.Security.Cryptography;
using TimeManager.API.Data;
using TimeManager.API.Authentication;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace TimeManager.API.Processors.AuthenticationProcessor
{
    public class User_Utilities : Processor
    {
        public User_Utilities(DataContext context) : base(context) { }
        public Tuple<byte[], byte[]> CreatePasswordHash(string password)
        {
            byte[] passwordSalt;
            byte[] passwordHash;

            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

            return new Tuple<byte[], byte[]>(passwordHash, passwordSalt);
        }

        public bool VerifyPasswordHash(string password, User user)
        {         
            using (var hmac = new HMACSHA512(user.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(user.PasswordHash);
            }
        }

        public Token CreateToken(User user)
        {
            var token = _context.Tokens.SingleOrDefault(t => t.userId == user.Id);   
            if (token != null && CheckExpirationDate(token))
            {
                return token;
            }


            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_context.TokenKey.FirstOrDefault().Key));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            JwtSecurityToken jwtToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            token = new Token(jwt);
            token.userId = user.Id;
            token.createDate = DateTime.Now;
            token.expirationDate = DateTime.Now.AddDays(1);
            _context.Tokens.Add(token);
            _context.SaveChanges();
            return token;
        }

        public bool IsAuthorised(User user)
        {
            var token = _context.Tokens.SingleOrDefault(t => t.userId == user.Id);
            if (token != null && CheckExpirationDate(token)) return true;

            return false;
        }

        private bool CheckExpirationDate(Token token)
        {
            int tokenTime = DateTime.Now.CompareTo(token.expirationDate);
            if (tokenTime > 0) _context.Tokens.Remove(token);
            return tokenTime < 0;
        }


    }
}
