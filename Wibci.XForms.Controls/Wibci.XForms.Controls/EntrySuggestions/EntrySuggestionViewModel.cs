using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Wibci.XForms.Controls.EntrySuggestions
{
	public class EntrySuggestionViewModel : BindableBase
	{
		public EntrySuggestionViewModel()
		{
			Suggestions = new List<Suggestion>();
		}

		private List<Suggestion> _suggestions { get; set; } = new List<Suggestion>
		{
			new Suggestion { Text = "Task 1" },
			new Suggestion { Text = "Task 2" },
			new Suggestion { Text = "Task 3" }
		};

		public List<Suggestion> Suggestions { get; set; }

		private string _selectedText;

		public string SelectedText
		{
			get { return _selectedText; }
			set 
			{ 
				SetProperty(ref _selectedText, value);
				FilterSuggestions();
			}
		}

		private string _finalSelectionText;

		public string FinalSelectionText
		{
			get { return _finalSelectionText; }
			set { SetProperty(ref _finalSelectionText, value); }
		}

		public ICommand DoSomethingCommand => new DelegateCommand(DoSomething);

		public ICommand SelectNextSuggestionCommand => new DelegateCommand(() => SelectTaskSuggestion(ListMoveDirection.Next));

		public ICommand SelectPreviousSuggestionCommand => new DelegateCommand(() => SelectTaskSuggestion(ListMoveDirection.Previous));


		private void DoSomething()
		{
			var selectedText = SelectedText;
			
			var selectedItem = Suggestions.FirstOrDefault(s => s.IsSelected);
			if (selectedItem != null)
			{
				selectedText = selectedItem.Text;
			}
			
			FinalSelectionText = selectedText;
			SelectedText = null;
		}

		private static object _autoCompleteTasksLock = new object();

		private void SelectTaskSuggestion(ListMoveDirection direction)
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				// lock for collection manupulation
				lock (_autoCompleteTasksLock)
				{
					bool isAnySelected = Suggestions.Any(t => t.IsSelected);
					if (!isAnySelected)
					{
						// select the last item in the list
						Suggestions[Suggestions.Count - 1].IsSelected = true;
					}
					else if (Suggestions.Count > 1)
					{
						var selectedItem = Suggestions.First(t => t.IsSelected);
						int index = Suggestions.IndexOf(selectedItem);
						index = direction == ListMoveDirection.Next ? index + 1 : index - 1;

						if (index < 0)
						{
							index = Suggestions.Count - 1;
						}
						if (index > Suggestions.Count - 1)
						{
							index = 0;
						}
						selectedItem.IsSelected = false;
						selectedItem = Suggestions[index];
						selectedItem.IsSelected = true;
					}
				}
			});
		}

		private void FilterSuggestions()
		{
			if (!string.IsNullOrEmpty(SelectedText) && SelectedText.Length > 3)
			{
				string matchText = SelectedText.ToUpper();
				var matchedItems = _suggestions.Where(t => t.Text.ToUpper().Contains(matchText)).ToList();
				Suggestions = matchedItems;
				RaisePropertyChanged(nameof(Suggestions));
			}
			else
			{
				Suggestions = new List<Suggestion>();
				RaisePropertyChanged(nameof(Suggestions));
			}
		}

	}

	public enum ListMoveDirection
	{
		Next,
		Previous
	}


	public class Suggestion : BindableBase
	{
		public string Text { get; set; }

		private bool _isSelected;

		public bool IsSelected
		{
			get { return _isSelected; }
			set { SetProperty(ref _isSelected, value); }
		}
	}

}
