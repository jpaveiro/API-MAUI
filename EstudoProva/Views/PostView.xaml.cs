using EstudoProva.ViewModels;

namespace EstudoProva.Views;

public partial class PostView : ContentPage
{
	public PostView()
	{
		InitializeComponent();
		BindingContext = new PostViewModel();
	}
}