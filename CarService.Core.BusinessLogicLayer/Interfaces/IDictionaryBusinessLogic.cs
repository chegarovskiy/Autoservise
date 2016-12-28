using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Core.DataAccessLayer;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer.Interfaces
{
    interface IDictionaryBusinessLogic:IBaseBusinessLogic<Dictionary>
    {
        IQueryable<Dictionary> GetByCode(int code);
    }
}
