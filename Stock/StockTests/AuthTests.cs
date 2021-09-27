using Domain;
using FluentAssertions;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Xunit;

namespace StockTests
{
    public class AuthTests
    {
        private readonly IAuthService _authService;

        private readonly IConfiguration _configuration;

        public AuthTests()
        {
            _configuration = TestHelper.InitConfiguration();
            _authService = new AuthService(_configuration);
        }

        /// <summary>
        /// A unit test for checking the case where password is not provided.
        /// </summary>
        [Fact]
        public async Task CreateToken_ArgumentNullException()
        {
            var exception = await Record.ExceptionAsync(() => _authService.CreateToken(string.Empty));
            exception.Should().BeOfType(typeof(ArgumentNullException));
        }

        /// <summary>
        /// A unit test for checking wrong password case.
        /// </summary>
        [Fact]
        public async Task CreateToken_UnauthorizedAccessException()
        {
            var exception = await Record.ExceptionAsync(() => _authService.CreateToken("dummy_password"));
            exception.Should().BeOfType(typeof(UnauthorizedAccessException));
        }

        /// <summary>
        /// A unit test for checking successful token creation.
        /// </summary>
        [Fact]
        public async Task CreateToken_Token()
        {
            string token = await _authService.CreateToken(_configuration.GetSection(StockConstants.TokenPassword).Value);
            token.Should().NotBeNullOrEmpty();
        }
    }
}
