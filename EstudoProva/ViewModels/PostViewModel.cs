using CommunityToolkit.Mvvm.ComponentModel;
using EstudoProva.Models;
using EstudoProva.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EstudoProva.ViewModels
{
    public partial class PostViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Post> _posts;

        public ICommand getPostsCommand { get; }

        public PostViewModel()
        {
            getPostsCommand = new Command(getPosts);
        }

        public async void getPosts()
        {
            PostService postService = new();
            Posts = await postService.getPosts();
        }
    }
}
