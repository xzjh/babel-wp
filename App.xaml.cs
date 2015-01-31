using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Resources;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Babel.Resources;

namespace Babel
{
    public partial class App : Application
    {
        public static User user1 { get; set; }
        public static User user2 { get; set; }
        public static User user3 { get; set; }
        public static User user4 { get; set; }
        public static User user5 { get; set; }
        public static User user6 { get; set; }
        public static Activity ac1 { get; set; }
        public static Activity ac2 { get; set; }
        public static Activity ac3 { get; set; }
        public static Activity ac4 { get; set; }


        /// <summary>
        /// Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public static PhoneApplicationFrame RootFrame { get; private set; }

        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public App()
        {
            user1 = new User();
            user1.UserName = "Zheng Li";
            user1.UserFacebookUrl = "https://www.facebook.com/sweeney1130?fref=ts";
            user1.UserIconUrl = "https://scontent-a-lax.xx.fbcdn.net/hphotos-prn2/t31.0-8/1077700_10200404863464677_701957100_o.jpg";
            user1.UserIntroduction = "Got great offer. Very happy these days.";
            user1.UserDescription = "I am a master student in University of Southern California, major in computer science. I like to play tennis and badminton. I like to make friends with different kinds of people.";

            user2 = new User();
            user2.UserName = "Long Chen";
            user2.UserFacebookUrl = "https://www.facebook.com/profile.php?id=1338028443&fref=ts";
            user2.UserIconUrl = "https://fbcdn-sphotos-g-a.akamaihd.net/hphotos-ak-xfa1/t31.0-8/1512257_10201665689747529_1243148821_o.jpg";
            user2.UserIntroduction = "";
            user2.UserDescription = "";
       
            user3 = new User();
            user3.UserName = "Zihan Tong";
            user3.UserFacebookUrl = "https://www.facebook.com/zihan.tong";
            user3.UserIconUrl = "https://scontent-a-lax.xx.fbcdn.net/hphotos-xfa1/t31.0-8/10626320_1463790837240602_3198076887803322097_o.jpg";
            user3.UserIntroduction = "";
            user3.UserDescription = "";

            user4 = new User();
            user4.UserName = "Jiaheng Zhang";
            user4.UserFacebookUrl = "https://www.facebook.com/ixzjh?fref=ts";
            user4.UserIconUrl = "https://fbcdn-profile-a.akamaihd.net/hprofile-ak-xaf1/v/t1.0-1/p320x320/10802010_10205596495731196_4446485967057294571_n.jpg?oh=94041e2921aaf06ede8b9ceaf056083b&oe=556DB1C9&__gda__=1433184850_f239d6b37f7ad6ae0a7d078fbd5e2ab8";
            user4.UserIntroduction = "";
            user4.UserDescription = "";

            user5 = new User();
            user5.UserName = "Yemin Shi";
            user5.UserFacebookUrl = "https://www.facebook.com/profile.php?id=100002144257426&fref=tl_fr_box&pnref=lhc.friends";
            user5.UserIconUrl = "https://scontent-b-lax.xx.fbcdn.net/hphotos-xpa1/t31.0-8/10329817_724203640994438_1635170653487382459_o.jpg";
            user5.UserIntroduction = "";
            user5.UserDescription = "";

            user5 = new User();
            user5.UserName = "Yemin Shi";
            user5.UserFacebookUrl = "https://www.facebook.com/profile.php?id=100002144257426&fref=tl_fr_box&pnref=lhc.friends";
            user5.UserIconUrl = "https://scontent-b-lax.xx.fbcdn.net/hphotos-xpa1/t31.0-8/10329817_724203640994438_1635170653487382459_o.jpg";
            user5.UserIntroduction = "";
            user5.UserDescription = "";

            user6 = new User();
            user6.UserName = "Liao Ni";
            user6.UserFacebookUrl = "https://www.facebook.com/photo.php?fbid=104777323005860&set=a.104777319672527.12431.100004207781291&type=1&theater";
            user6.UserIconUrl = "https://fbcdn-sphotos-h-a.akamaihd.net/hphotos-ak-xfa1/v/t1.0-9/552122_104777323005860_1750628002_n.jpg?oh=bd8acc69b5f1c44de0a27cc96a753e67&oe=554FB5CB&__gda__=1431354946_26b77c45ee1e16e230fdd82fbb4d5096";
            user6.UserIntroduction = "";
            user6.UserDescription = "";

            ac1 = new Activity();
            ac1.ActivityId = 0;
            ac1.ActivityTitle = "Go to 99 Ranch";
            ac1.Available = 4;
            ac1.Budget = 5;
            ac1.LocationDetail = "USC Gate 6";
            ac1.Owner = "Zheng Li";
            ac1.Destination = "99 Ranch";
            ac1.ActivityTime = Convert.ToDateTime("02/15/2015 10:30:00 AM");
            ac1.Description = "Go shopping to 99 Ranch."

            ac2 = new Activity();
            ac2.ActivityId = 1;
            ac2.ActivityTitle = "Go to see film at Regal";
            ac2.Available = 2;
            ac2.Budget = 1;
            ac2.LocationDetail = "USC Gate 4";
            ac2.Owner = "Long Chen";
            ac2.Destination = "Regal";
            ac2.ActivityTime = Convert.ToDateTime("02/19/2015 07:30:00 PM");
            ac2.Description = "See film at Regal. Here are two boys, and we want to invite two girls."

            // Global handler for uncaught exceptions.
            UnhandledException += Application_UnhandledException;

            // Standard XAML initialization
            InitializeComponent();

            // Phone-specific initialization
            InitializePhoneApplication();

            // Language display initialization
            InitializeLanguage();

            // Show graphics profiling information while debugging.
            if (Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode,
                // which shows areas of a page that are handed off to GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Prevent the screen from turning off while under the debugger by disabling
                // the application's idle detection.
                // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
                // and consume battery power when the user is not using the phone.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }

        }

        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
            //// Ensure that application state is restored appropriately
            //if (!App.ViewModel.IsDataLoaded)
            //{
            //    App.ViewModel.LoadData();
            //}
        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
            // Ensure that required application state is persisted here.
        }

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        // Code to execute if a navigation fails
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                Debugger.Break();
            }
        }

        #region Phone application initialization

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Handle reset requests for clearing the backstack
            RootFrame.Navigated += CheckForResetNavigation;

            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        private void CheckForResetNavigation(object sender, NavigationEventArgs e)
        {
            // If the app has received a 'reset' navigation, then we need to check
            // on the next navigation to see if the page stack should be reset
            if (e.NavigationMode == NavigationMode.Reset)
                RootFrame.Navigated += ClearBackStackAfterReset;
        }

        private void ClearBackStackAfterReset(object sender, NavigationEventArgs e)
        {
            // Unregister the event so it doesn't get called again
            RootFrame.Navigated -= ClearBackStackAfterReset;

            // Only clear the stack for 'new' (forward) and 'refresh' navigations
            if (e.NavigationMode != NavigationMode.New && e.NavigationMode != NavigationMode.Refresh)
                return;

            // For UI consistency, clear the entire page stack
            while (RootFrame.RemoveBackEntry() != null)
            {
                ; // do nothing
            }
        }

        #endregion

        // Initialize the app's font and flow direction as defined in its localized resource strings.
        //
        // To ensure that the font of your application is aligned with its supported languages and that the
        // FlowDirection for each of those languages follows its traditional direction, ResourceLanguage
        // and ResourceFlowDirection should be initialized in each resx file to match these values with that
        // file's culture. For example:
        //
        // AppResources.es-ES.resx
        //    ResourceLanguage's value should be "es-ES"
        //    ResourceFlowDirection's value should be "LeftToRight"
        //
        // AppResources.ar-SA.resx
        //     ResourceLanguage's value should be "ar-SA"
        //     ResourceFlowDirection's value should be "RightToLeft"
        //
        // For more info on localizing Windows Phone apps see http://go.microsoft.com/fwlink/?LinkId=262072.
        //
        private void InitializeLanguage()
        {
            try
            {
                // Set the font to match the display language defined by the
                // ResourceLanguage resource string for each supported language.
                //
                // Fall back to the font of the neutral language if the Display
                // language of the phone is not supported.
                //
                // If a compiler error is hit then ResourceLanguage is missing from
                // the resource file.
                RootFrame.Language = XmlLanguage.GetLanguage(AppResources.ResourceLanguage);

                // Set the FlowDirection of all elements under the root frame based
                // on the ResourceFlowDirection resource string for each
                // supported language.
                //
                // If a compiler error is hit then ResourceFlowDirection is missing from
                // the resource file.
                FlowDirection flow = (FlowDirection)Enum.Parse(typeof(FlowDirection), AppResources.ResourceFlowDirection);
                RootFrame.FlowDirection = flow;
            }
            catch
            {
                // If an exception is caught here it is most likely due to either
                // ResourceLangauge not being correctly set to a supported language
                // code or ResourceFlowDirection is set to a value other than LeftToRight
                // or RightToLeft.

                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                throw;
            }
        }
    }
}