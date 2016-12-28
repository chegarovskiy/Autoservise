using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using CarService.Core.BusinessLogicLayer;
using CarService.Core.Entities;
using NLog;

namespace CarService.Core.DataAccessLayer.Context
{
    /// <summary>
    /// Set initializer for defauld data in the DB
    /// </summary>
    public class CarServiceDbInitializer : CreateDatabaseIfNotExists<CarServiceDbContext>
    {
        //private static Logger logger = LogManager.GetCurrentClassLogger();
        protected override void Seed(CarServiceDbContext context)
        {
            
                // set up base currencies
                var defaultCurrencies = new List<Currency>
                {
                    new Currency()
                    {
                        Name = Currencies.UAH.ToString(),
                        Description = "UAH. Ukrainian national currency",
                        IsDeleted = false,
                        Code = (int) Currencies.UAH,
                        ExchangeRate = 1.00
                    },
                    new Currency()
                    {
                        Name = Currencies.EUR.ToString(),
                        Description = "EUR. EU currency",
                        IsDeleted = false,
                        Code = (int) Currencies.EUR,
                        ExchangeRate = 27.9250
                    },
                    new Currency()
                    {
                        Name = Currencies.USD.ToString(),
                        Description = "USD. National currency of the USA",
                        IsDeleted = false,
                        Code = (int) Currencies.USD,
                        ExchangeRate = 25.6404
                    },
                    new Currency()
                    {
                        Name = Currencies.RUB.ToString(),
                        Description = "RUB. National currency of Russia",
                        IsDeleted = false,
                        Code = (int) Currencies.RUB,
                        ExchangeRate = 0.4120
                    }
                };

                foreach (var item in defaultCurrencies)
                {
                    context.Currencies.Add(item);

                    //record info about the added to the db recordings to the log file
                    //logger.Info("Successfully added default item # {0} with name {1} and description {2}", item.Id, item.Name, item.Description);
                }
                context.SaveChanges();

                var defaultManufacturers = new List<Manufacturer>()
                {
                    new Manufacturer() {Name = "Bosch", IsDeleted = false},
                    new Manufacturer() {Name = "Astra", IsDeleted = false}
                };

                foreach (var item in defaultManufacturers)
                {
                    context.Manufacturers.Add(item);
                }
                context.SaveChanges();

                var defaultSpares = new List<Spare>()
                {
                    new Spare()
                    {
                        Code = "1777905",
                        Currency = context.Currencies.FirstOrDefault(x => x.Code == (int) Currencies.UAH),
                        Manufacturer = context.Manufacturers.FirstOrDefault(x => x.Name == "Astra"),
                        MarkupPercentage = 10,
                        Price = 7.77,
                        Name = "Распредвал Toyota",
                        Quantity = 100
                    },
                    new Spare()
                    {
                        Code = "7775542",
                        Currency = context.Currencies.FirstOrDefault(x => x.Code == (int) Currencies.EUR),
                        Manufacturer = context.Manufacturers.FirstOrDefault(x => x.Name == "Bosch"),
                        MarkupPercentage = 10,
                        Price = 10.79,
                        Name = "Коленвал Mercedes",
                        Quantity = 77
                    },
                    new Spare()
                    {
                        Code = "3335542",
                    Currency = context.Currencies.FirstOrDefault(x => x.Code == (int)Currencies.RUB),
                        Manufacturer = context.Manufacturers.FirstOrDefault(x => x.Name == "Bosch"),
                        MarkupPercentage = 15,
                        Price = 1.35,
                        Name = "Коленвал Opel",
                        Quantity = 77
                    },
                    new Spare()
                    {
                        Code = "1115542",
                        Currency = context.Currencies.FirstOrDefault(x => x.Code == (int) Currencies.USD),
                        Manufacturer = context.Manufacturers.FirstOrDefault(x => x.Name == "Astra"),
                        MarkupPercentage = 17,
                        Price = 1.35,
                        Name = "Аптечка",
                        Quantity = 305
                    }
                };

                foreach (var item in defaultSpares)
                {
                    context.Spares.Add(item);
                }
                context.SaveChanges();

                var defaultServiceTypes = new List<ServiceType>()
                {
                    new ServiceType()
                    {
                        Name = "Лако-красочные работы"
                    },
                    new ServiceType()
                    {
                        Name = "Сварочные работы"
                    }
                };

                foreach (var item in defaultServiceTypes)
                {
                    context.ServiceTypes.Add(item);
                }
                context.SaveChanges();

                var defaultServices = new List<Service>()
                {
                    new Service()
                    {
                        Name = "Покраска бампера",
                        EmployeePercent = 50,
                        ServiceType = context.ServiceTypes.FirstOrDefault(x => x.Name == "Лако-красочные работы"),
                        BasePrice = 700
                    },
                    new Service()
                    {
                        Name = "Рихтовка капота",
                        EmployeePercent = 60,
                        ServiceType = context.ServiceTypes.FirstOrDefault(x => x.Name == "Сварочные работы"),
                        BasePrice = 1200
                    }
                };

                foreach (var item in defaultServices)
                {
                    context.Services.Add(item);
                }
                context.SaveChanges();

                var defaultUserGroups = new List<UserGroup>()
                {
                    new UserGroup()
                    {
                        Name = "Admin"
                    },
                    new UserGroup()
                    {
                        Name = "Accountant"
                    }
                };

                foreach (var item in defaultUserGroups)
                {
                    context.UsersGroups.Add(item);
                }
                context.SaveChanges();


                var defaultUsers = new List<User>()
                {
                    new User()
                    {
                        FirstName = "Ivanov",
                        Login = "test",
                        Password = "test",
                        BaseSalary = 1000.00,
                        UserGroup = context.UsersGroups.FirstOrDefault(x => x.Name == "Admin")
                    },
                    new User()
                    {
                        FirstName = "Sidorova",
                        Login = "tester",
                        Password = "tester",
                        BaseSalary = 2000.00,
                        UserGroup = context.UsersGroups.FirstOrDefault(x => x.Name == "Accountant")
                    }
                };

                foreach (var item in defaultUsers)
                {
                    context.Users.Add(item);
                }
                context.SaveChanges();

                var defaultClients = new List<Client>()
                {
                    new Client()
                    {
                        FullName = "Mykhaylo Barskyy",
                        Phone = "55577551"
                    },
                    new Client()
                    {
                        FullName = "Vasyl Smyslov",
                        Phone = "3223225"
                    }
                };

                foreach (var item in defaultClients)
                {
                    context.Client.Add(item);
                }
                context.SaveChanges();



                var defaultPaymentTypes = new List<PaymentType>()
                {
                    new PaymentType()
                    {
                        Name = "Card"
                    },
                    new PaymentType()
                    {
                        Name = "Cash"
                    }
                };

                foreach (var item in defaultPaymentTypes)
                {
                    context.PaymentTypes.Add(item);
                }
                context.SaveChanges();

                var defaultWorkTypes = new List<WorkType>()
                {
                    new WorkType
                    {
                        WorkName = "Замена втулок стабилизатора",
                        Modified = DateTime.Now
                    },
                    new WorkType
                    {
                        WorkName = "Замена пыльника гранаты",
                        Modified = DateTime.Now
                    },
                    new WorkType
                    {
                        WorkName = "Замена передних тормозных колодок",
                        Modified = DateTime.Now
                    },
                    new WorkType
                    {
                        WorkName = "Замена лобового стекла",
                        Modified = DateTime.Now
                    },
                    new WorkType
                    {
                        WorkName = "Замена масляного фильтра",
                        Modified = DateTime.Now
                    },
                    new WorkType
                    {
                        WorkName = "Замена радиатора салона",
                        Modified = DateTime.Now
                    }
                };

                foreach (var item in defaultWorkTypes)
                {
                    context.WorkTypes.Add(item);
                }
                context.SaveChanges();

            var defaultOrderSatus = new List<OrderStatus>
                    {
                        new OrderStatus
                        {
                            Name = OrderCurrentStatus.Draft.ToString()
                        },
                        new OrderStatus
                        {
                            Name = OrderCurrentStatus.New.ToString()
                        },
                        new OrderStatus
                        {
                            Name = OrderCurrentStatus.Completed.ToString()
                        },


                    };

            foreach (var item in defaultOrderSatus)
            {
                context.OrderStatuses.Add(item);
            }
            context.SaveChanges();

            var defaultOrder = new List<Order>
                    {
                        new Order
                        {
                            Client = context.Client.FirstOrDefault(x => x.FullName == "Vasyl Smyslov"),
                            EndDate = DateTime.Now.AddDays(7),
                            StartDate = DateTime.Now,
                            IsDeleted = false,
                            IsPaid = true,
                            OrderStatus =
                                context.OrderStatuses.FirstOrDefault(
                                    x => x.Name.Equals(OrderCurrentStatus.Draft.ToString())),
                            TotalPrice = 10925.88
                        },
                        new Order
                        {
                            Client = context.Client.FirstOrDefault(x => x.FullName == "Mykhaylo Barskyy"),
                            EndDate = DateTime.Now.AddDays(5),
                            StartDate = DateTime.Now.AddDays(1),
                            IsDeleted = false,
                            IsPaid = true,
                            OrderStatus = context.OrderStatuses.FirstOrDefault(
                                    x => x.Name.Equals(OrderCurrentStatus.Completed.ToString())),

                            TotalPrice = 7714.34
                        }


                    };

            foreach (var item in defaultOrder)
            {
                context.Orders.Add(item);
            }
            context.SaveChanges();


            var defaultOrderServices = new List<OrderedService>
                    {
                        new OrderedService
                        {
                            User = context.Users.FirstOrDefault(x => x.Login == "test"),
                            Service = context.Services.FirstOrDefault(x => x.Name == "Рихтовка капота"),
                            Order = context.Orders.FirstOrDefault(x => x.Client.FullName == "Mykhaylo Barskyy"),
                            FinalPrice = 117.25
                        },
                        new OrderedService
                        {
                            User = context.Users.FirstOrDefault(x => x.Login == "test"),
                            Service = context.Services.FirstOrDefault(x => x.Name == "Рихтовка капота"),
                            Order = context.Orders.FirstOrDefault(x => x.Client.FullName == "Vasyl Smyslov"),
                            FinalPrice = 987.55
                        },
                        new OrderedService
                        {
                            User = context.Users.FirstOrDefault(x => x.Login == "tester"),
                            Service = context.Services.FirstOrDefault(x => x.Name == "Покраска бампера"),
                            Order = context.Orders.FirstOrDefault(x => x.Client.FullName == "Mykhaylo Barskyy"),
                            FinalPrice = 31056.62
                        }

                    };

            foreach (var item in defaultOrderServices)
            {
                context.OrderedServices.Add(item);
            }
            context.SaveChanges();
            

            var defaultOrderStatuses = new List<OrderStatus>
                {
                    new OrderStatus() {Name = OrderCurrentStatus.Draft.ToString()},
                    new OrderStatus() {Name = OrderCurrentStatus.New.ToString()},
                    new OrderStatus() {Name = OrderCurrentStatus.Completed.ToString()}
                };

            foreach (var item in defaultOrderStatuses)
            {
                context.OrderStatuses.Add(item);
            }
            context.SaveChanges();

            var defaultOrderSpares = new List<OrderedSpare>
                    {
                        new OrderedSpare
                        {
                            User = context.Users.FirstOrDefault(x => x.Login == "test"),
                            Order = context.Orders.FirstOrDefault(x => x.Client.FullName == "Mykhaylo Barskyy"),
                            Currency = context.Currencies.FirstOrDefault(x => x.Code == 980),
                            Count = 2,
                            ExchangeRate = context.Currencies.FirstOrDefault(x => x.Code == 980)?.ExchangeRate,
                            Spare = context.Spares.FirstOrDefault(x => x.Code == "1777905"),
                            UsedMarkup = 1.23,
                            PriceForAll = 19.11
                        },
                        new OrderedSpare
                        {
                            User = context.Users.FirstOrDefault(x => x.Login == "test"),
                            Order = context.Orders.FirstOrDefault(x => x.Client.FullName == "Vasyl Smyslov"),
                            Currency = context.Currencies.FirstOrDefault(x => x.Code == 978),
                            Count = 5,
                            ExchangeRate = context.Currencies.FirstOrDefault(x => x.Code == 978)?.ExchangeRate,
                            Spare = context.Spares.FirstOrDefault(x => x.Code == "7775542"),
                            UsedMarkup = 1.85,
                            PriceForAll = 2876.45
                        },
                        new OrderedSpare
                        {
                            User = context.Users.FirstOrDefault(x => x.Login == "tester"),
                            Order = context.Orders.FirstOrDefault(x => x.Client.FullName == "Mykhaylo Barskyy"),
                            Currency = context.Currencies.FirstOrDefault(x => x.Code == 840),
                            Count = 13,
                            ExchangeRate = context.Currencies.FirstOrDefault(x => x.Code == 840)?.ExchangeRate,
                            Spare = context.Spares.FirstOrDefault(x => x.Code == "3335542"),
                            UsedMarkup = 1.30,
                            PriceForAll = 8710.68
                        }

                    };

            foreach (var item in defaultOrderSpares)
            {
                context.OrderedSpares.Add(item);
            }
            context.SaveChanges();



            base.Seed(context);
        }
    }
}