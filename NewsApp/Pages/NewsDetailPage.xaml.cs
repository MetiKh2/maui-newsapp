using NewsApp.Models;

namespace NewsApp.Pages;

public partial class NewsDetailPage : ContentPage
{
	private string url;
	public NewsDetailPage(Article article)
	{
		InitializeComponent();
		LblContent.Text = article.Content;
		LblTitle.Text = article.Title;
		ImgNews.Source= article.Image;
		url = article.Url;
    }

	private async void ShareBtn_Clicked(object sender, EventArgs e)
	{
        await Share.RequestAsync(new ShareTextRequest
		{
            Uri = url,
            Title = "Share"
        });
    }
}