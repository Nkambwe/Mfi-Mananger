namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {
    public class GroupConfigurationParameter : CustomerConfigurationParameter,IConfigurationParameter  {
        
        /// <summary>
        /// Get/Set whether to treat group members as individuals not as a group when transacting
        /// </summary>
        public bool GroupMembersAsIndividuals { get; set; } = false;

        /// <summary>
        /// Get/Set custom group filter name 1
        /// </summary>
        public string GroupFilter1Name { get; set; } = "Group Filter 1";

        /// <summary>
        /// Get/Set whether custom group filter 1 is required
        /// </summary>
        public bool RequireGroupFilter1 { get; set; }

        /// <summary>
        /// Get/Set custom group member filter name 2
        /// </summary>
        public string GroupFilter2Name { get; set; } = "Group Filter 2";

        /// <summary>
        /// Get/Set whether custom group filter 2 is required
        /// </summary>
        public bool RequireGroupFilter2 { get; set; }

        /// <summary>
        /// Get/Set custom group member filter name 1
        /// </summary>
        public string MemberFilter1Name { get; set; } = "Member Filter 1";

        /// <summary>
        /// Get/Set whether custom group member filter 1 is required
        /// </summary>
        public bool RequireMemberFilter1 { get; set; }

        /// <summary>
        /// Get/Set custom group member filter name 2
        /// </summary>
        public string MemberFilter2Name { get; set; } = "Member Filter 2";

        /// <summary>
        /// Get/Set whether custom group member filter 2 is required
        /// </summary>
        public bool RequireMemberFilter2 { get; set; }
        /// <summary>
        /// Enable use of clusters
        /// </summary>
        public bool EnableClusters { get; set; } = false;
        /// <summary>
        /// Allow clusters to behave as separate groups
        /// </summary>
        public bool ClustersAsGroups { get; set; } = false;
        /// <summary>
        /// Get the maximum number of members a cluster can have
        /// </summary>
        public int MaximumClusterMembers { get; set; } = 10;

        public string GroupClientMailMerge { get; set; }

        public string GroupMemberMailMerge { get; set; }

        public int GroupMembersMaximum { get; set; } = 10;

    }
}
