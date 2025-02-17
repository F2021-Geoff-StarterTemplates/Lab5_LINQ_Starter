using System.Windows;

namespace Lab5_LINQ_Starter;

//Scaffold command used to generate the models/context for this lab
//scaffold-dbcontext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False" Microsoft.EntityFrameworkCore.SqlServer -outputdir Models/Generated -contextdir Data -namespace Lab5_LINQ.Models -contextnamespace Lab5_LINQ.Data -Tables Products, Categories, Suppliers -DataAnnotations -force

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

    }
}