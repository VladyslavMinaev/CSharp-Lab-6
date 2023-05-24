using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientApp.Entities;
using ClientApp.Services;
using Newtonsoft.Json;

namespace ClientApp
{
    public partial class MainForm : Form
    {
        private User _user;
        private Communicator _communicator;
        private DateTime _choosenDate;

        public MainForm(User user)
        {
            _user = user;
            _communicator = new();

            InitializeComponent();
            ReloadBookings();
            ReloadDates();
        }

        private async Task ReloadBookings()
        {
            var dates = await _communicator.Get<List<Date>>("http://localhost:5000/api/Room/GetMyBookings?token="
                                                            + _user.Token);

            bookingsListView.Items.Clear();
            foreach (var date in dates)
            {
                var url = "http://localhost:5000/api/Room/GetPlacesByRoom?token="
                          + _user.Token + "&roomName=" + date.RoomName;
                var places = await _communicator.Get<int>(url);

                url = "http://localhost:5000/api/Room/GetPriceByRoom?token="
                      + _user.Token + "&roomName=" + date.RoomName;
                var price = await _communicator.Get<double>(url);

                ListViewItem item = new(date.RoomName);
                item.SubItems.Add(date.DateTime.ToString("d"));
                item.SubItems.Add(price.ToString());
                item.SubItems.Add(places.ToString());

                bookingsListView.Items.Add(item);
            }
        }

        private void ReloadDates()
        {
            datesListView.Items.Clear();
            for (int i = 0; i < 100; i++)
            {
                ListViewItem item = new(DateTime.Now.AddDays(i).ToString("d"));
                datesListView.Items.Add(item);
            }
        }
        
        private async Task ReloadRooms()
        {
            var rooms = await _communicator.Get<List<Room>>("http://localhost:5000/api/Room/GetFreeRooms?token="
                                                            + _user.Token + "&dateTime=" + _choosenDate.ToString("d"));

            roomsListView.Items.Clear();
            foreach (var room in rooms)
            {
                ListViewItem item = new(room.Name);
                item.SubItems.Add(room.Price.ToString());
                item.SubItems.Add(room.PlacesAmount.ToString());

                roomsListView.Items.Add(item);
            }
        }

        private async void datesListView_ItemActivate(object sender, EventArgs e)
        {
            var date = (sender as ListView)!.SelectedItems[0].Text;
            _choosenDate = DateTime.Parse(date);

            await ReloadRooms();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Date date = new()
            {
                DateTime = _choosenDate,
                RoomName = roomsListView.SelectedItems[0].Text
            };

            await _communicator.Post<int>("http://localhost:5000/api/Room/Book?token=" 
                                                              + _user.Token, date);

            MessageBox.Show("Номер заброньовано на вибрану дату!");

            await ReloadBookings();
            await ReloadRooms();
        }
    }
}
