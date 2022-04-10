using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Zadanie5
{
	public partial class DodajEdytujModal : Window
	{
		public DodajEdytujModal()
		{
			InitializeComponent();
		}

		public string filmTitle { get; set; }
		public string filmDescription { get; set; }
		public DatePicker filmDate { get; set; }


		private void OnOK(object sender, RoutedEventArgs e)
		{
			filmTitle = title.Text;
			filmDescription = description.Text;
			filmDate = releasedate;
			DialogResult = true;
			Close();
		}
	}
}
