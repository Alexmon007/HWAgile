using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.InteropServices;
using AgileHW.Business.Managers;
using AgileHW.DataAccess.Context;
using AgileHW.DataAccess.DBModels;
using AgileHW.DataAccess.Repositories;
using Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AgileHW.Business.Test
{
    [TestClass]
    public class ProductManagerTest
    {
        private ProductManager _productManager;

        [TestInitialize]
        public void Load_Product_Manager()
        {
            var data = new List<Product>
            {
                new Product { ID = 1,Name = "AAA",Brand = "DatCo.",OriginCountry = "MX",Quantity = 1,Serial = "C12312N2",ReleaseDate = DateTime.Now,CreatedDate = DateTime.Now},
                new Product { ID = 2,Name = "BBB",Brand = "DatCo.",OriginCountry = "USA",Quantity = 32,Serial = "CDW312N2",ReleaseDate = DateTime.Now,CreatedDate = DateTime.Now},
                new Product { ID = 3,Name = "CCC",Brand = "DatCo.",OriginCountry = "CAN",Quantity = 50,Serial = "EE312N2",ReleaseDate = DateTime.Now,CreatedDate = DateTime.Now},
            };
            var mockDbSet = new Mock<DbSet<Product>>();
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());
            mockDbSet.Setup(d => d.Add(It.IsAny<Product>())).Callback<Product>(data.Add);
            var mockContext = new Mock<DBContext>();
            mockContext.Setup(m => m.Products).Returns(mockDbSet.Object);
            mockContext.Setup(m => m.Set<Product>()).Returns(mockDbSet.Object);
            var repository = new ProductRepository(mockContext.Object);
            this._productManager= new ProductManager(repository);
        }
        [TestMethod]
        public void Add_Product_Valid_Success()
        {
            var product = new ProductDTO
            {
                ID = 4,
                Name = "AAA",
                Brand = "DatCo.",
                OriginCountry = "MX",
                Quantity = 1,
                Serial = "C12312N2",
                Description = "This is a description",
                ReleaseDate = DateTime.Now,
                CreatedDate = DateTime.Now
            };
            var currentCount = this._productManager.getAll().Count;


            this._productManager.Add(product);

            Assert.AreEqual(currentCount+1,this._productManager.getAll().Count);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_Product_Invalid_Missing_Name_Fail()
        {
            var product = new ProductDTO
            {
                ID = 4,
                Name = "",
                Brand = "DatCo.",
                OriginCountry = "MX",
                Quantity = 1,
                Serial = "C12312N2",
                ReleaseDate = DateTime.Now,
                CreatedDate = DateTime.Now
            };
            this._productManager.Add(product);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_Product_Invalid_Missing_Brand_Fail()
        {
            var product = new ProductDTO
            {
                ID = 4,
                Name = "AAA",
                Brand = "",
                OriginCountry = "MX",
                Quantity = 1,
                Serial = "C12312N2",
                ReleaseDate = DateTime.Now,
                CreatedDate = DateTime.Now
            };

            this._productManager.Add(product);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_Product_Invalid_Missing_OriginCounty_Fail()
        {
            var product = new ProductDTO
            {
                ID = 4,
                Name = "AAA",
                Brand = "DatCo.",
                OriginCountry = "",
                Quantity = 1,
                Serial = "C12312N2",
                ReleaseDate = DateTime.Now,
                CreatedDate = DateTime.Now
            };

            this._productManager.Add(product);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_Product_Invalid_Mising_ReleaseDate_Fail()
        {
            var product = new ProductDTO
            {
                ID = 4,
                Name = "AAA",
                Brand = "DatCo.",
                OriginCountry = "MX",
                Quantity = 1,
                Serial = "C12312N2",
                CreatedDate = DateTime.Now
            };

            this._productManager.Add(product);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_Product_Invalid_Missing_Quantity_Fail()
        {
            var product = new ProductDTO
            {
                ID = 4,
                Name = "AAA",
                Brand = "DatCo.",
                OriginCountry = "MX",
                Quantity = 0,
                Serial = "C12312N2",
                ReleaseDate = DateTime.Now,
                CreatedDate = DateTime.Now
            };
            this._productManager.Add(product);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_Product_Invalid_Missing_SerialNumber_Fail()
        {
            var product = new ProductDTO
            {
                ID = 4,
                Name = "AAA",
                Brand = "DatCo.",
                OriginCountry = "MX",
                Quantity = 1,
                Serial = "",
                ReleaseDate = DateTime.Now,
                CreatedDate = DateTime.Now
            };
            this._productManager.Add(product);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_Product_Valid__Quantity_Over_999_Fail()
        {
            var product = new ProductDTO
            {
                ID = 4,
                Name = "AAA",
                Brand = "DatCo.",
                OriginCountry = "MX",
                Quantity = 1500,
                Serial = "C12312N2",
                ReleaseDate = DateTime.Now,
                CreatedDate = DateTime.Now
            };
            this._productManager.Add(product);
        }
        [TestMethod]
        public void Add_Product_Valid_NoDescription_Success()
        {
            var product = new ProductDTO
            {
                ID = 4,
                Name = "AAA",
                Brand = "DatCo.",
                OriginCountry = "MX",
                Quantity = 1,
                Serial = "C12312N2",
                ReleaseDate = DateTime.Now,
                CreatedDate = DateTime.Now
            };
            var currentCount = this._productManager.getAll().Count;


            this._productManager.Add(product);

            Assert.AreEqual(currentCount + 1, this._productManager.getAll().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Add_Product_Invalid_Null_Fail()
        {
            this._productManager.Add(null);
        }
    }
}
