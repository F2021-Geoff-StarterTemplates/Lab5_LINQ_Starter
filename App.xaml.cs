using Lab5_LINQ.Data;
using Lab5_LINQ_Starter.ViewModels;
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
            context.Products.Include(p => p.Category)
                            .Include(p => p.Supplier)
                            .Load();
            context.Categories.Include(c => c.Products).Load();
            ////context.Suppliers.Include(s => s.Products).Load();
            //context.Products.Include(p => p.Category).Load();
            //context.Products.Include(p => p.Supplier).Load();

            // Cast all loaded data as collections
            //var products = context.Products.Local.ToObservableCollection();
            var categories = context.Categories.Local.ToObservableCollection();
            //var suppliers = context.Suppliers.Local.ToObservableCollection();

            // Instantiate a new MainWindow and pass it all the loaded data
            // (Could also pass to other parts of the application, ie. usercontrol, page, etc.)

            var mainWindow = new MainWindow
            {
                DataContext = new MainViewModel(categories)
            };
            //Show the mainwindow object to the user.
            //To avoid double windows, be sure to remove the StartupUri attribute in App.xaml
            mainWindow.Show();
        }
    }
}

