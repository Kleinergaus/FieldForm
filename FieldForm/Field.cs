using FieldForm.API;

namespace FieldForm
{
    internal class Field : IField
    {
        IList<int> fieldObjects = new List<int>();        

        public int Background { get; internal set; }

        public IList<int> GetObjects()
        {
            return fieldObjects; 
        }

        public void AddObject(int id)
        {
            if (id > 0)
            {
                fieldObjects.Add(id);
            }
        }
    }
}
