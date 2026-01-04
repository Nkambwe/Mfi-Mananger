using MfiManager.Middleware.Data.Helpers;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {
    public class GroupCustomerConfigurationParameter : IConfigurationParameter {
        [ConfigParam(name: "MaximumNumberOfGroupMembers", description: "Maximum number of members allowed in a single group", paramType: "int")]
        public string MaximumNumberOfGroupMembers { get; set; }
        [ConfigParam(name: "TreatGroupMembersAsIndividualClients", description: "Check  whether to treat group members as individuals not as a group when transacting", paramType: "bool")]
        public string TreatGroupMembersAsIndividualClients { get; set; }
        [ConfigParam(name: "GroupFilter1Name", description: "Custome group filter 1 name", paramType: "string")]
        public string GroupFilter1Name { get; set; }
        [ConfigParam(name: "RequireGroupFilter1", description: "Check whether group filter 1 is required", paramType: "bool")]
        public string RequireGroupFilter1 { get; set; }
        [ConfigParam(name: "GroupFilter2Name", description: "Custome group filter 2 name", paramType: "string")]
        public string GroupFilter2Name { get; set; }
        [ConfigParam(name: "RequireGroupFilter2", description: "Check whether group filter 2 is required", paramType: "bool")]
        public string RequireGroupFilter2 { get; set; }
        [ConfigParam(name: "EnableClusters", description: "Check whether group clustering is enabled", paramType: "bool")]
        public string EnableClusters { get; set; }
        [ConfigParam(name: "ClustersAsGroups", description: "Check  whether to treat group clusters as separate groups when transacting", paramType: "bool")]
        public string ClustersAsGroups { get; set; }
        [ConfigParam(name: "MaximumClusterMembers", description: "Maximum number of members allowed in a single cluster", paramType: "int")]
        public string MaximumClusterMembers { get; set; }
        [ConfigParam(name: "GroupMailMergeUrl", description: "Storage directory for group mail merged files", paramType:"string")]
        public string GroupMailMergeUrl { get; set; }
        [ConfigParam(name: "GroupmemberMailMergeUrl", description: "Storage directory for group members mail merged files", paramType:"string")]
        public string GroupmemberMailMergeUrl { get; set; }
     }

}
