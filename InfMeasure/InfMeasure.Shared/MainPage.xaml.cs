using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace InfMeasure
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();

			this.Loaded += MainPage_Loaded;
		}
		
		private void MainPage_Loaded(object sender, RoutedEventArgs e)
		{
			HostBorder.Child = new InvalidatedChild(InvalidateChildView) { Background = new SolidColorBrush(Colors.Tomato) };
		}

		private void SetDimensions(object sender, RoutedEventArgs e)
		{
			InvalidateChildView.ChildWidth = 120;
			InvalidateChildView.ChildHeight = 72;
		}
	}
}
