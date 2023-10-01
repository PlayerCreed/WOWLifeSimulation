
namespace Fox.Data
{
    public interface IInit
    {
        public void Init();
    }

    public interface IClear
    {
        public void Clear();
    }

    public interface IData: IInit, IClear
    { 
    
    }
}