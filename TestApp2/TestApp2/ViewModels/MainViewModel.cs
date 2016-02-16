using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TestApp2.ViewModels
{
    public class BaseViewModel : IViewModel
    {
        
    }

    public interface IViewModel
    {

    }

    public class MainViewModel : BaseViewModel
    {
        private readonly IShapeFactory _factory;

        public MainViewModel(IShapeFactory factory)
        {
            _factory = factory;
            Shapes = new ObservableCollection<ShapeViewModel>();
        }

        public ObservableCollection<ShapeViewModel> Shapes { get; private set; } 

        public ShapeViewModel GetRandomShape()
        {
            return _factory.CreateRandomShape();
        }
    }

  
}
