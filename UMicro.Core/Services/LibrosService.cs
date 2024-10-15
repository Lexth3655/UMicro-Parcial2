using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Domain.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Services
{
    public class LibrosService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LibrosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Libros>> GetAllLibros()
        {
            return await _unitOfWork.Libros.GetAllAsync();
        }

        public async Task<Libros> GetLibrosById(int? id)
        {
            return await _unitOfWork.Libros.GetByIdAsync(id);
        }

        public async Task<Libros> AddLibros(Libros libro)
        {
            var addedlibro = await _unitOfWork.Libros.AgregarAsync(libro);
            await _unitOfWork.CompleteAsync();
            return addedlibro;
        }

        public async Task UpdateLibros(Libros libro)
        {
            await _unitOfWork.Libros.ActualizarAsync(libro);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteLibros(int id)
        {
            await _unitOfWork.Libros.EliminarAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
