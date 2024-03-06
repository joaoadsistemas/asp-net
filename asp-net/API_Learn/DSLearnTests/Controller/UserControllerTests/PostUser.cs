using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiCatalogo.Repositories;
using DSLearn.Controllers;
using DSLearn.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace DSLearnTests.Controller.UserControllerTests
{
    public class PostUser
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly UserController _userController;

        public PostUser()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _userController = new UserController(_unitOfWork);
        }


        [Fact]
        public async Task AddLikeToReplyShouldReturnOkWhenReplyIdExists()
        {
            var userId = Guid.NewGuid().ToString();
            var replyId = 1;

            // Criação de uma ClaimsPrincipal simulada para representar o usuário autenticado
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                // Adicione outras reivindicações, se necessário
            };

            var identity = new ClaimsIdentity(claims, "TestAuthentication");
            var principal = new ClaimsPrincipal(identity);

            // Atribui a ClaimsPrincipal simulada ao contexto da controladora
            _userController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = principal }
            };

            // Chama o método de controle
            var actionResult = await _userController.AddLikeToReply(replyId);

            // Verifica se o resultado é do tipo OkObjectResult
            Assert.IsType<OkResult>(actionResult);
        }

        [Fact]
        public async Task AddLikeToReplyShouldReturnBadRequestWhenReplyIdDoesNotExists()
        {
            var userId = Guid.NewGuid().ToString();
            var nonExistreplyId = 1000;

            // Criação de uma ClaimsPrincipal simulada para representar o usuário autenticado
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                // Adicione outras reivindicações, se necessário
            };

            var identity = new ClaimsIdentity(claims, "TestAuthentication");
            var principal = new ClaimsPrincipal(identity);

            // Atribui a ClaimsPrincipal simulada ao contexto da controladora
            _userController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = principal }
            };

            // Configuração do mock do repositório para lançar uma exceção quando o replyId não existe
            _unitOfWork.UserRepository
                .When(x => x.AddLikeToReply(Arg.Is<int>(id => id == nonExistreplyId), Arg.Any<string>()))
                .Throw(new ArgumentException($"Id {nonExistreplyId} does not exists"));

            // Chama o método de controle e espera pela exceção
            var actionResult = await _userController.AddLikeToReply(nonExistreplyId);

            // Verifica se o resultado é do tipo BadRequest
            Assert.IsAssignableFrom<BadRequestObjectResult>(actionResult);
        }


        [Fact]
        public async Task AddLikeToTopicShouldReturnOkWhenTopicIdExists()
        {
            var userId = Guid.NewGuid().ToString();
            var topicId = 1;

            // Criação de uma ClaimsPrincipal simulada para representar o usuário autenticado
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                // Adicione outras reivindicações, se necessário
            };

            var identity = new ClaimsIdentity(claims, "TestAuthentication");
            var principal = new ClaimsPrincipal(identity);

            // Atribui a ClaimsPrincipal simulada ao contexto da controladora
            _userController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = principal }
            };

            // Chama o método de controle
            var actionResult = await _userController.AddLikeToTopic(topicId);

            // Verifica se o resultado é do tipo OkObjectResult
            Assert.IsType<OkResult>(actionResult);
        }



        [Fact]
        public async Task AddLikeToTopicShouldReturnBadRequestWhenTopicIdDoesNotExists()
        {
            var userId = Guid.NewGuid().ToString();
            var nonExistsTopic = 1000;

            // Criação de uma ClaimsPrincipal simulada para representar o usuário autenticado
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                // Adicione outras reivindicações, se necessário
            };

            var identity = new ClaimsIdentity(claims, "TestAuthentication");
            var principal = new ClaimsPrincipal(identity);

            // Atribui a ClaimsPrincipal simulada ao contexto da controladora
            _userController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = principal }
            };

            // Configuração do mock do repositório para lançar uma exceção quando o replyId não existe
            _unitOfWork.UserRepository
                .When(x => x.AddLikeToTopic(Arg.Is<int>(id => id == nonExistsTopic), Arg.Any<string>()))
                .Throw(new ArgumentException($"Id {nonExistsTopic} does not exists"));

            // Chama o método de controle e espera pela exceção
            var actionResult = await _userController.AddLikeToTopic(nonExistsTopic);

            // Verifica se o resultado é do tipo BadRequest
            Assert.IsAssignableFrom<BadRequestObjectResult>(actionResult);
        }


    }
}
