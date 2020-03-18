using System;
using System.Collections.Generic;
using System.Text;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace InfMeasure
{
	public partial class InvalidateChildView : StackPanel
	{
		private InvalidatedChild _child;

		public double ChildWidth
		{
			get { return (double)GetValue(ChildWidthProperty); }
			set { SetValue(ChildWidthProperty, value); }
		}

		public static readonly DependencyProperty ChildWidthProperty =
			DependencyProperty.Register("ChildWidth", typeof(double), typeof(InvalidateChildView), new PropertyMetadata(0d, OnDimensionChanged));

		private static void OnDimensionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((InvalidateChildView)d).InvalidateMeasure();

		public double ChildHeight
		{
			get { return (double)GetValue(ChildHeightProperty); }
			set { SetValue(ChildHeightProperty, value); }
		}

		public static readonly DependencyProperty ChildHeightProperty =
			DependencyProperty.Register("ChildHeight", typeof(double), typeof(InvalidateChildView), new PropertyMetadata(0d, OnDimensionChanged));



		protected override Size MeasureOverride(Size availableSize)
		{
			_child?.InvalidateMeasure(); //Allow child to update its measure if ChildWidth/ChildHeight have changed

			return base.MeasureOverride(availableSize);
		}

		public void RegisterChild(InvalidatedChild child) => _child = child;
	}
}
