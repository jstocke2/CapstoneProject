//Defines a set of times in the test databse
//All items stored in the database use this class
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowRestfulTests
{
    public class TestDbSet<T> : DbSet<T>, IQueryable, IEnumerable<T>
         where T : class
    {
        ObservableCollection<T> _data;
        IQueryable _query;

        public TestDbSet()
        {
            _data = new ObservableCollection<T>();
            _query = _data.AsQueryable();
        }
        //adds item to set
        public override T Add(T item)
        {
            _data.Add(item);
            return item;
        }
        //removes item from set
        public override T Remove(T item)
        {
            _data.Remove(item);
            return item;
        }
        //adds item to set
        public override T Attach(T item)
        {
            _data.Add(item);
            return item;
        }
        //Creates new item
        public override T Create()
        {
            return Activator.CreateInstance<T>();
        }
        //Creates derived instance of the object
        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }
        //Returns 
        public override ObservableCollection<T> Local
        {
            get { return new ObservableCollection<T>(_data); }
        }
        //Returns the element type in the DbSet
        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }
        //Returns the expression the dbset uses
        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }
        //returns the provider of the dbset
        IQueryProvider IQueryable.Provider
        {
            get { return _query.Provider; }
        }
        //Gets teh enumerator for the dbset
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
        //Same ass above except it is templated
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }
}
