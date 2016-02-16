using System;
using System.Threading.Tasks;
using TestApp2.Services;

namespace TestApp2.ViewModels
{
    public interface IShapeFactory
    {
        ShapeViewModel CreateRandomShape();
    }

    public class ShapeFactory : IShapeFactory
    {
        private readonly IRandomizerService _service;
        private readonly IDevice _device;

        public ShapeFactory(IRandomizerService service, IDevice device)
        {
            _service = service;
            _device = device;
        }

        public ShapeViewModel CreateRandomShape()
        {
            var size =  _service.GetRandomSize(_device.ScreenWidth, _device.ScreenHeight);
            ShapeViewModel shape;

            if (IsEven(RandomProvider.GetRandomGenerator().Next()))
            {
                shape = new SquareViewModel(_service)
                {
                    Width = size.Width,
                    Height = size.Height
                };
            }
            else
            {
                shape = new CircleViewModel(_service)
                {
                    Height = size.Height,
                    Width = size.Width
                };
            }

            return shape;
        }

        private bool IsEven(int number)
        {
            return number%2 == 0;
        }

    }

}