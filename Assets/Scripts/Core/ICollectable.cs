namespace Core
{
    public interface ICollectable
    {
        public int Value
        {
            get;
            set;
        }
        
        public void Collect();
        public void ResetCollectable();
    }
}