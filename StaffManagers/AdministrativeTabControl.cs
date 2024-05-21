using System;
namespace StaffManagers
{
    public static class AdministrativeTabControl
    {
        private static bool tabUserAccount;

        private static bool tabDashboard;

        private static bool tabEmployee;

        private static bool tabLogView;

        private static bool tabSettings;

        private static bool tabFeedback;

        public static bool TabUserAccount
        {
            get { return tabUserAccount; }
            set
            {
                tabUserAccount = value;
                tabDashboard = false;
                tabEmployee = false;
                tabLogView = false;
                tabSettings = false;
                tabFeedback = false;
            }
        }

        public static bool TabDashboard
        {
            get { return tabDashboard; }
            set
            {
                tabUserAccount = false;
                tabDashboard = value;
                tabEmployee = false;
                tabLogView = false;
                tabSettings = false;
                tabFeedback = false;
            }
        }

        public static bool TabEmployee
        {
            get { return tabEmployee; }
            set
            {
                tabUserAccount = false;
                tabDashboard = false;
                tabEmployee = value;
                tabLogView = false;
                tabSettings = false;
                tabFeedback = false;
            }
        }

        public static bool TabLogView
        {
            get { return tabLogView; }
            set
            {
                tabUserAccount = false;
                tabDashboard = false;
                tabEmployee = false;
                tabLogView = value;
                tabSettings = false;
                tabFeedback = false;
            }
        }

        public static bool TabSettings
        {
            get { return tabSettings; }
            set
            {
                tabUserAccount = false;
                tabDashboard = false;
                tabEmployee = false;
                tabLogView = false;
                tabSettings = value;
                tabFeedback = false;
            }
        }

        public static bool TabFeedback
        {
            get { return tabFeedback; }
            set
            {
                tabUserAccount = false;
                tabDashboard = false;
                tabEmployee = false;
                tabLogView = false;
                tabSettings = false;
                tabFeedback = value;
            }
        }
    }
}
