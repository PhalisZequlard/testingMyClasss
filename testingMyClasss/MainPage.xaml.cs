using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace testingMyClasss
{
    public class Triangle
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public bool IsValid { get; set; }
    }
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }



        List<Triangle> triangles = new List<Triangle>();
        private void Tryan(object sender, EventArgs e)
        {
            double a, b, c;

            if (double.TryParse(na.Text, out a) && double.TryParse(nb.Text, out b) && double.TryParse(nc.Text, out c))
            {
                if (a < 0 || b < 0 || c < 0)
                {
                    DisplayAlert("Error", "Sides must be greater than 0", "OK");
                    return;
                }

                Triangle triangle = new Triangle { A = a, B = b, C = c };
                if (a + b > c && a + c > b && b + c > a)
                {
                    triangle.IsValid = true;
                    this.triangle.Text = $"邊長{a}, {b}, {c}可構成三角形";
                    this.triangle.BackgroundColor = Color.Green;
                }
                else
                {
                    triangle.IsValid = false;
                    this.triangle.Text = $"邊長{a}, {b}, {c}不可構成三角形";
                    this.triangle.BackgroundColor = Color.Red;
                }

                triangles.Add(triangle);
                UpdateTriangleHistory();
            }
            else
            {
                DisplayAlert("Error", "Invalid input. Please enter valid numbers.", "OK");
            }
        }

        private void UpdateTriangleHistory()
        {
            string history = "";
            foreach (var t in triangles)
            {
                history += $"A: {t.A}, B: {t.B}, C: {t.C}, IsValid: {t.IsValid}\n";
            }
            triangleHistory.Text = history;
        }
    }
}
