using VforNGOss.DataTransefObjects;

namespace VforNGOss.Repositories
{
    public interface IRepository
    {
        public Task Create(CreateDTO createDTO, int Id);

        public Task<IEnumerable<TodoItem>> GetAll();

        public Task<TodoItem> GetById(Guid id);

        public Task<IEnumerable<TodoItem>> GetByUser(Guid id);

        public Task Update(UpdateTodoDTO projectDTO, Guid id);

        public Task Delete(Guid id);
    }
}
