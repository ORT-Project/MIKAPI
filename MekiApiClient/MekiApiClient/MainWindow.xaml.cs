using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Media.Animation;
using Newtonsoft.Json;

namespace MekiApiClient
{
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string BaseUrl = "https://localhost:5001/api/users"; //Lien API

        public MainWindow()
        {
            InitializeComponent();
        }

        private void UsersListView_Loaded(object sender, RoutedEventArgs e)
        {
            var storyboard = (Storyboard)FindResource("FadeInAnimation");
            storyboard.Begin(UsersListView);
        }

        // Get all users
        private async void GetUsers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var response = await _httpClient.GetAsync(BaseUrl);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(content);

                // Display users in the ListView
                UsersListView.ItemsSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Create a new user
        private async void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            // Get values from input fields
            var username = UsernameTextBox.Text;
            var email = EmailTextBox.Text;

            // Check if fields are not empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Create a new user
            var user = new
            {
                Username = username,
                Email = email
            };

            try
            {
                // Send POST request to the API
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(BaseUrl, content);
                response.EnsureSuccessStatusCode();

                // Show success message
                MessageBox.Show("User created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Refresh the user list
                GetUsers_Click(sender, e);

                // Clear input fields
                UsernameTextBox.Clear();
                EmailTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // User model
        public class User
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
        }
    }
}