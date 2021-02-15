using System.ComponentModel.Composition;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;

namespace Bookstore.Concepts
{
    [Export(typeof(IConceptInfo))]
    [ConceptKeyword("CodeTable")]
    public class CodeTableInfo : IConceptInfo
    {
        [ConceptKey]
        public EntityInfo Entity { get; set; }

    }
}
