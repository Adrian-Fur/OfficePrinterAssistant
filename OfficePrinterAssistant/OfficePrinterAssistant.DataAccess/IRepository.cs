﻿using OfficePrinterAssistant.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficePrinterAssistant.DataAccess
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(int id); 
    }
}
