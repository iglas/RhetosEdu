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
    public class MonitoredRecordMacro : IConceptMacro<MonitoredRecordInfo>
    {
        public IEnumerable<IConceptInfo> CreateNewConcepts(MonitoredRecordInfo conceptInfo, IDslModel existingConcepts)
        {
            var createdAtPropertyInfo = new DateTimePropertyInfo
            {
                DataStructure = conceptInfo.Entity,
                Name = "CreatedAt"
            };

            var creationTimePropertyInfo = new CreationTimeInfo { Property = createdAtPropertyInfo };
            var denyUserEditPropertyInfo = new DenyUserEditPropertyInfo { Property = createdAtPropertyInfo };

            var loggingPropertyInfo = new EntityLoggingInfo
            {
                Entity = conceptInfo.Entity
            };

            var allPropertiesLoggingInfo = new AllPropertiesLoggingInfo { EntityLogging = loggingPropertyInfo };

            return new IConceptInfo[]
            {
                createdAtPropertyInfo, creationTimePropertyInfo, denyUserEditPropertyInfo, loggingPropertyInfo,allPropertiesLoggingInfo
            };
        }
    }
}
