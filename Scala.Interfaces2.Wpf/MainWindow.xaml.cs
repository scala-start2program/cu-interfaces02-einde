﻿using Scala.Interfaces2.Core.Entities;
using Scala.Interfaces2.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace Scala.Interfaces2.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TransportService transportService = new TransportService();
        public MainWindow()
        {
            InitializeComponent();
        }
        void ShowMeansOfTransport()
        {
            lstMeansOfTransport.ItemsSource = transportService.Movables;
            lstMeansOfTransport.Items.Refresh();
        }
        void ShowPeople()
        {
            lstPersons.ItemsSource = transportService.People;
            lstPersons.Items.Refresh();
        }
        void ShowTrips(Person person)
        {
            lstTrips.ItemsSource = person.Trips;
            lstTrips.Items.Refresh();
        }
        void ShowFeedback(string feedback, bool isError = true)
        {
            tbkFeedBack.Visibility = Visibility.Visible;
            tbkFeedBack.Text = feedback;
            tbkFeedBack.Background = isError ? Brushes.IndianRed : Brushes.DeepSkyBlue;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowMeansOfTransport();
            ShowPeople();
            tbkFeedBack.Visibility = Visibility.Hidden;
            lstPersons.SelectedIndex = 0;

        }



        private void LstPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person currentPerson = (Person)lstPersons.SelectedItem;
            ShowTrips(currentPerson);
            txtDistance.Focus();
            txtDistance.SelectAll();

        }

        private void BtnGo_Click(object sender, RoutedEventArgs e)
        {
            tbkFeedBack.Visibility = Visibility.Hidden;
            Movable movable = (Movable)lstMeansOfTransport.SelectedItem;
            Person currentPerson = (Person)lstPersons.SelectedItem;
            bool validDistance = float.TryParse(txtDistance.Text, out float distance);

            if (validDistance)
            {
                try
                {
                    currentPerson.Go(distance, movable);
                    ShowTrips(currentPerson);
                    lstMeansOfTransport.SelectedItem = null;
                    txtDistance.Focus();
                    txtDistance.SelectAll();
                }
                catch (Exception ex)
                {
                    ShowFeedback(ex.Message);
                }
            }
            else
            {
                ShowFeedback("Geef een getal in voor de afstand");
            }

        }
    }
}
