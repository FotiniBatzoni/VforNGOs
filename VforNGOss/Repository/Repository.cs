namespace VforNGOss.Repository
{
    public abstract class Repository<T> where T : new()
    {
        DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        protected DbContext Context
        {
            get
            {
                return this._context;
            }
        }

        protected IEnumerable<T> ToList(IDbCommand command)
        {
            using (var record = command.ExecuteReader())
            {
                List<T> items = new List<T>();
                while (record.Read())
                {

                    items.Add(Map<T>(record));
                }
                return items;
            }
        }

        protected T Map<T>(IDataRecord record)
        {
            var objT = Activator.CreateInstance<T>();
            foreach (var property in typeof(T).GetProperties())
            {
                if (record.HasColumn(property.Name) && !record.IsDBNull(record.GetOrdinal(property.Name)))
                    property.SetValue(objT, record[property.Name]);
            }
            return objT;
        }
    }
}
