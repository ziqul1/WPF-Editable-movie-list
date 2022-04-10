using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zadanie5
{
	public partial class MainWindow : Window
	{
		private List<Film> listOfFilms { get; set; } = new List<Film>()
		{
			new Film { title="Tabaluga", description="Tabaluga i jego ziomo Arktos", releaseDate=DateTime.Parse("03.05.2022") },
			new Film { title="Transformers", description="Roboty tluka sie po glowce", releaseDate=DateTime.Parse("06.05.2022") },
			new Film { title="FF8", description="Ostre wyscigi na ulicy", releaseDate=DateTime.Parse("07.05.2022") },
			new Film { title="Coco", description="Animowany - z fajnym przekazem", releaseDate=DateTime.Parse("08.05.2022") }
		};

		private NonModal dialog = new NonModal();

		public MainWindow()
		{
			InitializeComponent();
			dialog = null;
			listboxdata.ItemsSource = listOfFilms;

		}

		private void dodajmodal(object sender, RoutedEventArgs e)
		{
			DodajEdytujModal dlg = new DodajEdytujModal();
			dlg.Owner = this;
			dlg.Title = "Nowy film";
			var tmp = new Film();

			if (dlg.ShowDialog() == true)
			{
				tmp.title = dlg.filmTitle;
				tmp.description = dlg.filmDescription;
				tmp.releaseDate = dlg.filmDate.SelectedDate.Value;
				listOfFilms.Add(tmp);
				listboxdata.Items.Refresh();
			}
		}

		private void usun_click(object sender, RoutedEventArgs e)
		{
			if (listboxdata.SelectedIndex >= 0)
			{
				if (MessageBox.Show("Czy na pewno chcesz usunąć wskazany element?", "Usuń film", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
					return;
				int tmpID = listboxdata.SelectedIndex;
				listOfFilms.RemoveAt(tmpID);
				listboxdata.Items.Refresh();

			}
		}

		private void edytujmodal(object sender, RoutedEventArgs e)
		{
			DodajEdytujModal dlg = new DodajEdytujModal();
			dlg.Owner = this;
			dlg.Title = "Edytuj film";
			var tmpFilm = new Film();
			int tmpID = listboxdata.SelectedIndex;

			if (tmpID >= 0)
			{
				tmpFilm = listOfFilms[tmpID];

				dlg.title.Text = tmpFilm.title;
				dlg.description.Text = tmpFilm.description;
				dlg.releasedate.SelectedDate = tmpFilm.releaseDate;
			}

			if (dlg.ShowDialog() == true)
			{
				tmpFilm.title = dlg.filmTitle;
				tmpFilm.description = dlg.filmDescription;
				tmpFilm.releaseDate = dlg.filmDate.SelectedDate.Value;
				listOfFilms[tmpID] = tmpFilm;
				listboxdata.Items.Refresh();
			}
		}

		public void podgladClosed()
		{
			dialog = null;
			podgladButton.IsEnabled = true;
		}


		private void listboxdata_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			dynamic film2 = listboxdata.SelectedItem;

			if (listboxdata.SelectedIndex < 0)
			{
				usunButton.IsEnabled = false;
				edytujButton.IsEnabled = false;
				podgladButton.IsEnabled = false;

			}
			else if(dialog != null)
			{

				podgladButton.IsEnabled = false;
			}
			else 
			{
				usunButton.IsEnabled = true;
				edytujButton.IsEnabled = true;
				podgladButton.IsEnabled = true;
			}

			if (film2 != null && dialog != null)
			{
				dialog.Update(film2);
			}
			else
				return;

		}

		private void podglad_click(object sender, RoutedEventArgs e)
		{
			NonModal dlg = new NonModal();
			dlg.Owner = this;
			var tmpFilm = new Film();

			int tmpID = listboxdata.SelectedIndex;
			if (tmpID >= 0)
			{
				tmpFilm = listOfFilms[tmpID];

				dlg.title.Text = tmpFilm.title;
				dlg.description.Text = tmpFilm.description;
				dlg.releasedate.Text = tmpFilm.releaseDate.ToString("d");
			}
			this.dialog = dlg;
			podgladButton.IsEnabled = false;
			dlg.Show();

		}
	}


	public class Film
	{
		public string title { get; set; }
		public string description { get; set; }
		public DateTime releaseDate { get; set; }

		public override string ToString()
		{
			return title;
			//return title + " | " + description + " | " + releaseDate.ToString("d");
		}
	}

}
