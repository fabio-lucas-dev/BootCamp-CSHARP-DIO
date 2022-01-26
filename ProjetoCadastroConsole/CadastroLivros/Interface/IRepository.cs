namespace CadastroLivros.Interface
{
    public interface IRepository<T>
    {
        void insert(T entity);
        void update(int ID, T entity);
        List<T> toList();
        T searchByID(int id);
        int nextID();
        void delete(int ID);



    }
}
