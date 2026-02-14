using FieldForm.API;

namespace FieldForm
{
    internal class Field : IField
    {
        IList<int> fieldObjects = new List<int>();        

        public int Background { get; internal set; }        
        
    }
}
