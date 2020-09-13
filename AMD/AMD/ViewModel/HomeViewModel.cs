using AMD.Domain;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AMD.ViewModel
{
    class HomeViewModel : INotifyPropertyChanged
    {
        //    private object _allItems;

        //    public ICommand LoginCommand => new AnotherCommandImplementation(ExecuteLogin);

        //    public HomeViewModel()
        //    {

        //    }


        //    private void ExecuteLogin(object obj)
        //    {
        //        return new ObservableCollection<DemoItem>
        //        {
        //            new DemoItem("Login", new Home(),
        //                new[]
        //                {
        //                    new DocumentationLink(DocumentationLinkType.Wiki, $"{ConfigurationManager.AppSettings["GitHub"]}/wiki", "WIKI"),
        //                    DocumentationLink.DemoPageLink<Home>()
        //                }
        //            ),
        //        };
        //    }
        public event PropertyChangedEventHandler PropertyChanged;
        }
    }
