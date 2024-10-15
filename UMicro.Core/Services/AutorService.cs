using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Domain.Modelo;
using UMicro.Domain.Interfaces;

namespace UMicro.Core.Services
{
    public class AutorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AutorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Autor>> GetAllAutores()
        {
            return await _unitOfWork.Autores.GetAllAsync();
        }

        public async Task<Autor> GetAutorById(int? id)
        {
            return await _unitOfWork.Autores.GetByIdAsync(id);
        }

        public async Task<Autor> AddAutor(Autor autor)
        {
            var addedAutor = await _unitOfWork.Autores.AgregarAsync(autor);
            await _unitOfWork.CompleteAsync();
            return addedAutor;
        }

        public async Task UpdateAutor(Autor autor)
        {
            await _unitOfWork.Autores.ActualizarAsync(autor);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAutor(int id)
        {
            await _unitOfWork.Autores.EliminarAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
