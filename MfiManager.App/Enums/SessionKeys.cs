﻿using System.ComponentModel;

namespace MfiManager.App.Enums {
    public enum SessionKeys {

        [Description("current_user")]
        CurrentUser,

        [Description("workspace")]
        Workspace,

        [Description("branch")]
        Branch,
        
        [Description("user_prefference")]
        UserPreferences,
        
        [Description("favorites")]
        Favorites,

        [Description("permissions")]
        Permissions,

        [Description("last_activity")]
        LastActivity,

        [Description("theme")]
        Theme,

        [Description("language")]
        Language,
        
        [Description("RecentItems")]
        RecentItems 
    }
}
