using Data;
using Data.Migrations;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly AppDbContext _appDbContext;


        public EmpleadoService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Models.Crud.Empleado>> GetAllAsync()
        {
            return await _appDbContext.Empleados.ToListAsync();
        }

        public async Task AddAsync(Models.Crud.Empleado empleado)
        {
            await _appDbContext.Empleados.AddAsync(empleado);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var empleado = await _appDbContext.Empleados.FirstOrDefaultAsync(e => e.IdEmpleado == id);
            if (empleado != null)
            {
                _appDbContext.Empleados.Remove(empleado);
                await _appDbContext.SaveChangesAsync();
            }
        }

        

        public async Task UpdateAsync(Models.Crud.Empleado empleado)
        {
            _appDbContext.Empleados.Update(empleado);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Models.Crud.Empleado> GetByIdAsync(int id)
        {
            return await _appDbContext.Empleados.FirstOrDefaultAsync(e => e.IdEmpleado == id);
        }
    }
}
