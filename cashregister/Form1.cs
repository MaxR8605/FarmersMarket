using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace cashregister
{
    public partial class farmersMarket : Form
    {
        double carrots, potatoes, beetroots, wheat, subtotal, tax, total, change, emeraldsGiven;

        private void newOrderButton_Click(object sender, EventArgs e)
        {
            villagerspeechbubble.Text = "Hrmm, welcome back!";
            receiptLabel.Text = "";
            receiptLabel.Visible = false;

            carrots = 0;
            potatoes = 0;
            beetroots = 0;
            wheat = 0;
            subtotal = 0;
            tax = 0;
            total = 0;
            change = 0;
            emeraldsGiven = 0;

            subtotalLabel.Visible = false;
            taxLabel.Visible = false;
            totalLabel.Visible = false;

            subtotalOutput.Visible = false;
            taxOutput.Visible = false;
            totalOutput.Visible = false;

            subtotalEmeraldSymbol.Visible = false;
            taxEmeraldSymbol.Visible = false;
            totalEmeraldSymbol.Visible = false;

            purchaseButton.Visible = false;
            giveEmeraldInput.Visible = false;
            giveEmeraldLabel.Visible = false;

            checkoutButton.Visible = true;

            carrotInput.Text = "";
            potatoInput.Text = "";
            beetrootInput.Text = "";
            wheatInput.Text = "";
            giveEmeraldInput.Text = "";
        }

        private void purchase_Click(object sender, EventArgs e)
        {
            try
            {
                giveEmeraldInput.Visible = false;
                giveEmeraldLabel.Visible = false;
                purchaseButton.Visible = false;
                checkoutButton.Visible = false;
                receiptLabel.Text = "";
                receiptLabel.Visible = false;
                emeraldsGiven = Convert.ToDouble(giveEmeraldInput.Text);
                change = emeraldsGiven - total;
                
                villagerspeechbubble.Text = $"Hrmm, thank you for your purchase. Here is your change of {change.ToString("0.00")} emeralds.";
                SoundPlayer receipt = new SoundPlayer(Properties.Resources.receiptPrinter);
                receipt.Play();
                Refresh();
                Thread.Sleep(1500);
                receiptLabel.BackColor = Color.White;
                receiptLabel.Visible = true;
                Refresh();
                Thread.Sleep(200);
                receiptLabel.Text = "    Farmer Jonathan's Farmer's Market";
                Refresh();
                Thread.Sleep(200);
                receiptLabel.Text += $"\n\n  Carrots x{carrots * 20} ...... {carrots.ToString("0.00")} emeralds";
                Refresh();
                Thread.Sleep(200);
                receiptLabel.Text += $"\n  Potatoes x{potatoes * 15} ..... {potatoes.ToString("0.00")} emeralds";
                Refresh();
                Thread.Sleep(200);
                receiptLabel.Text += $"\n  Beetroots x{beetroots * 10} .... {beetroots.ToString("0.00")} emeralds";
                Refresh();
                Thread.Sleep(200);
                receiptLabel.Text += $"\n  Wheat x{wheat * 30} ........ {wheat.ToString("0.00")} emeralds";
                Refresh();
                Thread.Sleep(200);
                receiptLabel.Text += $"\n\n  Subtotal ......... {subtotal.ToString("0.00")} emeralds";
                Refresh();
                Thread.Sleep(200);
                receiptLabel.Text += $"\n  Tax .............. {tax.ToString("0.00")} emeralds";
                Refresh();
                Thread.Sleep(200);
                receiptLabel.Text += $"\n\n  Total ............ {total.ToString("0.00")} emeralds";
                Refresh();
                Thread.Sleep(200);
                receiptLabel.Text += $"\n\n  Tendered ......... {emeraldsGiven.ToString("0.00")} emeralds";
                Refresh();
                Thread.Sleep(200);
                receiptLabel.Text += $"\n  Change ........... {change.ToString("0.00")} emeralds";
                Refresh();
                Thread.Sleep(200);
                receiptLabel.Text += $"\n\n\n  Thank you for shopping at your local\n  farmer's market.";
                Refresh();
                Thread.Sleep(2000);
                villagerspeechbubble.Text = "Have a nice day! Hrmmm.";

            }
            catch
            {
                villagerspeechbubble.Text = "Hrmmm... Something's wrong. Please make sure it is only numbers you are putting into the boxes.";
            }
        }
        public farmersMarket()
        {
            InitializeComponent();
        }

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                carrots = Convert.ToDouble(carrotInput.Text);
                potatoes = Convert.ToDouble(potatoInput.Text);
                beetroots = Convert.ToDouble(beetrootInput.Text);
                wheat = Convert.ToDouble(wheatInput.Text);

                carrots = carrots / 20;
                potatoes = potatoes / 15;
                beetroots = beetroots / 10;
                wheat = wheat / 30;

                subtotal = carrots + potatoes + beetroots + wheat;
                subtotalOutput.Text = $"{subtotal.ToString("0.00")}";

                subtotalLabel.Visible = true;
                taxLabel.Visible = true;
                totalLabel.Visible = true;

                subtotalOutput.Visible = true;
                taxOutput.Visible = true;
                totalOutput.Visible = true;

                subtotalEmeraldSymbol.Visible = true;
                taxEmeraldSymbol.Visible = true;
                totalEmeraldSymbol.Visible = true;

                villagerspeechbubble.Text = "Hrmm...";
                tax = subtotal / 5;
                total = subtotal + tax;
                taxOutput.Text = $"{tax.ToString("0.00")}";
                totalOutput.Text = $"{total.ToString("0.00")}";
                Refresh();
                Thread.Sleep(1000);
                villagerspeechbubble.Text = $"That will be {total.ToString("0.00")} emeralds please! Hrmm.";
                purchaseButton.Visible = true;
                giveEmeraldInput.Visible = true;
                giveEmeraldLabel.Visible = true;
            }
            catch
            {
                villagerspeechbubble.Text = "Hrmmm... Something's wrong. Please make sure it is only numbers you are putting into the boxes.";
            }
        }
    }
}
