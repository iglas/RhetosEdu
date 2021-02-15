using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Rhetos.Compiler;
using Rhetos.Dom.DefaultConcepts;
using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using Rhetos.Extensibility;

namespace Bookstore.Concepts
{
    [Export(typeof(IConceptMacro))]
    public class CodeTableMacro : IConceptMacro<CodeTableInfo>
    {
        public IEnumerable<IConceptInfo> CreateNewConcepts(CodeTableInfo conceptInfo, IDslModel existingConcepts)
        {
            var codePropertyInfo = new ShortStringPropertyInfo
            {
                DataStructure = conceptInfo.Entity,
                Name = "Code"
            };

            var autoCode = new AutoCodePropertyInfo { Property = codePropertyInfo };

            var namePropertyInfo = new ShortStringPropertyInfo
            {
                DataStructure = conceptInfo.Entity,
                Name = "Name"
            };

            var requiredInfo = new RequiredPropertyInfo { Property = namePropertyInfo };

            return new IConceptInfo[]
            {
                codePropertyInfo, autoCode, namePropertyInfo, requiredInfo
            };
        }
    }
}
