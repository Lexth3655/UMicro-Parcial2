using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMicro.Domain.Interfaces;
using UMicro.Domain.Modelo;

namespace UMicro.Core.Services
{
    public class EditorialService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditorialService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Editorial>> GetAllEditorial()
        {
            return await _unitOfWork.Editoriales.GetAllAsync();
        }

        public async Task<Editorial> GetEditorialById(int? id)
        {
            return await _unitOfWork.Editoriales.GetByIdAsync(id);
        }

        public async Task<Editorial> AddEditorial(Editorial editorial)
        {
            var addededitorial = await _unitOfWork.Editoriales.AgregarAsync(editorial);
            await _unitOfWork.CompleteAsync();
            return addededitorial;
        }

        public async Task UpdateEditorial(Editorial editorial)
        {
            await _unitOfWork.Editoriales.ActualizarAsync(editorial);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteEditorial(int id)
        {
            await _unitOfWork.Editoriales.EliminarAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
