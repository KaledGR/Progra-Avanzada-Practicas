using AP.Data.Models;
using AP.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Core.BusinessLogic
{
    public interface IComponentBusiness
    {
        /// <summary>
        /// Obtiene todos los componentes o uno específico por ID.
        /// </summary>
        /// <param name="id">ID del componente (opcional)</param>
        /// <returns>Lista de componentes o uno específico</returns>
        Task<IEnumerable<Component>> GetComponent(int? id);

        /// <summary>
        /// Guarda o actualiza un componente.
        /// </summary>
        /// <param name="component">Entidad de componente</param>
        /// <returns>True si se guarda correctamente</returns>
        Task<bool> SaveComponentAsync(Component component);

        /// <summary>
        /// Elimina un componente por ID.
        /// </summary>
        /// <param name="id">ID del componente</param>
        /// <returns>True si se elimina correctamente</returns>
        Task<bool> DeleteComponentAsync(int id);
    }

    public class ComponentBusiness(IRepositoryComponent repositoryComponent) : IComponentBusiness
    {
        /// <inheritdoc/>
        public async Task<IEnumerable<Component>> GetComponent(int? id)
        {
            return id == null
                ? await repositoryComponent.ReadAsync()
                : [await repositoryComponent.FindAsync((int)id)];
        }

        /// <inheritdoc/>
        public async Task<bool> SaveComponentAsync(Component component)
        {  
            return await repositoryComponent.UpdateAsync(component);
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteComponentAsync(int id)
        {
            var component = await repositoryComponent.FindAsync(id);
            return await repositoryComponent.DeleteAsync(component);
        }
    }
}
