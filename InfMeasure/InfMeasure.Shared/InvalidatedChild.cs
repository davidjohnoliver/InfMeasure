using System;
using System.Collections.Generic;
using System.Text;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace InfMeasure
{
	public partial class InvalidatedChild : Panel
	{
		private WeakReference<InvalidateChildView> _ownerRef;

		private InvalidateChildView Owner
		{
			get
			{
				if (_ownerRef != null && _ownerRef.TryGetTarget(out var target))
				{
					return target;
				}
				return null;
			}
			set => _ownerRef = new WeakReference<InvalidateChildView>(value);
		}

		public InvalidatedChild(InvalidateChildView owner)
		{
			Owner = owner;
			owner.RegisterChild(this);
		}

		private int _count;
		private Size _lastSize;

		protected override Size MeasureOverride(Size availableSize)
		{
			_count++;
			var size = new Size(Owner?.ChildWidth ?? 0, Owner?.ChildHeight ?? 0);
			if (_lastSize != size)
			{
				Console.WriteLine($"Measure count: {_count}");
				_count = 0;
			}
			_lastSize = size;
			if (_count > 20)
			{
				throw new InvalidOperationException("Too many measures");
			}
			return _lastSize;
		}
	}
}
