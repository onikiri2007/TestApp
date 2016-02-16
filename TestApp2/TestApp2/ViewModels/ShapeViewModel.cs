using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestApp2.Annotations;
using TestApp2.Services;
using Xamarin.Forms;

namespace TestApp2.ViewModels
{
    public abstract class ShapeViewModel : INotifyPropertyChanged
    {
        protected readonly IRandomizerService _randomizer;
        private Color _color;
        private ImageSource _imageSource;

        public event PropertyChangedEventHandler PropertyChanged;
        private double _width;
        private double _height;

        protected ShapeViewModel(IRandomizerService randomizer)
        {
            _randomizer = randomizer;
        }

        public double Width
        {
            get { return _width;}
            set
            {
                _width = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("Width"));
                }
            }
        }

        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("Height"));
                }
            }
        }

        public Color Color
        {
            get { return _color;  }
            set
            {
                _color = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("Color"));
                }
            }
        }

        public string ImageUrl
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    ImageSource = new UriImageSource()
                    {
                        CachingEnabled = true,
                        Uri = new Uri(value),
                        CacheValidity = TimeSpan.FromDays(1)
                    };
                }
            }
        }


        public ImageSource ImageSource
        {
            get { return _imageSource;  }
            set
            {
                _imageSource = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("ImageSource"));
                }
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


        public abstract Task LoadRandomPattern();

    }


    public class SquareViewModel : ShapeViewModel
    {
        public SquareViewModel(IRandomizerService randomizer)
            : base(randomizer)
        {

        }

        public async override Task LoadRandomPattern()
        {
            var pattern = await _randomizer.GetRandomPattern();

            if (pattern.IsColorPattern)
            {
                this.Color = pattern.Color.Value;
            }
            else
            {
                this.ImageUrl = pattern.ImageUrl;
            }
        }
    }

    public class CircleViewModel : ShapeViewModel
    {
        public double Radius
        {
            get { return Math.Min(this.Width, Height)/2; }
        }

        public CircleViewModel(IRandomizerService randomizer) : base(randomizer)
        {

        }

        public async override Task LoadRandomPattern()
        {
            var pattern = await _randomizer.GetRandomColor();

            if (pattern.IsColorPattern)
            {
                this.Color = pattern.Color.Value;
            }
            else
            {
                this.Color = Color.FromRgb(0, 0, 0);
            }
        }
    }
}
