﻿using Prism.Commands;
using Prism.Mvvm;
using System.Diagnostics;
using System.Windows.Input;

namespace Wibci.XForms.Controls
{
	public class EntryViewModel : BindableBase
    {

		public EntryViewModel()
		{
			ValidateCommand = new DelegateCommand(Validate);
		}

		public ICommand ValidateCommand { get; }

		private string _firstName;

		public string FirstName
		{
			get { return _firstName; }
			set
			{
				SetProperty(ref _firstName, value);
				FirstNameValidationText = null;
			}
		}

		private string _lastName;

		public string LastName
		{
			get { return _lastName; }
			set
			{
				SetProperty(ref _lastName, value);
				LastNameValidationText = null;
			}
		}

		private string _email;

		public string Email
		{
			get { return _email; }
			set
			{
				SetProperty(ref _email, value);
				EmailValidationText = null;
			}
		}

		private string _emailValidationText;

		public string EmailValidationText
		{
			get { return _emailValidationText; }
			set { SetProperty(ref _emailValidationText, value); }
		}

		private string _firstNameValidationText;

		public string FirstNameValidationText
		{
			get { return _firstNameValidationText; }
			set { SetProperty(ref _firstNameValidationText, value); }
		}

		private string _lastNameValidationText;

		public string LastNameValidationText
		{
			get { return _lastNameValidationText; }
			set { SetProperty(ref _lastNameValidationText, value); }
		}

		private string _notes;

		public string Notes
		{
			get { return _notes; }
			set
			{
				SetProperty(ref _notes, value);
				NotesValidationText = null;
			}
		}

		private string _notesValidationText;

		public string NotesValidationText
		{
			get { return _notesValidationText; }
			set { SetProperty(ref _notesValidationText, value); }
		}


		private void Validate()
		{
			FirstNameValidationText = !string.IsNullOrEmpty(FirstName) ? null : "'First Name' must contain something!";
			LastNameValidationText = !string.IsNullOrEmpty(LastName) ? null : "'Last Name' must contain something!";
			NotesValidationText= !string.IsNullOrEmpty(Notes) ? null : "'Notes' must contain something!";
			EmailValidationText = string.IsNullOrEmpty(Email) ? "'Email' is required" : !Email.Contains("@") ? "'Email' must be valid" : null;
		}

	}
}
