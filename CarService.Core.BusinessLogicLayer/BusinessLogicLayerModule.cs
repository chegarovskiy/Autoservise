
using Autofac;
using CarService.Core.BusinessLogicLayer.Implementations;
using CarService.Core.BusinessLogicLayer.Interfaces;
using CarService.Core.DataAccessLayer;
using CarService.Core.DataAccessLayer.Repositories;
using CarService.Core.DataAccessLayer.Repositories.Implementations;
using CarService.Core.DataAccessLayer.Repositories.Interfaces;
using CarService.Core.Entities;

namespace CarService.Core.BusinessLogicLayer
{
    public class BusinessLogicLayerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IEntity>().As<ModelId>();
            builder.RegisterType<IBaseRepository<ModelId>>().As<BaseRepository<ModelId>>();
            builder.RegisterType<IBaseBusinessLogic<ModelId>>().As<BaseBusinessLogic<BaseRepository<ModelId>, ModelId>>();
            builder.RegisterType<IBaseBusinessLogic<ModelId>>().As<BaseBusinessLogic<BaseRepository<ModelId>, ModelId>>();
            builder.RegisterType<IPaymentBusinessLogic>().As<PaymentBusinessLogic>();
            builder.RegisterType<IOrderBusinessLogic>().As<OrderBusinessLogic>();
            builder.RegisterType<IOrderRepository>().As<OrderRepository>();
            builder.RegisterType<IOrderedSpareBusinessLogic>().As<OrderedSpareBusinessLogic>();
            builder.RegisterType<IOrderedSpareRepository>().As<OrderedSpareRepository>();
            builder.RegisterType<IOrderedServiceBusinessLogic>().As<OrderedServiceBusinessLogic>();
            builder.RegisterType<IOrderedServiceRepository>().As<OrderedServiceRepository>();
            builder.RegisterType<IUserBusinessLogic>().As<UserBusinessLogic>();
            builder.RegisterType<IUserRepository>().As<UserRepository>();
            builder.RegisterType<IClientBusinessLogic>().As<ClientBusinessLogic>();
            builder.RegisterType<IClientRepository>().As<ClientRepository>();


            base.Load(builder);
        }
    }
}