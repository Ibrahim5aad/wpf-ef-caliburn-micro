using Caliburn.Micro;
using WpfEfCaliburnMicro.Application.Interfaces;
using WpfEfCaliburnMicro.Persistence.Contexts;
using WpfEfCaliburnMicro.Persistence.Repositories;
using CaliburnMicroTest.ViewModels;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CaliburnMicroTest
{
  internal class Bootstrapper : BootstrapperBase
  {

    SimpleContainer _container;

    public Bootstrapper()
    {
      _container = new SimpleContainer();
      Initialize();
    }


    protected override void Configure()
    {
      _container.Instance(_container);

      _container
        .Singleton<IWindowManager, WindowManager>()
        .Singleton<IEventAggregator, EventAggregator>()
        .Singleton<MyDbContext>()
        .Singleton<MainViewModel>()
        .PerRequest<IErrorClassRepository, ErrorClassRepository>()
        .PerRequest<IProductRepository, ProductRepository>();
    }


    protected override IEnumerable<object> GetAllInstances(Type service)
    {
      return _container.GetAllInstances(service);
    }

    protected override object GetInstance(Type service, string key)
    {
      return _container.GetInstance(service, key);
    }

    protected override void BuildUp(object instance)
    {
      _container.BuildUp(instance);
    }

    protected async override void OnStartup(object sender, StartupEventArgs e)
    {

      DatabaseFacade facade = new DatabaseFacade(new MyDbContext());
      facade.EnsureCreated();

      await DisplayRootViewForAsync<MainViewModel>();
    }

  }
}
