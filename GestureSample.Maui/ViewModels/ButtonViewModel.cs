﻿using System.Windows.Input;

namespace GestureSample.ViewModels
{
	public class ButtonViewModel : CustomEventArgsViewModel
	{
		public ICommand ClickedCommand { get; protected set; }

		public ButtonViewModel()
		{
			ClickedCommand = new Command<object>(OnClicked);
		}

		private void OnClicked(object obj)
		{
			AddText("{0} was clicked.", obj);
			
		}

		protected override void OnDown(MR.Gestures.DownUpEventArgs e)
		{
			base.OnDown(e);
			if(((VisualElement)e.Sender).BackgroundColor != Colors.Yellow)
				((VisualElement)e.Sender).BackgroundColor = Colors.Yellow;
			else
                ((VisualElement)e.Sender).BackgroundColor = Color.FromArgb("808080");
        }

		protected override void OnUp(MR.Gestures.DownUpEventArgs e)
		{
			base.OnUp(e);

			//((VisualElement)e.Sender).BackgroundColor = Color.FromArgb("808080");
		}
	}
}
