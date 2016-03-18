using ImitationGame.Lab1.ViewModels;
using MvvmCross.Wpf.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ImitationGame.Lab1.WPF.Views
{
    public partial class FirstView : MvxWpfView
    {
        public FirstView()
        {
            this.InitializeComponent();
            var block = new TextBlock()
            {

            };

            Binding binding = new Binding
            {
                Source = block,
                Path = new PropertyPath("Children[0]"),
            };

        }
    }
}
