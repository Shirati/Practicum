using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        private readonly IService<UserDTO> _user;

        private readonly IService<ChildDTO> _children;

        public UserController(IService<UserDTO> user,
            IService<ChildDTO> children)
        {
            _user = user;
            _children = children;
        }


        // GET: api/<ActionController>
        [HttpGet]
        public async Task<List<UserDTO>> Get()
        {
            return await _user.GetAll();
        }

        // GET api/<ActionController>/5
        [HttpGet("{id}")]
        public async Task<UserDTO> Get(int id)
        {
            return await _user.GetById(id);
        }

        // POST api/<ActionController>
        [HttpPost]
        public async Task<UserDTO> Post([FromBody] UserModel postModel)
        {
            UserDTO newUser = new UserDTO
            {
                FirstName = postModel.FirstName,
                LastName = postModel.LastName,
                IdUser = postModel.IdUser,
                MaleOrFemale = postModel.MaleOrFemale,
                Hmo = postModel.Hmo,
                Date = postModel.Date
            };

            newUser = await _user.Add(newUser);

            postModel.Children.ForEach(async child =>
            {
                child.ParentId = newUser.NumUser;
                newUser.Children.Add(await AddChildAsync(child));
            });

            return newUser;
        }

        private async Task<ChildDTO> AddChildAsync(ChildModel postModel)
        {
            ChildDTO newOne = new ChildDTO();
            newOne.IdChild = postModel.IdChild;
            newOne.Fullname = postModel.Fullname;
            newOne.DateOfBirth = postModel.DateOfBirth;
            newOne.ParentId = postModel.ParentId;
            return await _children.Add(newOne);
        }



        // PUT api/<ActionController>/5
        [HttpPut("{id}")]
        public async Task<UserDTO> Put([FromBody] UserModel postModel)
        {
            UserDTO newOne = new UserDTO();
            // newOne.NumUser = postModel.nu;
            newOne.FirstName = postModel.FirstName;
            newOne.LastName = postModel.LastName;
            newOne.IdUser = postModel.IdUser;
            newOne.MaleOrFemale = postModel.MaleOrFemale;
            newOne.Hmo = postModel.Hmo;
            newOne.Date = postModel.Date;
            return await _user.Update(newOne);
        }

        // DELETE api/<ActionController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _user.Delete(id);
        }
    }
}
