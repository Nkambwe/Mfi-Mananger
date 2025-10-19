﻿namespace MfiManager.App.Models {

    public class CurrentUserModel {
        public long UserId { get; set; }
        public string PersonnelFileNumber { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }

}
