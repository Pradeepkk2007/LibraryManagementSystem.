using LibraryManagementSystem.API.Data;
using LibraryManagementSystem.API.DTOs;
using LibraryManagementSystem.API.Exceptions;
using LibraryManagementSystem.API.Interfaces;
using LibraryManagementSystem.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryManagementSystem.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
{
    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
    new Claim(ClaimTypes.Name, user.Username),
    new Claim(ClaimTypes.Email, user.Email),
    new Claim(ClaimTypes.Role, user.Role)
};

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(
                    Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public AuthService(
            ApplicationDbContext context,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> Register(RegisterDto registerDto)
        {
            bool usernameExists = _context.Users
                                          .Any(x => x.Username == registerDto.Username);

            if (usernameExists)
            {
                throw new BadRequestException("Username already exists.");
            }

            bool emailExists = _context.Users
                                       .Any(x => x.Email == registerDto.Email);

            if (emailExists)
            {
                throw new BadRequestException("Email already exists.");
            }

            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                Role = registerDto.Role,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

        //    await _emailService.SendEmailAsync(
        //        user.Email,
        //        "Welcome to Library Management System",
        //        $@"
        //<h2>Welcome {user.Username}</h2>

        //<p>Your account has been created successfully.</p>

        //<p><strong>Role:</strong> {user.Role}</p>

        //<br/>

        //<p>Thank you for using our Library Management System.</p>

        //<p><strong>Library Management Team</strong></p>"
        //    );

            return "User registered successfully.";
        }

        public string Login(LoginDto loginDto)
        {
            var user = _context.Users
                               .FirstOrDefault(x => x.Username == loginDto.Username);

            if (user == null)
            {
                throw new UnauthorizedException("Invalid Username or Password.");
            }

            if (!user.IsActive)
            {
                throw new UnauthorizedException("Your account has been deactivated.");
            }

            bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(
                loginDto.Password,
                user.PasswordHash);

            if (!isPasswordCorrect)
            {
                throw new UnauthorizedException("Invalid Username or Password.");
            }

            return GenerateJwtToken(user);
        }
    }
    }
