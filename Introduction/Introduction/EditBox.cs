using System.Reflection;

namespace Introduction
{
    interface IDataBound
    {
        void Bind(Binder b);
    }

    public class EditBox : IComboBox, IDataBound
    {
        public void Bind(Binder b)
        {
            throw new System.NotImplementedException();
        }

        public void Paint()
        {
            throw new System.NotImplementedException();
        }

        public void SetItems(string[] items)
        {
            throw new System.NotImplementedException();
        }

        public void SetText(string text)
        {
            throw new System.NotImplementedException();
        }
    }
}
