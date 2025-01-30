namespace esercizio_1.Interfaces
{

    // Creata una interfaccia base per tutti i service CRUD così da rendere più snelle le interfacce figlie
    public interface IBaseCRUD<T, DTO>
    {
        public List<T> GetAll();
        public T? GetById(int id);
        public bool Insert(DTO dto);
        public bool Update(int idToUpdate, DTO dto);
        public bool Delete(int idToDelete);

    }

}