using Caliburn.Micro;
using WpfEfCaliburnMicro.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CaliburnMicroTest.ViewModels
{
  internal class MainViewModel : Screen, IHandle<string>
  {
    private IProductRepository _productRepo;
    private IEventAggregator _eventAggregator;
    private string _prop;
    private CancellationToken _cancellationToken = new CancellationToken();

    /// <summary>
    /// Initializes a new instance of the <see cref="MainViewModel"/> class.
    /// </summary>
    /// <param name="productRepo">The error class repository.</param>
    public MainViewModel(IProductRepository productRepo, IEventAggregator eventAggregator)
    {
      _productRepo = productRepo;
      _eventAggregator = eventAggregator;
      _eventAggregator.SubscribeOnUIThread(this);
    }

    public string MyProperty
    {
      get => _prop;
      set => Set(ref _prop, value);
    }

    public async Task HandleAsync(string message, CancellationToken cancellationToken)
    {
      if (!cancellationToken.IsCancellationRequested)
        await Task.Run(() => MyProperty = $"{message} Products found."); 
    }

    public async void Run()
    {
      var products = await _productRepo.GetAllAsync();
      await _eventAggregator.PublishOnUIThreadAsync(products.Count.ToString(), _cancellationToken);
    }

  }
}
