using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Repositories.entities;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Utilities;

namespace Repositories.repositories
{
    public class ChildRepository:Ientity<Child>
    {
        Icontex _contex;
        public ChildRepository(Icontex contex)
        {
            _contex = contex;
        }

        public async Task<Child> Add(Child entity)
        {
            //if (_contex.Children.Count(x => x.IdChild == entity.IdChild) == 1)
            //    throw new Exception("  משתמש קיים במערכת");
            //if (ValidateUtil.LegalId(entity.IdChild)&& ValidateUtil. IsHebrew(entity.Fullname))
            {
               EntityEntry<Child> newEntity = _contex.Children.Add(entity);
            await _contex.SaveChangesAsync();
            return newEntity.Entity;
            }
            //else
            
            //    throw new Exception("  תעות בתעודת זהות או בשם");
            

           
        }

        public async Task Delete(int id)
        {
            _contex.Children.Remove(_contex.Children.Single(a => a.NumChild == id));
            await _contex.SaveChangesAsync();
        }

        public async Task<List<Child>> GetAll()
        {
            return await _contex.Children.ToListAsync();

        }
        public async Task<Child> GetById(int id)
        {
            return await _contex.Children.SingleAsync(a => a.NumChild == id);
        }

        public async Task<Child> Update(Child entity)
        {
            Delete(entity.NumChild);
            return await Add(entity);
        }
    }
}

