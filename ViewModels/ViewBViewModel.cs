﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSamples.ViewModels
{
    public class ViewBViewModel : BindableBase, IDialogAware
    {
        public ViewBViewModel()
        {
            OKButton = new DelegateCommand(OKButtonExecute);
        }

        public string Title => "";

        //
        private string _viewBTextBox = "XXX";
        public string ViewBTextBox
        {
            get { return _viewBTextBox; }
            set { SetProperty(ref _viewBTextBox, value); }
        }

        public event Action<IDialogResult> RequestClose;
        public DelegateCommand OKButton { get; }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            ViewBTextBox = parameters.GetValue<string>(nameof(ViewBTextBox));
        }

        private void OKButtonExecute ()
        {
            var p = new DialogParameters();
            p.Add(nameof(ViewBTextBox), ViewBTextBox);
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, p));
        }
    }
}
