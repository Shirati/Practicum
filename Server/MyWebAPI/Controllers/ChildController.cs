using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private readonly IService<ChildDTO> _Children;
        public ChildController(IService<ChildDTO> children)
        {
            _Children = children;
        }



        // GET: api/<ActionController>
        [HttpGet]
        public async Task<List<ChildDTO>> Get()
        {
            return await _Children.GetAll();
        }

        // GET api/<ActionController>/5
        [HttpGet("{id}")]
        public async Task<ChildDTO> Get(int id)
        {
            return await _Children.GetById(id);
        }

        // POST api/<ActionController>
        [HttpPost]
        public async Task<ChildDTO> Post([FromBody] ChildModel postModel)
        {
            ChildDTO newOne = new ChildDTO();
            newOne.IdChild = postModel.IdChild;
            newOne.Fullname = postModel.Fullname;
            newOne.DateOfBirth = postModel.DateOfBirth;
            newOne.ParentId = 0;
            return await _Children.Add(newOne);
        }

        // PUT api/<ActionController>/5
        [HttpPut("{id}")]
        public async Task<ChildDTO> Put([FromBody] ChildModel postModel)
        {
            ChildDTO newOne = new ChildDTO();
            //newOne.NumChild = postModel.NumChild;
            newOne.IdChild = postModel.IdChild;
            newOne.Fullname = postModel.Fullname;
            newOne.DateOfBirth = postModel.DateOfBirth;
            newOne.ParentId = postModel.ParentId;
            return await _Children.Update(newOne);
        }

        // DELETE api/<ActionController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _Children.Delete(id);
        }
    }
}
