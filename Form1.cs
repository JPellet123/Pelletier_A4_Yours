using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PelletierLab4
{
    public partial class PelletierLab4 : Form
    {
        public PelletierLab4()
        {
            InitializeComponent();
        }

        /* Name: Jared Pelletier
         * Due Date: November 17th 2022
         * Description: This is a program that will calculate the price of a number of flights based on a
         * number of factors
         * */


        /* Name: ResetTrip
        * Sent: none
        * Returned: none
        * Resets all items inside the book group box */
        private void ResetTrip()
        {

            //hide the trip info grpbx
            grpTripInformation.Hide();

            //set cuba to be default checked
            radCuba.Checked = true;

            //blank out people txtbx
            txtPeople.Text = "";

            //blank out price lbl
            lblPrice.Text = "";

            //set credit card to default checked
            radCreditCard.Checked = true;

            //set cursor on the people txtbx
            txtPeople.Focus();
        }


        /* Name: SetFlight
        * Sent: none
        * Returned: none
        * changes flight included chk bx depending on which location rad is selected */
        private void SetFlight()
        {
            if (radFlorida.Checked)
            {
                chkFlightIncluded.Checked = false;
            }
            else
            {
                chkFlightIncluded.Checked = true;
            }
        }


        /* Name: Display Message
        * Sent: 2 strings, pass by value
        * Returned: none
        * Display message box with two variables for the message and title */
        private void DisplayMsg(string message, string title)
        {
            MessageBox.Show(message, title);
        }

        private void PelletierLab4_Load(object sender, EventArgs e)
        {
            ResetTrip();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTrip();
            
        }

        private void radCuba_CheckedChanged(object sender, EventArgs e)
        {
            SetFlight();
        }

        private void radFlorida_CheckedChanged(object sender, EventArgs e)
        {
            SetFlight();
        }

        private void radMexico_CheckedChanged(object sender, EventArgs e)
        {
            SetFlight();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {

            const int MIN = 1, MAX = 10;
            double price, total;
            string location;
            bool tryParseResult = int.TryParse(txtPeople.Text, out int number);

            if (tryParseResult == false)                
            {
                DisplayMsg("People must be a whole number", "Input Error");
                txtPeople.Focus();
                txtPeople.SelectAll();
            } //end if

            else if (number < MIN || number > MAX)
            {
                DisplayMsg("People must be between 1-10", "Input Error");
                txtPeople.Focus();
                txtPeople.SelectAll();
            } // end else if
            else
            {
                if (radMexico.Checked)
                {
                    price = 2300.79;
                    location = "MEXICO";
                } // end if
                else if (radCuba.Checked)
                {
                    price = 2150.50;
                    location = "CUBA";
                } //end else if

                else
                {
                    price = 2150.50;
                    location = "FLORIDA";
                } //end else

                total = price * number;

                if (radCash.Checked)
                {
                    total = total * 0.90;
                } //end if
                lblPrice.Text = total.ToString("C");

                lblDisplay.Text = "Booked by Jared" +
                    "\n\n" + "People: " + number.ToString("d2") +
                    "\n" + "Location: " + location +
                    "\n" + "Price : " + total.ToString("C");

                if (radCash.Checked)
                {
                    lblDisplay.Text = "Booked by Jared" +
                    "\n\n" + "People: " + number.ToString("d2") +
                    "\n" + "Location: " + location +
                    "\n" + "Cash Discount Applied" +
                    "\n" + "Price : " + total.ToString("C"); ;
                } //end if

                if (chkFlightIncluded.Checked)
                    {
                     lblDisplay.Text = "Booked by Jared" +
                     "\n\n" + "People: " + number.ToString("d2") +
                     "\n" + "Location: " + location +
                     "\n" + "Flight included" +
                     "\n" + "Price : " + total.ToString("C");
                    } //end if

                if (radCash.Checked == true && chkFlightIncluded.Checked == true)
                    {
                     lblDisplay.Text = "Booked by Jared" +
                     "\n\n" + "People: " + number.ToString("d2") +
                     "\n" + "Location: " + location +
                     "\n" + "Flight included" +
                     "\n" + "Cash Discount Applied" +
                     "\n" + "Price : " + total.ToString("C");
                    } //end if

                switch (number)
                {
                    case 1:
                        DisplayMsg("Special when booking single or tiple." +
                            "\n" + "BOGO Special - Call 555-1212 to recieve another person free!",
                            "Limited Time Offer");
                        break;
                    case 3:
                        DisplayMsg("Special when booking single or tiple." +
                            "\n" + "BOGO Special - Call 555-1212 to recieve another person free!",
                            "Limited Time Offer");
                        break;

                    default:
                        break;
                } //end switch

                grpTripInformation.Show();
                grpBook.Enabled = false;
            } //end else
        } //end book click

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string price = (string)lblPrice.Text;

            DisplayMsg("Trip booked and paid" +
                "\n" + "Price: " + lblPrice.Text, "Confirmation Email Sent");

            grpBook.Enabled = true;
            ResetTrip();
        }
    } //end form
} //end namespace


