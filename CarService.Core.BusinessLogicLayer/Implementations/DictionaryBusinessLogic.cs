using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Core.BusinessLogicLayer.Interfaces;
//using CarService.Core.BusinessLogicLayer.Interfaces;
using CarService.Core.DataAccessLayer;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer.Implementations
{
    public class DictionaryBusinessLogic:BaseBusinessLogic<DictionaryRepository<Dictionary>, Dictionary>, IDictionaryBusinessLogic
    {
        public DictionaryBusinessLogic(DictionaryRepository<Dictionary> repository) : base(repository)
        {
        }

        public IQueryable<Dictionary> GetByCode(Guid code) => Repository.Get(x => x.Id == code && x.IsDeleted==false);

        public override void Remove(Dictionary entity)
        {
            var toDelete = Repository.GetById(entity.Id);
            toDelete.IsDeleted = false;
            Repository.Update(toDelete);
        }

        public IQueryable<Dictionary> GetByCode(int code)
        {
            throw new NotImplementedException();
        }
    }
}
