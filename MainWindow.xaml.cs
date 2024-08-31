using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml.Input;
using System;
using Windows.Graphics;
using WinRT.Interop;
using System.Collections.ObjectModel;
using Microsoft.UI;
using Microsoft.UI.Xaml.Media.Animation; // For animations
using Microsoft.UI.Xaml.Media; // For brush
using System.Threading.Tasks; // For task delay
using Windows.UI.Core; // For Dispatcher
using Microsoft.UI.Dispatching; // For DispatcherTimer

namespace Pixelpaw
{
    public sealed partial class MainWindow : Window
    {
        private double accelerationValue;
        private const double IncrementValue = 1; // Amount to increment the progress bar per click
        private const double MaxValue = 100; // Maximum value for the progress bar
        private const double MaxHeight = 200; // Height of the container
        private DispatcherTimer resetTimer;
        public ObservableCollection<SessionData> SessionHistory { get; set; }
        private bool isAccelerating;
        private bool wasReset; // Flag to track if the bar was reset
        private bool isFirstClick; // Flag to track if it's the first click

        public MainWindow()
        {
            this.InitializeComponent();
            this.Title = "Test App";

            var appWindow = GetAppWindowForCurrentWindow();
            appWindow.Resize(new SizeInt32(500, 870));

            AppWindow.SetIcon("D:\\Skills\\Internships\\Pixelpaw\\Project\\Pixelpaw\\Assets\\oval.ico");

            // Initialize the progress value
            accelerationValue = 0;

            // Initialize the session history collection
            SessionHistory = new ObservableCollection<SessionData>();
            SessionHistoryListView.ItemsSource = SessionHistory;

            // Ensure no session is registered on start
            isAccelerating = false;

            // Initialize and configure the reset timer
            resetTimer = new DispatcherTimer();
            resetTimer.Interval = TimeSpan.FromSeconds(1);
            resetTimer.Tick += ResetTimer_Tick;

            // Initialize the reset flag
            wasReset = false;

            // Initialize the first click flag
            isFirstClick = true; // Treat the first click as a new session
        }

        private AppWindow GetAppWindowForCurrentWindow()
        {
            var hwnd = WindowNative.GetWindowHandle(this);
            WindowId windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
            return AppWindow.GetFromWindowId(windowId);
        }

        private void OnAccelerateClick(object sender, RoutedEventArgs e)
        {
            // Treat the first click as a new session
            if (isFirstClick || wasReset)
            {
                isAccelerating = true;
                wasReset = false; // Clear the reset flag
                isFirstClick = false; // Clear the first click flag
                AddSession("Session " + (SessionHistory.Count + 1), DateTime.Now);
            }

            // Increment the progress bar value
            accelerationValue += IncrementValue;

            // Ensure the value doesn't exceed the maximum
            if (accelerationValue > MaxValue)
            {
                accelerationValue = MaxValue;
            }

            // Calculate the height of the fill
            double fillHeight = (accelerationValue / MaxValue) * MaxHeight;
            ProgressFill.Height = fillHeight;

            // Restart the reset timer
            resetTimer.Stop();
            resetTimer.Start();
        }

        private void OnAccelerateButtonReleased(object sender, RoutedEventArgs e)
        {
            // Stop acceleration and prevent new sessions from being registered until a new press
            isAccelerating = false;

            // Restart the reset timer for the final reset if needed
            resetTimer.Stop();
            resetTimer.Start();
        }

        private void ResetTimer_Tick(object sender, object e)
        {
            // Reset the progress bar value to 0
            accelerationValue = 0;
            ProgressFill.Height = 0;

            // Stop the timer after resetting
            resetTimer.Stop();

            // Set the flag indicating that the bar was reset
            wasReset = true;
        }

        private void AddSession(string title, DateTime time)
        {
            SessionHistory.Add(new SessionData
            {
                SessionTitle = title,
                SessionTime = $"Login time: {time:yyyy-MM-dd | hh:mm tt}"
            });
        }
    }

    public class SessionData
    {
        public string SessionTitle { get; set; }
        public string SessionTime { get; set; }
    }
}
