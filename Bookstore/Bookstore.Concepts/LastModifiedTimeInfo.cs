using System.ComponentModel.Composition;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;

namespace Bookstore.Concepts
{
    /// <summary>
    /// Automatically enters time when the records was modified.
    /// </summary>
    [Export(typeof(IConceptInfo))]
    [ConceptKeyword("LastModifiedTime")]
    public class LastModifiedTimeInfo : IConceptInfo
    {
        [ConceptKey]
        public DateTimePropertyInfo Property { get; set; }
    }
}
