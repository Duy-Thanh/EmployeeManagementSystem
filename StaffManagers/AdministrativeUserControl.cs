using StaffManagers.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace StaffManagers
{
    public partial class AdministrativeUserControl : UserControl
    {
        public AdministrativeUserControl()
        {
            InitializeComponent();

            // Form Load event handler
            this.Load += AdministrativeUserControl_Load;

            userAccountEditor.Click += UserAccountEditor_Click;
            switchToDashboard.Click += SwitchToDashboard_Click;
            employeeManagement.Click += EmployeeManagement_Click;
            logView.Click += LogView_Click;
            appSettings.Click += AppSettings_Click;
            feedbackTab.Click += FeedbackTab_Click;

            ElipseControl elipsePanel2 = new ElipseControl();
            elipsePanel2.TargetControl = panel2;
            elipsePanel2.CornerRadius = 50;

            userAccountEditor.ClickIcon += UserAccountEditor_ClickIcon;
            userAccountEditor.ClickTitle += UserAccountEditor_ClickTitle;

            userAccountEditor.MouseEnter += UserAccountEditor_MouseEnter;
            userAccountEditor.MouseLeave += UserAccountEditor_MouseLeave;

            userAccountEditor.MouseEnterIcon += UserAccountEditor_MouseEnterIcon;
            userAccountEditor.MouseLeaveIcon += UserAccountEditor_MouseLeaveIcon;

            userAccountEditor.MouseEnterTitle += UserAccountEditor_MouseEnterTitle;
            userAccountEditor.MouseLeaveTitle += UserAccountEditor_MouseLeaveTitle;

            switchToDashboard.ClickIcon += SwitchToDashboard_ClickIcon;
            switchToDashboard.ClickTitle += SwitchToDashboard_ClickTitle;

            switchToDashboard.MouseEnter += SwitchToDashboard_MouseEnter;
            switchToDashboard.MouseLeave += SwitchToDashboard_MouseLeave;

            switchToDashboard.MouseEnterIcon += SwitchToDashboard_MouseEnterIcon;
            switchToDashboard.MouseLeaveIcon += SwitchToDashboard_MouseLeaveIcon;

            switchToDashboard.MouseEnterTitle += SwitchToDashboard_MouseEnterTitle;
            switchToDashboard.MouseLeaveTitle += SwitchToDashboard_MouseLeaveTitle;

            employeeManagement.MouseEnter += EmployeeManagement_MouseEnter;
            employeeManagement.MouseLeave += EmployeeManagement_MouseLeave;

            employeeManagement.MouseEnterIcon += EmployeeManagement_MouseEnterIcon;
            employeeManagement.MouseLeaveIcon += EmployeeManagement_MouseLeaveIcon;

            employeeManagement.MouseEnterTitle += EmployeeManagement_MouseEnterTitle;
            employeeManagement.MouseLeaveTitle += EmployeeManagement_MouseLeaveTitle;

            employeeManagement.ClickIcon += EmployeeManagement_ClickIcon;
            employeeManagement.ClickTitle += EmployeeManagement_ClickTitle;

            logView.MouseEnter += LogView_MouseEnter;
            logView.MouseLeave += LogView_MouseLeave;

            logView.MouseEnterIcon += LogView_MouseEnterIcon;
            logView.MouseLeaveIcon += LogView_MouseLeaveIcon;

            logView.MouseEnterTitle += LogView_MouseEnterTitle;
            logView.MouseLeaveTitle += LogView_MouseLeaveTitle;

            logView.ClickIcon += LogView_ClickIcon;
            logView.ClickTitle += LogView_ClickTitle;

            appSettings.MouseEnter += AppSettings_MouseEnter;
            appSettings.MouseLeave += AppSettings_MouseLeave;

            appSettings.MouseEnterIcon += AppSettings_MouseEnterIcon;
            appSettings.MouseLeaveIcon += AppSettings_MouseLeaveIcon;

            appSettings.MouseEnterTitle += AppSettings_MouseEnterTitle;
            appSettings.MouseLeaveTitle += AppSettings_MouseLeaveTitle;

            appSettings.ClickIcon += AppSettings_ClickIcon;
            appSettings.ClickTitle += AppSettings_ClickTitle;

            feedbackTab.MouseEnter += FeedbackTab_MouseEnter;
            feedbackTab.MouseLeave += FeedbackTab_MouseLeave;

            feedbackTab.MouseEnterIcon += FeedbackTab_MouseEnterIcon;
            feedbackTab.MouseLeaveIcon += FeedbackTab_MouseLeaveIcon;

            feedbackTab.MouseEnterTitle += FeedbackTab_MouseEnterTitle;
            feedbackTab.MouseLeaveTitle += FeedbackTab_MouseLeaveTitle;

            feedbackTab.ClickIcon += FeedbackTab_ClickIcon;
            feedbackTab.ClickTitle += FeedbackTab_ClickTitle;

            DashboardUserControl dashboardPanel = new DashboardUserControl();
            panel2.Controls.Add(dashboardPanel);

            this.Load += AdministrativeUserControl_Load1;
        }

        private void FeedbackTab_ClickTitle(object sender, EventArgs e)
        {
            if (feedbackTab.IsClicked) return;
            else
            {
                AdministrativeTabControl.TabFeedback = true;

                feedbackTab.IsClicked = true;
                userAccountEditor.IsClicked = switchToDashboard.IsClicked = employeeManagement.IsClicked = logView.IsClicked = appSettings.IsClicked = false;
                feedbackTab.BackColor = Color.FromArgb(120, 255, 255, 255);

                switchToDashboard.BackColor = Color.Transparent;
                employeeManagement.BackColor = Color.Transparent;
                logView.BackColor = Color.Transparent;
                appSettings.BackColor = Color.Transparent;
                userAccountEditor.BackColor = Color.Transparent;
            }
        }

        private void FeedbackTab_ClickIcon(object sender, EventArgs e)
        {
            if (feedbackTab.IsClicked) return;
            else
            {
                AdministrativeTabControl.TabFeedback = true;

                feedbackTab.IsClicked = true;
                userAccountEditor.IsClicked = switchToDashboard.IsClicked = employeeManagement.IsClicked = logView.IsClicked = appSettings.IsClicked = false;
                feedbackTab.BackColor = Color.FromArgb(120, 255, 255, 255);

                switchToDashboard.BackColor = Color.Transparent;
                employeeManagement.BackColor = Color.Transparent;
                logView.BackColor = Color.Transparent;
                appSettings.BackColor = Color.Transparent;
                userAccountEditor.BackColor = Color.Transparent;
            }
        }

        private void AppSettings_ClickTitle(object sender, EventArgs e)
        {
            if (appSettings.IsClicked) return;
            else
            {
                AdministrativeTabControl.TabSettings = true;

                appSettings.IsClicked = true;
                userAccountEditor.IsClicked = switchToDashboard.IsClicked = employeeManagement.IsClicked = logView.IsClicked = feedbackTab.IsClicked = false;
                appSettings.BackColor = Color.FromArgb(120, 255, 255, 255);

                switchToDashboard.BackColor = Color.Transparent;
                employeeManagement.BackColor = Color.Transparent;
                logView.BackColor = Color.Transparent;
                userAccountEditor.BackColor = Color.Transparent;
                feedbackTab.BackColor = Color.Transparent;

                SettingsUC settings = new SettingsUC();
                settings.Dock = DockStyle.Fill;

                settings.Visible = true;
                settings.Enabled = true;

                panel2.Controls.Clear();
                panel2.Controls.Add(settings);
            }
        }

        private void AppSettings_ClickIcon(object sender, EventArgs e)
        {
            if (appSettings.IsClicked) return;
            else
            {
                AdministrativeTabControl.TabSettings = true;

                appSettings.IsClicked = true;
                userAccountEditor.IsClicked = switchToDashboard.IsClicked = employeeManagement.IsClicked = logView.IsClicked = feedbackTab.IsClicked = false;
                appSettings.BackColor = Color.FromArgb(120, 255, 255, 255);

                switchToDashboard.BackColor = Color.Transparent;
                employeeManagement.BackColor = Color.Transparent;
                logView.BackColor = Color.Transparent;
                userAccountEditor.BackColor = Color.Transparent;
                feedbackTab.BackColor = Color.Transparent;

                SettingsUC settings = new SettingsUC();
                settings.Dock = DockStyle.Fill;

                settings.Visible = true;
                settings.Enabled = true;

                panel2.Controls.Clear();
                panel2.Controls.Add(settings);
            }
        }

        private void LogView_ClickTitle(object sender, EventArgs e)
        {
            if (logView.IsClicked) return;
            else
            {
                AdministrativeTabControl.TabLogView = true;
                logView.IsClicked = true;
                userAccountEditor.IsClicked = switchToDashboard.IsClicked = employeeManagement.IsClicked = appSettings.IsClicked = feedbackTab.IsClicked = false;

                logView.BackColor = Color.FromArgb(120, 255, 255, 255);

                switchToDashboard.BackColor = Color.Transparent;
                employeeManagement.BackColor = Color.Transparent;
                userAccountEditor.BackColor = Color.Transparent;
                appSettings.BackColor = Color.Transparent;
                feedbackTab.BackColor = Color.Transparent;

                ActivityViewer activityViewer = new ActivityViewer();
                activityViewer.Dock = DockStyle.Fill;

                activityViewer.Visible = true;
                activityViewer.Enabled = true;

                panel2.Controls.Clear();
                panel2.Controls.Add(activityViewer);
            }
        }

        private void LogView_ClickIcon(object sender, EventArgs e)
        {
            if (logView.IsClicked) return;
            else
            {
                AdministrativeTabControl.TabLogView = true;
                logView.IsClicked = true;
                userAccountEditor.IsClicked = switchToDashboard.IsClicked = employeeManagement.IsClicked = appSettings.IsClicked = feedbackTab.IsClicked = false;

                logView.BackColor = Color.FromArgb(120, 255, 255, 255);

                switchToDashboard.BackColor = Color.Transparent;
                employeeManagement.BackColor = Color.Transparent;
                userAccountEditor.BackColor = Color.Transparent;
                appSettings.BackColor = Color.Transparent;
                feedbackTab.BackColor = Color.Transparent;

                ActivityViewer activityViewer = new ActivityViewer();
                activityViewer.Dock = DockStyle.Fill;

                activityViewer.Visible = true;
                activityViewer.Enabled = true;

                panel2.Controls.Clear();
                panel2.Controls.Add(activityViewer);
            }
        }

        private void EmployeeManagement_ClickTitle(object sender, EventArgs e)
        {
            if (employeeManagement.IsClicked) return;
            else
            {
                AdministrativeTabControl.TabEmployee = true;
                employeeManagement.IsClicked = true;
                userAccountEditor.IsClicked = switchToDashboard.IsClicked = logView.IsClicked = appSettings.IsClicked = feedbackTab.IsClicked = false;

                employeeManagement.BackColor = Color.FromArgb(120, 255, 255, 255);

                switchToDashboard.BackColor = Color.Transparent;
                userAccountEditor.BackColor = Color.Transparent;
                logView.BackColor = Color.Transparent;
                appSettings.BackColor = Color.Transparent;
                feedbackTab.BackColor = Color.Transparent;

                EmployeeManagerUserControl employeeManager = new EmployeeManagerUserControl();
                employeeManager.Dock = DockStyle.Fill;
                employeeManager.Visible = true;
                employeeManager.Enabled = true;

                panel2.Controls.Clear();
                panel2.Controls.Add(employeeManager);
            }
        }

        private void EmployeeManagement_ClickIcon(object sender, EventArgs e)
        {
            if (employeeManagement.IsClicked) return;
            else
            {
                AdministrativeTabControl.TabEmployee = true;
                employeeManagement.IsClicked = true;
                userAccountEditor.IsClicked = switchToDashboard.IsClicked = logView.IsClicked = appSettings.IsClicked = feedbackTab.IsClicked = false;

                employeeManagement.BackColor = Color.FromArgb(120, 255, 255, 255);

                switchToDashboard.BackColor = Color.Transparent;
                userAccountEditor.BackColor = Color.Transparent;
                logView.BackColor = Color.Transparent;
                appSettings.BackColor = Color.Transparent;
                feedbackTab.BackColor = Color.Transparent;

                EmployeeManagerUserControl employeeManager = new EmployeeManagerUserControl();
                employeeManager.Dock = DockStyle.Fill;
                employeeManager.Visible = true;
                employeeManager.Enabled = true;

                panel2.Controls.Clear();
                panel2.Controls.Add(employeeManager);
            }
        }

        private void SwitchToDashboard_ClickTitle(object sender, EventArgs e)
        {
            if (switchToDashboard.IsClicked) return;
            else
            {
                AdministrativeTabControl.TabDashboard = true;

                switchToDashboard.IsClicked = true;
                userAccountEditor.IsClicked = employeeManagement.IsClicked = logView.IsClicked = appSettings.IsClicked = feedbackTab.IsClicked = false;
                switchToDashboard.BackColor = Color.FromArgb(120, 255, 255, 255);

                userAccountEditor.BackColor = Color.Transparent;
                employeeManagement.BackColor = Color.Transparent;
                logView.BackColor = Color.Transparent;
                appSettings.BackColor = Color.Transparent;
                feedbackTab.BackColor = Color.Transparent;

                DashboardUserControl dashboard = new DashboardUserControl();
                dashboard.Dock = DockStyle.Fill;

                dashboard.Enabled = true;
                dashboard.Visible = true;

                panel2.Controls.Clear();
                panel2.Controls.Add(dashboard);

            }
        }

        private void SwitchToDashboard_ClickIcon(object sender, EventArgs e)
        {
            if (switchToDashboard.IsClicked) return;
            else
            {
                AdministrativeTabControl.TabDashboard = true;

                switchToDashboard.IsClicked = true;
                userAccountEditor.IsClicked = employeeManagement.IsClicked = logView.IsClicked = appSettings.IsClicked = feedbackTab.IsClicked = false;
                switchToDashboard.BackColor = Color.FromArgb(120, 255, 255, 255);

                userAccountEditor.BackColor = Color.Transparent;
                employeeManagement.BackColor = Color.Transparent;
                logView.BackColor = Color.Transparent;
                appSettings.BackColor = Color.Transparent;
                feedbackTab.BackColor = Color.Transparent;

                DashboardUserControl dashboard = new DashboardUserControl();
                dashboard.Dock = DockStyle.Fill;

                dashboard.Enabled = true;
                dashboard.Visible = true;

                panel2.Controls.Clear();
                panel2.Controls.Add(dashboard);

            }
        }

        private void UserAccountEditor_ClickTitle(object sender, EventArgs e)
        {
            if (userAccountEditor.IsClicked) return;
            else
            {
                AdministrativeTabControl.TabUserAccount = true;

                userAccountEditor.IsClicked = true;
                switchToDashboard.IsClicked = employeeManagement.IsClicked = logView.IsClicked = appSettings.IsClicked = feedbackTab.IsClicked = false;
                userAccountEditor.BackColor = Color.FromArgb(120, 255, 255, 255);

                switchToDashboard.BackColor = Color.Transparent;
                employeeManagement.BackColor = Color.Transparent;
                logView.BackColor = Color.Transparent;
                appSettings.BackColor = Color.Transparent;
                feedbackTab.BackColor = Color.Transparent;
            }
        }

        private void UserAccountEditor_ClickIcon(object sender, EventArgs e)
        {
            if (userAccountEditor.IsClicked) return;
            else
            {
                AdministrativeTabControl.TabUserAccount = true;

                userAccountEditor.IsClicked = true;
                switchToDashboard.IsClicked = employeeManagement.IsClicked = logView.IsClicked = appSettings.IsClicked = feedbackTab.IsClicked = false;
                userAccountEditor.BackColor = Color.FromArgb(120, 255, 255, 255);

                switchToDashboard.BackColor = Color.Transparent;
                employeeManagement.BackColor = Color.Transparent;
                logView.BackColor = Color.Transparent;
                appSettings.BackColor = Color.Transparent;
                feedbackTab.BackColor = Color.Transparent;
            }
        }

        private void FeedbackTab_MouseLeaveTitle(object sender, EventArgs e)
        {
            if (feedbackTab.IsClicked)
            {
                feedbackTab.BackColor = Color.FromArgb(120, 255, 255, 255);
                feedbackTab.Icon_BackColor = Color.Transparent;
                feedbackTab.Title_BackColor = Color.Transparent;
            }
            else
            {
                feedbackTab.BackColor = Color.Transparent;
                feedbackTab.Icon_BackColor = Color.Transparent;
                feedbackTab.Title_BackColor = Color.Transparent;
            }
        }

        private void FeedbackTab_MouseEnterTitle(object sender, EventArgs e)
        {
            if (feedbackTab.IsClicked)
            {
                feedbackTab.BackColor = Color.FromArgb(120, 255, 255, 255);
                feedbackTab.Icon_BackColor = Color.Transparent;
                feedbackTab.Title_BackColor = Color.Transparent;
            }
            else
            {
                feedbackTab.BackColor = Color.FromArgb(120, 255, 255, 255);
                feedbackTab.Icon_BackColor = Color.Transparent;
                feedbackTab.Title_BackColor = Color.Transparent;
            }
        }

        private void FeedbackTab_MouseLeaveIcon(object sender, EventArgs e)
        {
            if (feedbackTab.IsClicked)
            {
                feedbackTab.BackColor = Color.FromArgb(120, 255, 255, 255);
                feedbackTab.Icon_BackColor = Color.Transparent;
                feedbackTab.Title_BackColor = Color.Transparent;
            }
            else
            {
                feedbackTab.BackColor = Color.Transparent;
                feedbackTab.Icon_BackColor = Color.Transparent;
                feedbackTab.Title_BackColor = Color.Transparent;
            }
        }

        private void FeedbackTab_MouseEnterIcon(object sender, EventArgs e)
        {
            if (feedbackTab.IsClicked)
            {
                feedbackTab.BackColor = Color.FromArgb(120, 255, 255, 255);
                feedbackTab.Icon_BackColor = Color.Transparent;
                feedbackTab.Title_BackColor = Color.Transparent;
            }
            else
            {
                feedbackTab.BackColor = Color.FromArgb(120, 255, 255, 255);
                feedbackTab.Icon_BackColor = Color.Transparent;
                feedbackTab.Title_BackColor = Color.Transparent;
            }
        }

        private void AppSettings_MouseLeaveTitle(object sender, EventArgs e)
        {
            if (appSettings.IsClicked)
            {
                appSettings.BackColor = Color.FromArgb(120, 255, 255, 255);
                appSettings.Icon_BackColor = Color.Transparent;
                appSettings.Title_BackColor = Color.Transparent;
            }
            else
            {
                appSettings.BackColor = Color.Transparent;
                appSettings.Icon_BackColor = Color.Transparent;
                appSettings.Title_BackColor = Color.Transparent;
            }
        }

        private void AppSettings_MouseEnterTitle(object sender, EventArgs e)
        {
            if (appSettings.IsClicked)
            {
                appSettings.BackColor = Color.FromArgb(120, 255, 255, 255);
                appSettings.Icon_BackColor = Color.Transparent;
                appSettings.Title_BackColor = Color.Transparent;
            }
            else
            {
                appSettings.BackColor = Color.FromArgb(120, 255, 255, 255);
                appSettings.Icon_BackColor = Color.Transparent;
                appSettings.Title_BackColor = Color.Transparent;
            }
        }

        private void AppSettings_MouseLeaveIcon(object sender, EventArgs e)
        {
            if (appSettings.IsClicked)
            {
                appSettings.BackColor = Color.FromArgb(120, 255, 255, 255);
                appSettings.Icon_BackColor = Color.Transparent;
                appSettings.Title_BackColor = Color.Transparent;
            }
            else
            {
                appSettings.BackColor = Color.Transparent;
                appSettings.Icon_BackColor = Color.Transparent;
                appSettings.Title_BackColor = Color.Transparent;
            }
        }

        private void AppSettings_MouseEnterIcon(object sender, EventArgs e)
        {
            if (appSettings.IsClicked)
            {
                appSettings.BackColor = Color.FromArgb(120, 255, 255, 255);
                appSettings.Icon_BackColor = Color.Transparent;
                appSettings.Title_BackColor = Color.Transparent;
            }
            else
            {
                appSettings.BackColor = Color.FromArgb(120, 255, 255, 255);
                appSettings.Icon_BackColor = Color.Transparent;
                appSettings.Title_BackColor = Color.Transparent;
            }
        }

        private void LogView_MouseLeaveTitle(object sender, EventArgs e)
        {
            if (logView.IsClicked)
            {
                logView.BackColor = Color.FromArgb(120, 255, 255, 255);
                logView.Icon_BackColor = Color.Transparent;
                logView.Title_BackColor = Color.Transparent;
            }
            else
            {
                logView.BackColor = Color.Transparent;
                logView.Icon_BackColor = Color.Transparent;
                logView.Title_BackColor = Color.Transparent;
            }
        }

        private void LogView_MouseEnterTitle(object sender, EventArgs e)
        {
            if (logView.IsClicked)
            {
                logView.BackColor = Color.FromArgb(120, 255, 255, 255);
                logView.Icon_BackColor = Color.Transparent;
                logView.Title_BackColor = Color.Transparent;
            }
            else
            {
                logView.BackColor = Color.FromArgb(120, 255, 255, 255);
                logView.Icon_BackColor = Color.Transparent;
                logView.Title_BackColor = Color.Transparent;
            }
        }

        private void LogView_MouseLeaveIcon(object sender, EventArgs e)
        {
            if (logView.IsClicked)
            {
                logView.BackColor = Color.FromArgb(120, 255, 255, 255);
                logView.Icon_BackColor = Color.Transparent;
                logView.Title_BackColor = Color.Transparent;
            }
            else
            {
                logView.BackColor = Color.Transparent;
                logView.Icon_BackColor = Color.Transparent;
                logView.Title_BackColor = Color.Transparent;
            }
        }

        private void LogView_MouseEnterIcon(object sender, EventArgs e)
        {
            if (logView.IsClicked)
            {
                logView.BackColor = Color.FromArgb(120, 255, 255, 255);
                logView.Icon_BackColor = Color.Transparent;
                logView.Title_BackColor = Color.Transparent;
            }
            else
            {
                logView.BackColor = Color.FromArgb(120, 255, 255, 255);
                logView.Icon_BackColor = Color.Transparent;
                logView.Title_BackColor = Color.Transparent;
            }
        }

        private void EmployeeManagement_MouseLeaveTitle(object sender, EventArgs e)
        {
            if (employeeManagement.IsClicked)
            {
                employeeManagement.BackColor = Color.FromArgb(120, 255, 255, 255);
                employeeManagement.Icon_BackColor = Color.Transparent;
                employeeManagement.Title_BackColor = Color.Transparent;
            }
            else
            {
                employeeManagement.BackColor = Color.Transparent;
                employeeManagement.Icon_BackColor = Color.Transparent;
                employeeManagement.Title_BackColor = Color.Transparent;
            }
        }

        private void EmployeeManagement_MouseEnterTitle(object sender, EventArgs e)
        {
            if (employeeManagement.IsClicked)
            {
                employeeManagement.BackColor = Color.FromArgb(120, 255, 255, 255);
                employeeManagement.Icon_BackColor = Color.Transparent;
                employeeManagement.Title_BackColor = Color.Transparent;
            }
            else
            {
                employeeManagement.BackColor = Color.FromArgb(120, 255, 255, 255);
                employeeManagement.Icon_BackColor = Color.Transparent;
                employeeManagement.Title_BackColor = Color.Transparent;
            }
        }

        private void EmployeeManagement_MouseLeaveIcon(object sender, EventArgs e)
        {
            if (employeeManagement.IsClicked)
            {
                employeeManagement.BackColor = Color.FromArgb(120, 255, 255, 255);
                employeeManagement.Icon_BackColor = Color.Transparent;
                employeeManagement.Title_BackColor = Color.Transparent;
            }
            else
            {
                employeeManagement.BackColor = Color.Transparent;
                employeeManagement.Icon_BackColor = Color.Transparent;
                employeeManagement.Title_BackColor = Color.Transparent;
            }
        }

        private void EmployeeManagement_MouseEnterIcon(object sender, EventArgs e)
        {
            if (employeeManagement.IsClicked)
            {
                employeeManagement.BackColor = Color.FromArgb(120, 255, 255, 255);
                employeeManagement.Icon_BackColor = Color.Transparent;
                employeeManagement.Title_BackColor = Color.Transparent;
            }
            else
            {
                employeeManagement.BackColor = Color.FromArgb(120, 255, 255, 255);
                employeeManagement.Icon_BackColor = Color.Transparent;
                employeeManagement.Title_BackColor = Color.Transparent;
            }

        }

        private void SwitchToDashboard_MouseLeaveTitle(object sender, EventArgs e)
        {
            if (switchToDashboard.IsClicked)
            {
                switchToDashboard.BackColor = Color.FromArgb(120, 255, 255, 255);
                switchToDashboard.Icon_BackColor = Color.Transparent;
                switchToDashboard.Title_BackColor = Color.Transparent;
            }
            else
            {
                switchToDashboard.BackColor = Color.Transparent;
                switchToDashboard.Icon_BackColor = Color.Transparent;
                switchToDashboard.Title_BackColor = Color.Transparent;
            }
        }

        private void SwitchToDashboard_MouseEnterTitle(object sender, EventArgs e)
        {
            if (switchToDashboard.IsClicked)
            {
                switchToDashboard.BackColor = Color.FromArgb(120, 255, 255, 255);
                switchToDashboard.Icon_BackColor = Color.Transparent;
                switchToDashboard.Title_BackColor = Color.Transparent;
            }
            else
            {
                switchToDashboard.BackColor = Color.FromArgb(120, 255, 255, 255);
                switchToDashboard.Icon_BackColor = Color.Transparent;
                switchToDashboard.Title_BackColor = Color.Transparent;
            }
        }

        private void SwitchToDashboard_MouseLeaveIcon(object sender, EventArgs e)
        {
            if (switchToDashboard.IsClicked)
            {
                switchToDashboard.BackColor = Color.FromArgb(120, 255, 255, 255);
                switchToDashboard.Icon_BackColor = Color.Transparent;
                switchToDashboard.Title_BackColor = Color.Transparent;
            }
            else
            {
                switchToDashboard.BackColor = Color.Transparent;
                switchToDashboard.Icon_BackColor = Color.Transparent;
                switchToDashboard.Title_BackColor = Color.Transparent;
            }
        }

        private void SwitchToDashboard_MouseEnterIcon(object sender, EventArgs e)
        {
            if (switchToDashboard.IsClicked)
            {
                switchToDashboard.BackColor = Color.FromArgb(120, 255, 255, 255);
                switchToDashboard.Icon_BackColor = Color.Transparent;
                switchToDashboard.Title_BackColor = Color.Transparent;
            }
            else
            {
                switchToDashboard.BackColor = Color.FromArgb(120, 255, 255, 255);
                switchToDashboard.Icon_BackColor = Color.Transparent;
                switchToDashboard.Title_BackColor = Color.Transparent;
            }
        }

        private void UserAccountEditor_MouseLeaveTitle(object sender, EventArgs e)
        {
            if (userAccountEditor.IsClicked)
            {
                userAccountEditor.BackColor = Color.FromArgb(120, 255, 255, 255);
                userAccountEditor.Icon_BackColor = Color.Transparent;
                userAccountEditor.Title_BackColor = Color.Transparent;
            }
            else
            {
                userAccountEditor.BackColor = Color.Transparent;
                userAccountEditor.Icon_BackColor = Color.Transparent;
                userAccountEditor.Title_BackColor = Color.Transparent;
            }
        }

        private void UserAccountEditor_MouseEnterTitle(object sender, EventArgs e)
        {
            if (userAccountEditor.IsClicked)
            {
                userAccountEditor.BackColor = Color.FromArgb(120, 255, 255, 255);
                userAccountEditor.Icon_BackColor = Color.Transparent;
                userAccountEditor.Title_BackColor = Color.Transparent;
            }
            else
            {
                userAccountEditor.BackColor = Color.FromArgb(120, 255, 255, 255);
                userAccountEditor.Icon_BackColor = Color.Transparent;
                userAccountEditor.Title_BackColor = Color.Transparent;
            }
        }

        private void UserAccountEditor_MouseLeaveIcon(object sender, EventArgs e)
        {
            if (userAccountEditor.IsClicked)
            {
                userAccountEditor.BackColor = Color.FromArgb(120, 255, 255, 255);
                userAccountEditor.Icon_BackColor = Color.Transparent;
                userAccountEditor.Title_BackColor = Color.Transparent;
            }
            else
            {
                userAccountEditor.BackColor = Color.Transparent;
                userAccountEditor.Icon_BackColor = Color.Transparent;
                userAccountEditor.Title_BackColor = Color.Transparent;
            }
        }

        private void UserAccountEditor_MouseEnterIcon(object sender, EventArgs e)
        {
            if (userAccountEditor.IsClicked)
            {
                userAccountEditor.BackColor = Color.FromArgb(120, 255, 255, 255);
                userAccountEditor.Icon_BackColor = Color.Transparent;
                userAccountEditor.Title_BackColor = Color.Transparent;
            }
            else
            {
                userAccountEditor.BackColor = Color.FromArgb(120, 255, 255, 255);
                userAccountEditor.Icon_BackColor = Color.Transparent;
                userAccountEditor.Title_BackColor = Color.Transparent;
            }
        }

        private void FeedbackTab_MouseLeave(object sender, EventArgs e)
        {
            if (feedbackTab.IsClicked)
            {
                feedbackTab.BackColor = Color.FromArgb(120, 255, 255, 255);
                feedbackTab.Icon_BackColor = Color.Transparent;
                feedbackTab.Title_BackColor = Color.Transparent;
            }
            else
            {
                feedbackTab.BackColor = Color.Transparent;
                feedbackTab.Icon_BackColor = Color.Transparent;
                feedbackTab.Title_BackColor = Color.Transparent;
            }
        }

        private void FeedbackTab_MouseEnter(object sender, EventArgs e)
        {
            if (feedbackTab.IsClicked)
            {
                feedbackTab.BackColor = Color.FromArgb(120, 255, 255, 255);
                feedbackTab.Icon_BackColor = Color.Transparent;
                feedbackTab.Title_BackColor = Color.Transparent;
            }
            else
            {
                feedbackTab.BackColor = Color.FromArgb(120, 255, 255, 255);
                feedbackTab.Icon_BackColor = Color.Transparent;
                feedbackTab.Title_BackColor = Color.Transparent;
            }
        }

        private void FeedbackTab_Click(object sender, EventArgs e)
        {
            if (feedbackTab.IsClicked) return;
            else
            {
                AdministrativeTabControl.TabFeedback = true;

                feedbackTab.IsClicked = true;
                userAccountEditor.IsClicked = switchToDashboard.IsClicked = employeeManagement.IsClicked = logView.IsClicked = appSettings.IsClicked = false;
                feedbackTab.BackColor = Color.FromArgb(120, 255, 255, 255);

                switchToDashboard.BackColor = Color.Transparent;
                employeeManagement.BackColor = Color.Transparent;
                logView.BackColor = Color.Transparent;
                appSettings.BackColor = Color.Transparent;
                userAccountEditor.BackColor = Color.Transparent;
            }
        }

        private void AdministrativeUserControl_Load1(object sender, EventArgs e)
        {
            // Auto switch to dashboard
            AdministrativeTabControl.TabDashboard = true;

            switchToDashboard.IsClicked = true;
            userAccountEditor.IsClicked = employeeManagement.IsClicked = logView.IsClicked = appSettings.IsClicked = feedbackTab.IsClicked = false;
            switchToDashboard.BackColor = Color.FromArgb(120, 255, 255, 255);
            switchToDashboard.Icon_BackColor = Color.Transparent;
            switchToDashboard.Title_BackColor = Color.Transparent;

            userAccountEditor.BackColor = Color.Transparent;
            employeeManagement.BackColor = Color.Transparent;
            logView.BackColor = Color.Transparent;
            appSettings.BackColor = Color.Transparent;
            feedbackTab.BackColor = Color.Transparent;
        }

        private void AppSettings_MouseLeave(object sender, EventArgs e)
        {
            if (appSettings.IsClicked)
            {
                appSettings.BackColor = Color.FromArgb(120, 255, 255, 255);
                appSettings.Icon_BackColor = Color.Transparent;
                appSettings.Title_BackColor = Color.Transparent;
            }
            else
            {
                appSettings.BackColor = Color.Transparent;
                appSettings.Icon_BackColor = Color.Transparent;
                appSettings.Title_BackColor = Color.Transparent;
            }
        }

        private void AppSettings_MouseEnter(object sender, EventArgs e)
        {
            if (appSettings.IsClicked)
            {
                appSettings.BackColor = Color.FromArgb(120, 255, 255, 255);
                appSettings.Icon_BackColor = Color.Transparent;
                appSettings.Title_BackColor = Color.Transparent;
            }
            else
            {
                appSettings.BackColor = Color.FromArgb(120, 255, 255, 255);
                appSettings.Icon_BackColor = Color.Transparent;
                appSettings.Title_BackColor = Color.Transparent;
            }
        }

        private void LogView_MouseLeave(object sender, EventArgs e)
        {
            if (logView.IsClicked)
            {
                logView.BackColor = Color.FromArgb(120, 255, 255, 255);
                logView.Icon_BackColor = Color.Transparent;
                logView.Title_BackColor = Color.Transparent;
            }
            else
            {
                logView.BackColor = Color.Transparent;
                logView.Icon_BackColor = Color.Transparent;
                logView.Title_BackColor = Color.Transparent;
            }
        }

        private void LogView_MouseEnter(object sender, EventArgs e)
        {
            if (logView.IsClicked)
            {
                logView.BackColor = Color.FromArgb(120, 255, 255, 255);
                logView.Icon_BackColor = Color.Transparent;
                logView.Title_BackColor = Color.Transparent;
            }
            else
            {
                logView.BackColor = Color.FromArgb(120, 255, 255, 255);
                logView.Icon_BackColor = Color.Transparent;
                logView.Title_BackColor = Color.Transparent;
            }
        }

        private void EmployeeManagement_MouseLeave(object sender, EventArgs e)
        {
            if (employeeManagement.IsClicked)
            {
                employeeManagement.BackColor = Color.FromArgb(120, 255, 255, 255);
                employeeManagement.Icon_BackColor = Color.Transparent;
                employeeManagement.Title_BackColor = Color.Transparent;
            }
            else
            {
                employeeManagement.BackColor = Color.Transparent;
                employeeManagement.Icon_BackColor = Color.Transparent;
                employeeManagement.Title_BackColor = Color.Transparent;
            }
        }

        private void EmployeeManagement_MouseEnter(object sender, EventArgs e)
        {
            if (employeeManagement.IsClicked)
            {
                employeeManagement.BackColor = Color.FromArgb(120, 255, 255, 255);
                employeeManagement.Icon_BackColor = Color.Transparent;
                employeeManagement.Title_BackColor = Color.Transparent;
            }
            else
            {
                employeeManagement.BackColor = Color.FromArgb(120, 255, 255, 255);
                employeeManagement.Icon_BackColor = Color.Transparent;
                employeeManagement.Title_BackColor = Color.Transparent;
            }
        }

        private void SwitchToDashboard_MouseLeave(object sender, EventArgs e)
        {
            if (switchToDashboard.IsClicked)
            {
                switchToDashboard.BackColor = Color.FromArgb(120, 255, 255, 255);
                switchToDashboard.Icon_BackColor = Color.Transparent;
                switchToDashboard.Title_BackColor = Color.Transparent;
            }
            else
            {
                switchToDashboard.BackColor = Color.Transparent;
                switchToDashboard.Icon_BackColor = Color.Transparent;
                switchToDashboard.Title_BackColor = Color.Transparent;
            }
        }

        private void SwitchToDashboard_MouseEnter(object sender, EventArgs e)
        {
            if (switchToDashboard.IsClicked)
            {
                switchToDashboard.BackColor = Color.FromArgb(120, 255, 255, 255);
                switchToDashboard.Icon_BackColor = Color.Transparent;
                switchToDashboard.Title_BackColor = Color.Transparent;
            }
            else
            {
                switchToDashboard.BackColor = Color.FromArgb(120, 255, 255, 255);
                switchToDashboard.Icon_BackColor = Color.Transparent;
                switchToDashboard.Title_BackColor = Color.Transparent;
            }
        }

        private void UserAccountEditor_MouseLeave(object sender, EventArgs e)
        {
            if (userAccountEditor.IsClicked)
            {
                userAccountEditor.BackColor = Color.FromArgb(120, 255, 255, 255);
                userAccountEditor.Icon_BackColor = Color.Transparent;
                userAccountEditor.Title_BackColor = Color.Transparent;
            }
            else
            {
                userAccountEditor.BackColor = Color.Transparent;
                userAccountEditor.Icon_BackColor = Color.Transparent;
                userAccountEditor.Title_BackColor = Color.Transparent;
            }
        }

        private void UserAccountEditor_MouseEnter(object sender, EventArgs e)
        {
            if (userAccountEditor.IsClicked)
            {
                userAccountEditor.BackColor = Color.FromArgb(120, 255, 255, 255);
                userAccountEditor.Icon_BackColor = Color.Transparent;
                userAccountEditor.Title_BackColor = Color.Transparent;
            }
            else
            {
                userAccountEditor.BackColor = Color.FromArgb(120, 255, 255, 255);
                userAccountEditor.Icon_BackColor = Color.Transparent;
                userAccountEditor.Title_BackColor = Color.Transparent;
            }
        }

        private void AppSettings_Click(object sender, EventArgs e)
        {
            if (appSettings.IsClicked) return;
            else
            {
                AdministrativeTabControl.TabSettings = true;

                appSettings.IsClicked = true;
                userAccountEditor.IsClicked = switchToDashboard.IsClicked = employeeManagement.IsClicked = logView.IsClicked = feedbackTab.IsClicked = false;
                appSettings.BackColor = Color.FromArgb(120, 255, 255, 255);

                switchToDashboard.BackColor = Color.Transparent;
                employeeManagement.BackColor = Color.Transparent;
                logView.BackColor = Color.Transparent;
                userAccountEditor.BackColor = Color.Transparent;
                feedbackTab.BackColor = Color.Transparent;

                SettingsUC settings = new SettingsUC();
                settings.Dock = DockStyle.Fill;

                settings.Visible = true;
                settings.Enabled = true;

                panel2.Controls.Clear();
                panel2.Controls.Add(settings);
            }
        }

        private void LogView_Click(object sender, EventArgs e)
        {
            if (logView.IsClicked) return;
            else
            {
                AdministrativeTabControl.TabLogView = true;
                logView.IsClicked = true;
                userAccountEditor.IsClicked = switchToDashboard.IsClicked = employeeManagement.IsClicked = appSettings.IsClicked = feedbackTab.IsClicked = false;

                logView.BackColor = Color.FromArgb(120, 255, 255, 255);

                switchToDashboard.BackColor = Color.Transparent;
                employeeManagement.BackColor = Color.Transparent;
                userAccountEditor.BackColor = Color.Transparent;
                appSettings.BackColor = Color.Transparent;
                feedbackTab.BackColor = Color.Transparent;

                ActivityViewer activityViewer = new ActivityViewer();
                activityViewer.Dock = DockStyle.Fill;

                activityViewer.Visible = true;
                activityViewer.Enabled = true;

                panel2.Controls.Clear();
                panel2.Controls.Add(activityViewer);
            }
        }

        private void EmployeeManagement_Click(object sender, EventArgs e)
        {
            if (employeeManagement.IsClicked) return;
            else
            {
                AdministrativeTabControl.TabEmployee = true;
                employeeManagement.IsClicked = true;
                userAccountEditor.IsClicked = switchToDashboard.IsClicked = logView.IsClicked = appSettings.IsClicked = feedbackTab.IsClicked = false;

                employeeManagement.BackColor = Color.FromArgb(120, 255, 255, 255);

                switchToDashboard.BackColor = Color.Transparent;
                userAccountEditor.BackColor = Color.Transparent;
                logView.BackColor = Color.Transparent;
                appSettings.BackColor = Color.Transparent;
                feedbackTab.BackColor = Color.Transparent;

                EmployeeManagerUserControl employeeManager = new EmployeeManagerUserControl();
                employeeManager.Dock = DockStyle.Fill;
                employeeManager.Visible = true;
                employeeManager.Enabled = true;

                panel2.Controls.Clear();
                panel2.Controls.Add(employeeManager);
            }
        }

        private void SwitchToDashboard_Click(object sender, EventArgs e)
        {
            if (switchToDashboard.IsClicked) return;
            else
            {
                AdministrativeTabControl.TabDashboard = true;

                switchToDashboard.IsClicked = true;
                userAccountEditor.IsClicked = employeeManagement.IsClicked = logView.IsClicked = appSettings.IsClicked = feedbackTab.IsClicked = false;
                switchToDashboard.BackColor = Color.FromArgb(120, 255, 255, 255);

                userAccountEditor.BackColor = Color.Transparent;
                employeeManagement.BackColor = Color.Transparent;
                logView.BackColor = Color.Transparent;
                appSettings.BackColor = Color.Transparent;
                feedbackTab.BackColor = Color.Transparent;

                DashboardUserControl dashboard = new DashboardUserControl();
                dashboard.Dock = DockStyle.Fill;

                dashboard.Enabled = true;
                dashboard.Visible = true;

                panel2.Controls.Clear();
                panel2.Controls.Add(dashboard);
            }
        }

        private void UserAccountEditor_Click(object sender, EventArgs e)
        {
            if (userAccountEditor.IsClicked) return;
            else
            {
                AdministrativeTabControl.TabUserAccount = true;

                userAccountEditor.IsClicked = true;
                switchToDashboard.IsClicked = employeeManagement.IsClicked = logView.IsClicked = appSettings.IsClicked = feedbackTab.IsClicked = false;
                userAccountEditor.BackColor = Color.FromArgb(120, 255, 255, 255);

                switchToDashboard.BackColor = Color.Transparent;
                employeeManagement.BackColor = Color.Transparent;
                logView.BackColor = Color.Transparent;
                appSettings.BackColor = Color.Transparent;
                feedbackTab.BackColor = Color.Transparent;
            }
        }

        private void AdministrativeUserControl_Load(object sender, EventArgs e)
        {
            Bitmap bmpAccount = new Bitmap(Resources.account);
            userAccountEditor.Icon = bmpAccount;
            userAccountEditor.Title = "Welcome back, " + Config.Username_shared + "!";

            Bitmap bmpDashboard = new Bitmap(Resources.dashboard);
            switchToDashboard.Icon = bmpDashboard;
            switchToDashboard.Title = "Dashboard";

            Bitmap bmpEmployee = new Bitmap(Resources.employee);
            employeeManagement.Icon = bmpEmployee;
            employeeManagement.Title = "Employee Manager";

            Bitmap bmpLogViewer = new Bitmap(Resources.log_viewer);
            logView.Icon = bmpLogViewer;
            logView.Title = "Activity Viewer";

            Bitmap bmpSettings = new Bitmap(Resources.settings);
            appSettings.Icon = bmpSettings;
            appSettings.Title = "Settings";

            Bitmap bmpFeedback = new Bitmap(Resources.feedback);
            feedbackTab.Icon = bmpFeedback;
            feedbackTab.Title = "Feedback";
        }
    }
}
