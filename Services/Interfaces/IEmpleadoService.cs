﻿using Models.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEmpleadoService
    {
        Task <List<Empleado>> GetAllAsync();
        Task AddAsync(Empleado empleado);
        Task<Empleado> GetByIdAsync(int id);
        Task UpdateAsync(Empleado empleado);
        Task DeleteAsync(int id);
    }
}
