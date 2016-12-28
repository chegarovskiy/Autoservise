using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.DataAccessLayer
{
    /// <summary>
    /// Interface for implement by dictionary repository for CRUD over dictionaries
    /// </summary>
    /// <typeparam name="TDictionaryEntity"></typeparam>
    public class DictionaryRepository<TDictionaryEntity> : BaseRepository<TDictionaryEntity>, IDictionaryRepository<TDictionaryEntity>
        where TDictionaryEntity : Dictionary
    {
         
    }
}