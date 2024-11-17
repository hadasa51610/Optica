using Microsoft.AspNetCore.Mvc;
using Optica.Controllers;
using Optica.Entities;
using Optica.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class UserUnitTest
    {
        private readonly UserController _usersContorller;

        public UserUnitTest()
        {
            _usersContorller = new UserController(new UserService(new FakeContext()));
        }

        [Fact]
        public void GetAll_User_ReturnsUsers()
        {
            var result = _usersContorller.Get();
            Assert.IsType<ActionResult<List<User>>>(result);
        }
        [Fact]
        public void Get_User_ReturnsUser()
        {
            var id = "123";
            var result= _usersContorller.Get(id);
            Assert.IsType<ActionResult<User>>(result);
        }
        [Fact]
        public void Get_User_OkResult()
        {
            var id = "123";
            var result = _usersContorller.Get(id);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void Get_User_ReturnsNull()
        {
            var id = "123";
            var result = _usersContorller.Get(id).Value;
            Assert.Null(result);
        }
        [Fact]
        public void Post_User_OkResult()
        {
            var user = new User();
            var result = _usersContorller.Post(user);   
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void Put_User_OkResult()
        {
            var id = "123";
            var user=new User();
            var result = _usersContorller.Put(id,user);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void Put_User_NotFoundResult()
        {
            var id = "123";
            var user = new User();
            var result = _usersContorller.Put(id, user);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void Delete_User_OkResult()
        {
            var id = "123";
            var result = _usersContorller.Delete(id);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void Delete_User_NotFoundResult()
        {
            var id = "123";
            var result = _usersContorller.Delete(id);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
