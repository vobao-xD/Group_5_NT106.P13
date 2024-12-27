using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Client
{
    public partial class ListTrip : Form
    {
        public ListTrip()
        {
            InitializeComponent();
        }

        private void ListTrip_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(response);
            ProcessResponse(response);
        }
        public string? response = Home.response;
        public void ProcessResponse(string response)
        {
            ///MessageBox.Show(response);
            if (response == null) { return; }
            try
            {
                List<Trips>? list = JsonConvert.DeserializeObject<List<Trips>>(response);
                if (list == null) { return; }

                /*foreach (var trip in list)
                {
                    string[] tripinfo = { trip.TripId.ToString(), trip.TripName, trip.DepartLocation, trip.ArrivalLocation, trip.DepartureDate, trip.Status.ToString(), trip.Plate.ToString() };
                    ListViewItem item = new ListViewItem(tripinfo);
                    ListViewItem a = listView1.Items.Add(item);

                }*/

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            MessageBox.Show("ok");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(listView1.SelectedItems.Count.ToString());
        }

       /* private void btnReserve_Click(object sender, EventArgs e)
        {
            ReserveTicket ins = new();
        }*/
    }




}
