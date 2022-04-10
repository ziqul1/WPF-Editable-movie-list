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
	public partial class NonModal : Window
	{
		public NonModal()
		{
			InitializeComponent();
		}

		public void Update(Film film)
		{
			title.Text = film.title;
			description.Text = film.description;
			releasedate.Text = film.releaseDate.ToString("d");
		}

		private void OnZamknij(object sender, RoutedEventArgs e)
		{
			Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().podgladClosed();
			Close();
		}
	}
}
