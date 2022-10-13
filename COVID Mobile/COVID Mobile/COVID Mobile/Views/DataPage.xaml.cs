using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace COVID_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPage : ContentPage
    {
        public DataPage()
        {
            InitializeComponent();
            Point dataInfect1 = new Point(0, 100);
            Point dataInfect2 = new Point(20, 70);
            Point dataInfect3 = new Point(40, 50);
            Point dataInfect4 = new Point(60, 60);
            Point dataInfect5 = new Point(80, 50);

            Point dataMorbid1 = new Point(0, 80);
            Point dataMorbid2 = new Point(20, 30);
            Point dataMorbid3 = new Point(40, 82);
            Point dataMorbid4 = new Point(60, 57);
            Point dataMorbid5 = new Point(80, 13);


            PointCollection infectionPoints = new PointCollection();
            infectionPoints.Add(dataInfect1);
            infectionPoints.Add(dataInfect2);
            infectionPoints.Add(dataInfect3);
            infectionPoints.Add(dataInfect4);
            infectionPoints.Add(dataInfect5);

            PointCollection morbidPoints = new PointCollection();
            morbidPoints.Add(dataMorbid1);
            morbidPoints.Add(dataMorbid2);
            morbidPoints.Add(dataMorbid3);
            morbidPoints.Add(dataMorbid4);
            morbidPoints.Add(dataMorbid5);


            this.GraphInfectData.Points = infectionPoints;
            this.GraphMorbidData.Points = morbidPoints;

            

        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (InfectRadio.IsChecked)
            {
                GraphInfectData.IsVisible = true;
                GraphMorbidData.IsVisible = false;
                InfectNum_Label.IsVisible = true;
                MorbidNum_Label.IsVisible = false;
            }
            else if (MorbidRadio.IsChecked)
            {
                GraphInfectData.IsVisible = false;
                GraphMorbidData.IsVisible = true;
                InfectNum_Label.IsVisible = false;
                MorbidNum_Label.IsVisible = true;
                MorbidNum_Label.Margin = new Thickness(0, 510, 0, 0);
            }
            else
            {
                GraphInfectData.IsVisible = true;
                GraphMorbidData.IsVisible = true;
                InfectNum_Label.IsVisible = true;
                MorbidNum_Label.IsVisible = true;
                MorbidNum_Label.Margin = new Thickness(0, 550, 0, 0);
            }
        }

        private void GraphTimeToggle_Toggled(object sender, ToggledEventArgs e)
        {
            if (GraphTimeToggle.IsToggled)
            {
                GraphTimeToggle_Label.Text = "All Data";
                InfectNum_Label.Text = "Total Infection: ";
                MorbidNum_Label.Text = "Total Deaths: ";
            }
            else
            {
                GraphTimeToggle_Label.Text = "Recent Data";
                InfectNum_Label.Text = "Recent Infections: ";
                MorbidNum_Label.Text = "Recent Deaths: "; 
            }
            
        }
    }
}