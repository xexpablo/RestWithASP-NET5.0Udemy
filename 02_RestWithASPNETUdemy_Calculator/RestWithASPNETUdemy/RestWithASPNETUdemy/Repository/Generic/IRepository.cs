﻿using RestWithASPNETUdemy.Model.Base;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindByID(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool ExistsID(long id);
    }
}
