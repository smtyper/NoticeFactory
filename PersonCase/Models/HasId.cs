using System.ComponentModel.DataAnnotations;

namespace PersonCase.Models
{
    public abstract class HasId<T>
    {
        [Key]
        public T Id { get; protected set; }

        public HasId(T id)
        {
            Id = id;
        }

        protected HasId()
        {

        }
    }
}