using AutoMapper;
using Common.DTOs;
using Repositories.entities;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.entities
{
    public class UserService : IService<UserDTO>
    {
        private readonly IMapper _mapper;
        private readonly Ientity<User> _userRepository;
        public UserService(IMapper mapper, Ientity<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
    
        public async Task<UserDTO> Add(UserDTO entity)
        {
            var c = _mapper.Map<UserDTO>(await _userRepository.Add(_mapper.Map<User>(entity)));
            return c;
        }

        public async Task Delete(int id)
        {
            await _userRepository.Delete(id);
        }

        public async Task<List<UserDTO>> GetAll()
        {
            return _mapper.Map<List<UserDTO>>(await _userRepository.GetAll());
        }

        public async Task<UserDTO> GetById(int id)
        {
            return _mapper.Map<UserDTO>(await _userRepository.GetById(id));
        }

        public async Task<UserDTO> Update(UserDTO entity)
        {
            return _mapper.Map<UserDTO>(await _userRepository.Update(_mapper.Map<User>(entity)));
        }
    }
}
