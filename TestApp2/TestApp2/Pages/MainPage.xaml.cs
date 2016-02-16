using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp2.Services;
using TestApp2.ViewModels;
using TestApp2.Views;
using Xamarin.Forms;
using TappedEventArgs = TestApp2.Views.TappedEventArgs;

namespace TestApp2.Pages
{
  
    public partial class MainPage : ContentPage
    {
        private readonly IDevice _device;
        private TapGestureRecognizer _tapGestureRecognizer;
        private PanGestureRecognizer _panGestureRecognizer;
        private MainViewModel _viewModel;
        public MainPage(MainViewModel mainViewModel, IDevice device) 
        {
            _device = device;
            InitializeComponent();
            Setup(mainViewModel);
            this.BindingContext = mainViewModel;
        }

        private void Setup(MainViewModel model)
        {
            _viewModel = model;
            this.Layout.OnTapped += this.CreateShapeView;
        }

        private async void CreateShapeView(object sender, TappedEventArgs args)
        {
            var shape = _viewModel.GetRandomShape();
            var view = CreateShapeView(shape);
            var c = new PanContainer(view, _device);
            Layout.Children.Add(c ,new Point(args.TappedLocation.X, args.TappedLocation.Y));
            await shape.LoadRandomPattern();
     
        }

        public CanvasLayout Layout
        {
         get { return (CanvasLayout) this.Content;  }
        }

        public MainViewModel ViewModel { get; set; }


        public Image CreateShapeView(ShapeViewModel shape)
        {
            Image i;
            if (shape is CircleViewModel)
            {
                i = new CircleImage {WidthRequest = shape.Width, HeightRequest = shape.Width, BindingContext = shape};
                i.SetBinding(CircleImage.FillColorProperty, new Binding("Color"));
            }
            else
            {
                i = new Image() { WidthRequest = shape.Width, HeightRequest = shape.Height, BindingContext = shape };
                i.SetBinding(BackgroundColorProperty, new Binding("Color"));
            }

            i.BindingContext = shape;
            i.SetBinding(Image.SourceProperty, new Binding("ImageSource"));

            return i;
        }


    }
}
