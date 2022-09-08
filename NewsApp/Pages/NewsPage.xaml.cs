using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsPage : ContentPage
{
    private bool isNextPage = false;
    public List<Category> CategoryList = new List<Category>()
    {
        new Category(){Name = "Breaking-News"},
        new Category(){Name = "World"},
        new Category(){Name = "Nation"},
        new Category(){Name = "Business"},
        new Category(){Name = "Technology"},
        new Category(){Name = "Entertainment"},
        new Category(){Name = "Sports"},
        new Category(){Name = "Science"},
        new Category(){Name = "Health"}
    };
    private List<Article> Articles { get; set; }
    public NewsPage()
    {
        InitializeComponent();
        CollectionViewCategories.ItemsSource= CategoryList;
        Articles = new List<Article>();
        
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!isNextPage)
        {
            await PassCategoryName("breaking-news");
        }
        isNextPage = true;
    }
    public async Task PassCategoryName(string categoryName)
    {
        CollectionViewNews.ItemsSource = null;
        Articles.Clear();
        ApiService apiService = new ApiService();
        var newsResult = await apiService.GetNews(categoryName);
        Articles = newsResult.Articles;
        CollectionViewNews.ItemsSource = Articles;
    }
    private async void CollectionViewCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Category;
        await PassCategoryName(selectedItem.Name);

    }

    private void CollectionViewNews_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Article;
        Navigation.PushAsync(new NewsDetailPage(selectedItem));

    }
}