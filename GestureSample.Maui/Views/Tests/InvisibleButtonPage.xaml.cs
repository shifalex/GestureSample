﻿using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace GestureSample.Views.Tests
{
	public partial class InvisibleButtonPage : ContentPage
	{
		public InvisibleButtonPage()
		{
			InitializeComponent();
		}

		private void ContainerVisibility_Toggled(object sender, ToggledEventArgs e)
		{
			Container.IsVisible = e.Value;
		}

		private void ButtonVisibility_Toggled(object sender, ToggledEventArgs e)
		{
			theButton.IsVisible = e.Value;
		}

		private void TheButton_Down(object sender, MR.Gestures.DownUpEventArgs e)
		{
			LogCall();
		}

		private void TheButton_Up(object sender, MR.Gestures.DownUpEventArgs e)
		{
			LogCall();
		}

		private void TheButton_LongPressing(object sender, MR.Gestures.LongPressEventArgs e)
		{
			LogCall();
		}

		private void TheButton_LongPressed(object sender, MR.Gestures.LongPressEventArgs e)
		{
			LogCall();
		}

		private void TheButton_Clicked(object sender, EventArgs e)
		{
			LogCall();
		}

		private void LogCall([CallerMemberName] string caller = "")
		{
			Log.Text = caller + "\n" + Log.Text;
			Debug.WriteLine(caller);
		}
	}
}