using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repositories.entities;
using Repositories.Interface;
using Repositories.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.repositories
{
    public class UserRepository : Ientity<User>
    {
        Icontex _contex;
        public UserRepository(Icontex contex)
        {
            _contex = contex;
        }

        public async Task<User> Add(User entity)
        {
            if (_contex.Users.Count(x => x.IdUser == entity.IdUser) == 1)
                throw new Exception("משתמש קיים במערכת");
            if (ValidateUtil.LegalId(entity.IdUser) )
            {
                EntityEntry<User> newEntity = _contex.Users.Add(entity);
                await _contex.SaveChangesAsync();
                return newEntity.Entity;
            }
            else
                throw new Exception("טעות בתעודת זהות");
        }

        public async Task Delete(int id)
        {
            _contex.Users.Remove(_contex.Users.Single(a => a.NumUser == id));
            await _contex.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await _contex.Users.ToListAsync();

        }
        public async Task<User> GetById(int id)
        {
            return await _contex.Users.SingleAsync(a => a.NumUser == id);
        }

        public async Task<User> Update(User entity)
        {
            Delete(entity.NumUser);
            return await Add(entity);
        }
    }
}
