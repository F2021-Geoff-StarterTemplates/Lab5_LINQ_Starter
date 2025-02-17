using Lab5_LINQ.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Lab5_LINQ_Starter;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        using (var context = new NorthwindContext())
        {
            //Load all DbSets
            context.Products.Load();
            context.Categories.Load();
            context.Suppliers.Load();

            // Cast all loaded data as collections
            var products = context.Products.Local.ToObservableCollection();
            var categories = context.Categories.Local.ToObservableCollection();
            var suppliers = context.Suppliers.Local.ToObservableCollection();

            // Instantiate a new MainWindow and pass it all the loaded data
            // (Could also pass to other parts of the application, ie. usercontrol, page, etc.)
            
            var mainWindow = new MainWindow
            {
                DataContext = new
                {
                    Products = products,
                    Categories = categories,
                    Suppliers = suppliers
                }
            };
            //Show the mainwindow object to the user.
            //To avoid double windows, be sure to remove the StarupUri attribute in App.xaml
            mainWindow.Show();
        }
    }
}

