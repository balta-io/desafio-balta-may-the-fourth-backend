namespace LotoBackend.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime InsertedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            Active = true;
            SetInsertAt();
            SetUpdateAt();
        }

        public void SetInsertAt()
        {
            InsertedAt = DateTime.UtcNow;
            SetUpdateAt();
        }

        public void SetUpdateAt()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEntityToActive()
        {
            Active = true;
            SetUpdateAt();
        }

        public void SetEntityToInactive()
        {
            Active = false;
            SetUpdateAt();
        }
    }
}
