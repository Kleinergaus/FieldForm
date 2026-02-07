namespace FieldForm.API
{
    public interface IField
    {
        /// <summary>
        /// Gets the background id of the field.
        /// </summary>
        int Background { get; }

        /// <summary>
        /// Adds an Object to the field.
        /// </summary>
        /// <param name="id">The id of the object.</param>
        void AddObject(int id);

        /// <summary>
        /// Gets the objectes on this field.
        /// </summary>
        /// <returns>The list of object ids.</returns>
        IList<int> GetObjects();

    }
}
